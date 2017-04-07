using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;

namespace HighlightDatePickerDemo
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private IList<HighlightedDate> _highlightedDates;

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

        public IList<HighlightedDate> HighlightedDates
        {
            get { return _highlightedDates; }
            set
            {
                _highlightedDates = value;
                OnPropertyChanged(() => HighlightedDates);
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            HighlightedDates = new ObservableCollection<HighlightedDate>(HighlightedDates) 
            {
                new HighlightedDate(DateTime.Today, "Today")
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(body.Member.Name));
        }
    }
}
