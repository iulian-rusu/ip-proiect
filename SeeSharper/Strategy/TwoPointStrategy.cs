using System;
using System.Collections.Generic;
using System.Drawing;

namespace Strategy
{
	public abstract class TwoPointStrategy : Strategy
	{
		protected Point[] _points;

		public void Reset()
        {
			_done = false;
			_points = null;
        }
	}
}

