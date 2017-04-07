using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HighlightDatePickerDemo
{
    public class HighlightDatePicker : DatePicker
    {
        static HighlightDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HighlightDatePicker), new FrameworkPropertyMetadata(typeof(HighlightDatePicker)));
        }

        public static readonly DependencyProperty HighlightedDatesProperty = DependencyProperty.Register("HighlightedDates", typeof(IList<HighlightedDate>), typeof(HighlightDatePicker));

        public IList<HighlightedDate> HighlightedDates
        {
            get { return (IList<HighlightedDate>)GetValue(HighlightedDatesProperty); }
            set { SetValue(HighlightedDatesProperty, value); }
        }

        public static readonly DependencyProperty HighlightBrushProperty = DependencyProperty.Register("HighlightBrush", typeof(Brush),
            typeof(HighlightDatePicker), new PropertyMetadata(Brushes.Orange));

        public Brush HighlightBrush
        {
            get { return (Brush)GetValue(HighlightBrushProperty); }
            set { SetValue(HighlightBrushProperty, value); }
        }
    }

    public class HighlightedDate
    {
        public HighlightedDate(DateTime date, string description)
        {
            Date = date;
            Description = description;
        }

        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
