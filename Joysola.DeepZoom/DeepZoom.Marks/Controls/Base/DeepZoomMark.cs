using DeepZoom.Marks.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DeepZoom.Marks.Controls
{
    /// <summary>
    /// 用于MultiScakeImage相关处理
    /// </summary>
    public class DeepZoomMark : BaseMark
    {
        private const string PartShape = "PART_Shape";
        private Shape _shape;
        /// <summary>
        /// 是否正在拖动
        /// </summary>
        private bool _isDraging = false;

        public DeepZoomMark()
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

        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(nameof(Offset), typeof(Point), typeof(DeepZoomMark),
           new FrameworkPropertyMetadata(new Point(0.0, 0.0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnOffsetChanged));

        private static void OnOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DeepZoomMark shapeMark)
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

        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(nameof(Scale), typeof(double), typeof(DeepZoomMark),
            new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnScaleChanged));
        private static void OnScaleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DeepZoomMark shapeMark)
            {
                shapeMark.OnScaleChanged(e);
            }
        }
        #endregion Scale

        #region MSIRect
        public Rect MSIRect
        {
            get => (Rect)GetValue(MSIRectProperty);
            set => SetValue(MSIRectProperty, value);
        }
        public static readonly DependencyProperty MSIRectProperty = DependencyProperty.Register(nameof(MSIRect), typeof(Rect), typeof(DeepZoomMark),
           new FrameworkPropertyMetadata(default(Rect), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnMSIRectChanged));

        private static void OnMSIRectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DeepZoomMark shapeMark)
            {
                shapeMark.OnMSIRectChanged(e);
            }
        }
        #endregion MSIRect

        private DispatcherOperation RealizeOperation { get; set; }
        private DispatcherPriority RealizationPriority { get; set; } = DispatcherPriority.Render;
        #endregion Properties


        /// <summary>
        /// Scale变化触发更新
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnScaleChanged(DependencyPropertyChangedEventArgs e) => UpdateShape();
        /// <summary>
        /// Offset变化触发更新
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnOffsetChanged(DependencyPropertyChangedEventArgs e) => UpdateShape();
        /// <summary>
        /// MSI坐标更新后，触发更新
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnMSIRectChanged(DependencyPropertyChangedEventArgs e)
        {
            if (!_isDraging)
            {
                UpdateShape();
            }
        }
        /// <summary>
        /// 更新图形
        /// </summary>
        public virtual void UpdateShape()
        {
            SetTargetActualBound(this.MsiToCanvas(MSIRect));
            //RealizeOperation?.Abort();
            //Action action = null;
            //action = () =>
            //{
            //    RealizeOperation = null;
            //    SetTargetActualBound(this.MsiToCanvas(MSIRect));
            //    RealizeOperation ??= base.Dispatcher.BeginInvoke(action, RealizationPriority);
            //};
            //RealizeOperation = base.Dispatcher.BeginInvoke(action, RealizationPriority);
        }

        /// <summary>
        /// 拖拽完成后，更新msi数据
        /// </summary>
        /// <param name="NewBound"></param>
        protected override void RaisenDragCompletedEvent(Rect NewBound)
        {
            base.RaisenDragCompletedEvent(NewBound);
            _isDraging = true;
            MSIRect = NewBound.CanvasToMsi(Offset, Scale);
            _isDraging = false;
        }


    }
}
