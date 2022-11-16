using DeepZoom.Marks.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DeepZoom.Marks.Controls
{
    /// <summary>
    /// 用于MultiScakeImage相关处理
    /// </summary>
    public class ShapeMark : BaseMark
    {
        private const string PartShape = "PART_Shape";
        private Shape _shape;


        public ShapeMark()
        {
            //this.Loaded += (s, e) =>
            //{
            //    if (MainThumb != null)
            //    {
            //        _shape = MainThumb.Template.FindName(PartShape, _mainThumb) as Shape;
            //    }
            //};
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

        

        protected virtual void OnScaleChanged(DependencyPropertyChangedEventArgs e) => UpdateShape();
        protected virtual void OnOffsetChanged(DependencyPropertyChangedEventArgs e) => UpdateShape();

        public virtual void UpdateShape() { }
    }
}
