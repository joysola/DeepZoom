using DeepZoom.Marks.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DeepZoom.Marks.Controls
{
    public class RectangleMark : ShapeMark
    {
        protected override void SetTargetActualBound(Rect NewBound)
        {
            base.SetTargetActualBound(NewBound);
            //MSIStartPoint = NewBound.TopLeft.CanvasToMsi(Offset, Scale);
            //MSIEndPoint = NewBound.BottomRight.CanvasToMsi(Offset, Scale);
        }


        public override void UpdateShape()
        {
            base.UpdateShape();
            var startPoint = this.MsiToCanvas(this.MSIStartPoint);
            var endPoint = this.MsiToCanvas(this.MSIEndPoint);
            var x = Math.Min(startPoint.X, endPoint.X);
            var y = Math.Min(startPoint.Y, endPoint.Y);
            var width = Math.Abs(startPoint.X - endPoint.X);
            var height = Math.Abs(startPoint.Y - endPoint.Y);
            SetTargetActualBound(new Rect { X = x, Y = y, Width = width, Height = height });
            //UpdateLayout();
        }
    }
}
