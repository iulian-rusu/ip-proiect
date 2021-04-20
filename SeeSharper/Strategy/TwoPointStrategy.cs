using System;
using System.Drawing;

namespace Strategy
{
	public abstract class TwoPointStrategy : Strategy
	{
		private Tuple<Point, Point> points;
	}
}

