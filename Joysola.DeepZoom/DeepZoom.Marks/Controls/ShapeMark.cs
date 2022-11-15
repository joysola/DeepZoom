using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DeepZoom.Marks.Controls
{
    [TemplatePart(Name = "PART_MainCustomThumb", Type = typeof(CustomThumb))]
    public class ShapeMark : BaseMark
    {
        private const string PartShape = "PART_Shape";
        private const string PartMainCustomThumb = "PART_MainCustomThumb";

        private Shape _shape;

        private CustomThumb _mainThumb;

        public ShapeMark()
        {
            this.Loaded += (s, e) =>
            {
                _mainThumb = Template?.FindName(PartMainCustomThumb, this) as CustomThumb;
                if (_mainThumb != null)
                {
                    _shape = _mainThumb.Template.FindName(PartShape, _mainThumb) as Shape;
                }
            };
        }

        #region GetTargetActualBound
        protected override Rect GetTargetActualBound()
        {
            if (_shape == null)
            {
                return Rect.Empty;
            }

            double Top = CorrectDoubleValue(Canvas.GetTop(_shape));
            double Left = CorrectDoubleValue(Canvas.GetLeft(_shape));



            return new Rect
            {
                X = Left,
                Y = Top,
                Width = _shape.ActualWidth,
                Height = _shape.ActualHeight
            };
        }
        #endregion
        #region SetTargetActualBound
        protected override void SetTargetActualBound(Rect NewBound)
        {
            if (_shape != null)
            {
                _shape.Width = NewBound.Width;
                _shape.Height = NewBound.Height;
                Canvas.SetTop(_shape, NewBound.Y);
                Canvas.SetLeft(_shape, NewBound.X);
            }
        }
        #endregion


        protected override void RaisenDragCompletedEvent(Rect NewBound)
        {
            RaiseEvent(new DragChangedEventArgs(DragCompletedEvent, NewBound, _shape));
        }

        protected override void RaisenDragChangingEvent(Rect NewBound)
        {
            RaiseEvent(new DragChangedEventArgs(DragChangingEvent, NewBound, _shape));
        }
    }
}
