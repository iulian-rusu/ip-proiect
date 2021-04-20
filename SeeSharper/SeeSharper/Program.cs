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
    /// The main entry point for the application.
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
