using System.Windows.Forms;

namespace Strategy
{
    public class RectangleStrategy : TwoPointStrategy
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
            throw new System.NotImplementedException();
        }

        public override void MouseMoved(int x, int y)
        {
            throw new System.NotImplementedException();
        }
        private void Draw(object sender, PaintEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
