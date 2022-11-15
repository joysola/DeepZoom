using DeepZoom.Marks.Tools;
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

        #region Properties
        #region Offset
        public Point Offset
        {
            get => (Point)GetValue(OffsetProperty);
            set => SetValue(OffsetProperty, value);
        }

        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(nameof(Offset), typeof(Point), typeof(BaseMark),
           new FrameworkPropertyMetadata(new Point(0.0, 0.0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnOffsetChanged));

        private static void OnOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ShapeMark shapeMark)
            {
                shapeMark.OnOffsetChanged(e);
            }
        }
        #endregion Offset

        #region Scale
        public double Scale
        {
            get
                => (double)GetValue(ScaleProperty);
            set => SetValue(ScaleProperty, value);
        }

        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(nameof(Scale), typeof(double), typeof(BaseMark),
            new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnScaleChanged));
        private static void OnScaleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ShapeMark shapeMark)
            {
                shapeMark.OnScaleChanged(e);
            }
        }
        #endregion Scale

        public Point MSIStartPoint
        {
            get => (Point)GetValue(MSIStartPointProperty);
            set => SetValue(MSIStartPointProperty, value);
        }

        public static readonly DependencyProperty MSIStartPointProperty = DependencyProperty.Register(nameof(MSIStartPoint), typeof(Point), typeof(BaseMark),
            new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public Point MSIEndPoint
        {
            get => (Point)GetValue(MSIEndPointProperty);
            set => SetValue(MSIEndPointProperty, value);
        }

        public static readonly DependencyProperty MSIEndPointProperty = DependencyProperty.Register(nameof(MSIEndPoint), typeof(Point), typeof(BaseMark),
            new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public Point MSI_StratPoint { get; set; }
        public Point MSI_EndPoint { get; set; }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        #endregion Properties

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

        #region DragEvents
        protected override void RaisenDragCompletedEvent(Rect NewBound)
        {
            RaiseEvent(new DragChangedEventArgs(DragCompletedEvent, NewBound, _shape));
        }

        protected override void RaisenDragChangingEvent(Rect NewBound)
        {
            RaiseEvent(new DragChangedEventArgs(DragChangingEvent, NewBound, _shape));
        }
        #endregion DragEvents

        protected virtual void OnScaleChanged(DependencyPropertyChangedEventArgs e) => UpdateShape();
        protected virtual void OnOffsetChanged(DependencyPropertyChangedEventArgs e) => UpdateShape();

        public virtual void UpdateShape() { }
    }
}
