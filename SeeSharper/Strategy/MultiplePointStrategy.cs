/**************************************************************************
 *                                                                        *
 *  File:        MultiplePointStrategy.cs                                 *
 *  Copyright:   (c) 2021, Rusu Iulian                                    *
 *  E-mail:      iulian.rusu2@student.tuiasi.ro                           *
 *  Description: Class for strategies that require two clicks             *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System.Collections.Generic;
using System.Drawing;

namespace Strategy
{
    /// <summary>
    ///  Base class for brushes
    /// </summary>
	public abstract class MultiplePointStrategy : Strategy
	{
        #region Protected Fields
        protected List<Point> _points;
        #endregion

        #region Public Methods
        public override void Reset()
        {
            _done = false;
            _points = null;
            _hasDrawn = false;
        }
        public override string GetDescription()
        {
            if (_points != null)
                return $"Brush from {_points[0]} to {_points[_points.Count - 1]}";
            else return "";
        }
        #endregion
    }
}
