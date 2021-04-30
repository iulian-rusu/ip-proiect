/**************************************************************************
 *                                                                        *
 *  File:        UndoStack.cs                                             *
 *  Copyright:   (c) 2021, Baltariu Ionut-Alexandru                       *
 *  E-mail:      ionut-alexandru.baltariu@student.tuiasi.ro               *
 *  Description: Undo stack - used to memorize drawing states             *
 *               between actions                                          *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/


using Memento;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Undo stack - logic for the undo/redo process
    /// </summary>
    public class UndoStack
    {
        #region Private Fields
        private LinkedList<DrawingMemento> _stack;
        private LinkedListNode<DrawingMemento> _current;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the undo stack - initializes the double linked list used
        /// to store different states of the image
        /// </summary>
        public UndoStack()
        {
            _stack = new LinkedList<DrawingMemento>();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a drawing to the state stack
        /// </summary>
        /// <param name="drawing">The saved drawing</param>
        /// <returns>void</returns>
        public void Add(DrawingMemento drawing)
        {
            if (_stack.Count != 0 && _current != null)
            {
                while (_current != _stack.Last)
                {
                    _stack.RemoveLast();
                }
            }

            _stack.AddLast(drawing);
            _current = _stack.Last;
        }

        /// <summary>
        /// Clears the stack of all elements
        /// </summary>
        /// <returns>void</returns>
        public void Drop()
        {
            _stack.Clear();
        }

        /// <summary>
        /// Undoes the last drawing action
        /// </summary>
        /// <returns>The state of the drawing before the last done action</returns>
        public DrawingMemento Undo()
        {
            DrawingMemento undoneMemento = null;

            if (_current != null)
            {

                if (_current.Previous != null)
                {
                    _current = _current.Previous;
                }

                undoneMemento = _current.Value;

            }

            return undoneMemento;
        }

        /// <summary>
        /// Redoes the last undone drawing action
        /// </summary>
        /// <returns>The state of the drawing before the last undo action</returns>
        public DrawingMemento Redo()
        {
            DrawingMemento redoneMemento = null;

            if (_current != null)
            {

                if (_current.Next != null)
                {
                    _current = _current.Next;
                }

                redoneMemento = _current.Value;
            }

            return redoneMemento;
        }

        /// <summary>
        /// Used to get the description of the next undo
        /// </summary>
        /// <returns>The description of the next undo</returns>
        public string GetNextUndoDescription()
        {
            string description = string.Empty;

            if (_current != null)
            {
                description = _current.Value.Description;
            }

            return description;
        }

        /// <summary>
        /// Used to get the description of the next redo
        /// </summary>
        /// <returns>The description of the next redo</returns>
        public string GetNextRedoDescription()
        {
            string description = string.Empty;

            if (_current != null)
            {

                if (_current.Next != null)
                {
                    description = _current.Next.Value.Description;
                }

            }

            return description;
        }
        #endregion
    }
}
