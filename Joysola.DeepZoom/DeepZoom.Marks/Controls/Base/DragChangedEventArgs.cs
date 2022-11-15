using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DeepZoom.Marks.Controls
{
    public class DragChangedEventArgs : RoutedEventArgs
    {
        public DragChangedEventArgs(RoutedEvent Event, Rect NewBound, object Target = null) : base(Event)
        {
            this.NewBound = NewBound;
            DragTargetElement = Target;
        }
        public Rect NewBound { get; private set; }

        public object DragTargetElement { get; private set; }
    }
    public delegate void DragChangedEventHandler(object Sender, DragChangedEventArgs e);
}
