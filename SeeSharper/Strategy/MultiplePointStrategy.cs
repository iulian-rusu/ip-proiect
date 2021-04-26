/**************************************************************************
 *                                                                        *
 *  File:        MultiplePointStrategy.cs                                 *
 *  Copyright:   (c) 2021, Nistor Paula-Alina                             *
 *  E-mail:      paula-alina.nistor@student.tuiasi.ro                     *
 *  Description:                                                          *
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
	public abstract class MultiplePointStrategy : Strategy
	{
		protected List<Point> _points;
        public override void Reset()
        {

        }
        public override string GetDescription()
        {
            return "";
        }
    }
}
