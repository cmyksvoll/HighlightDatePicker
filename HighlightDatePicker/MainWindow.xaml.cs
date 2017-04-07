using System;
using System.Collections.Generic;
using System.Windows;

namespace HighlightDatePickerDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SelectedDate = DateTime.Now.Date;
            HighlightedDates = new List<HighlightedDate>
            {
                new HighlightedDate(DateTime.Today.AddDays(-3), "My birthday"),
                new HighlightedDate(DateTime.Today.AddDays(-2), "Wedding anniversary")
            };

            InitializeComponent();
        }

        public DateTime SelectedDate { get; set; }

        public IList<HighlightedDate> HighlightedDates { get; set; }
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
