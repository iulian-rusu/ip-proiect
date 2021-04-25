using System.Windows.Forms;

namespace Strategy
{
    public class BrushStrategy : MultiplePointStrategy
    {
        public override PaintEventHandler GetDraw()
        {
            throw new System.NotImplementedException();
        }

        public override void IsDone()
        {
            throw new System.NotImplementedException();
        }

        public override void MouseClicked(int x, int y)
        {
        }

        public override void MouseMoved(int x, int y)
        {
        }
        private void Draw(object sender, PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

