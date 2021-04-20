using Memento;
using System.Collections.Generic;

namespace Model
{
	public class UndoStack
	{
		private LinkedList<DrawingMemento> _stack;
		private LinkedListNode<DrawingMemento> _current;

        public void Add(DrawingMemento drawing)
		{
			// TODO add implementation
		}

        public void Drop()
		{
			// TODO add implementation
		}

        public DrawingMemento Undo()
		{
            // TODO add implementation and return statement
            throw new System.NotImplementedException();
        }

		public DrawingMemento Redo()
		{
            // TODO add implementation and return statement
            throw new System.NotImplementedException();
        }
	}
}
