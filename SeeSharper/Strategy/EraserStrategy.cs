/**************************************************************************
 *                                                                        *
 *  File:        EraserStrategy.cs                                        *
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Strategy
{
    public class EraserStrategy : MultiplePointStrategy
    {
        public override void MouseMoved(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void MouseStateChanged(int x, int y)
        {
            throw new NotImplementedException();
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
