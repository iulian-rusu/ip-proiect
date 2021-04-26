using System.Windows.Forms;

namespace Strategy
{
    public class BrushStrategy : MultiplePointStrategy
    {
        public override void MouseClicked(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        public override void MouseMoved(int x, int y)
        {
            throw new System.NotImplementedException();
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

