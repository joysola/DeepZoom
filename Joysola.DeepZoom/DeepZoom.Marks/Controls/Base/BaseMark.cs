using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DeepZoom.Marks.Controls.Base
{
    public class BaseMark : UserControl
    {
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(nameof(Offset), typeof(Point), typeof(BaseMark),
           new FrameworkPropertyMetadata(new Point(0.0, 0.0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnOffsetChanged));


        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(nameof(Scale), typeof(double), typeof(BaseMark),
            new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnScaleChanged));

        public Point Offset
        {
            get => (Point)GetValue(OffsetProperty);
            set => SetValue(OffsetProperty, value);
        }

        public double Scale
        {
            get
                => (double)GetValue(ScaleProperty);
            set => SetValue(ScaleProperty, value);
        }

        private static void OnScaleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
        private static void OnOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
        

    }
}
