/**************************************************************************
 *                                                                        *
 *  File:        Program.cs                                               *
 *  Copyright:   (c) 2021, Beldiman Vladislav                             *
 *  E-mail:      vladislav.beldiman@student.tuiasi.ro                     *
 *  Description: Entry point for the application.                         *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using System;
using System.Windows.Forms;

namespace SeeSharper
{
    using Model;
    using Presenter;
    using Shared;
    using View;
    static class Program
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IModel model = new Model();
            IView view = new View();
            IPresenter presenter = new Presenter(model, view);
            view.SetPresenter(presenter);
            Application.Run((View)view);
        }
    }
}
