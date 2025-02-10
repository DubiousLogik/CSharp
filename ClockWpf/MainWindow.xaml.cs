using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string currentTime1;
        private string currentTime2;
        private string currentTime3;
        private string currentTime4;

        private DateTime time1;
        private DateTime time2;
        private DateTime time3;
        private DateTime time4;

        private TimeZoneInfo selectedTimeZone1;
        private TimeZoneInfo selectedTimeZone2;
        private TimeZoneInfo selectedTimeZone3;
        private TimeZoneInfo selectedTimeZone4;

        private string selectedTimeZone1DisplayName;
        private string selectedTimeZone2DisplayName;
        private string selectedTimeZone3DisplayName;
        private string selectedTimeZone4DisplayName;

        public MainWindow()
        {
            this.SetDefaultTimeZones();

            InitializeComponent();

            var timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += (sender, eventArgs) =>
            {
                UpdateTimes();
            };
        }

        public List<TimeZoneInfo> TimeZones
        {
            get { return TimeZoneInfo.GetSystemTimeZones().ToList(); }
        }

        public string CurrentTime1
        {
            get { return currentTime1; }
            set { currentTime1 = value; OnPropertyChanged("CurrentTime1"); }
        }

        public string CurrentTime2
        {
            get { return currentTime2; }
            set { currentTime2 = value; OnPropertyChanged("CurrentTime2"); }
        }

        public string CurrentTime3
        {
            get { return currentTime3; }
            set { currentTime3 = value; OnPropertyChanged("CurrentTime3"); }
        }

        public string CurrentTime4
        {
            get { return currentTime4; }
            set { currentTime4 = value; OnPropertyChanged("CurrentTime4"); }
        }

        public TimeZoneInfo SelectedTimeZone1
        {
            get { return selectedTimeZone1; }
            set
            {
                selectedTimeZone1 = value;
                SelectedTimeZone1DisplayName = this.GetShortTimeZoneName(selectedTimeZone1.DisplayName);
                OnPropertyChanged("SelectedTimeZone1");
            }
        }

        public string SelectedTimeZone1DisplayName
        {
            get { return this.selectedTimeZone1DisplayName; }
            set { this.selectedTimeZone1DisplayName = value; OnPropertyChanged("SelectedTimeZone1DisplayName"); }
        }

        public TimeZoneInfo SelectedTimeZone2
        {
            get { return selectedTimeZone2; }
            set
            {
                selectedTimeZone2 = value;
                SelectedTimeZone2DisplayName = this.GetShortTimeZoneName(selectedTimeZone2.DisplayName);
                OnPropertyChanged("SelectedTimeZone2");
            }
        }

        public string SelectedTimeZone2DisplayName
        {
            get { return this.selectedTimeZone2DisplayName; }
            set { this.selectedTimeZone2DisplayName = value; OnPropertyChanged("SelectedTimeZone2DisplayName"); }
        }

        public TimeZoneInfo SelectedTimeZone3
        {
            get { return selectedTimeZone3; }
            set
            {
                selectedTimeZone3 = value;
                SelectedTimeZone3DisplayName = this.GetShortTimeZoneName(selectedTimeZone3.DisplayName);
                OnPropertyChanged("SelectedTimeZone3");
            }
        }

        public string SelectedTimeZone3DisplayName
        {
            get { return this.selectedTimeZone3DisplayName; }
            set { this.selectedTimeZone3DisplayName = value; OnPropertyChanged("SelectedTimeZone3DisplayName"); }
        }

        public TimeZoneInfo SelectedTimeZone4
        {
            get { return selectedTimeZone4; }
            set
            {
                selectedTimeZone4 = value;
                SelectedTimeZone4DisplayName = this.GetShortTimeZoneName(selectedTimeZone4.DisplayName);
                OnPropertyChanged("SelectedTimeZone4");
            }
        }

        public string SelectedTimeZone4DisplayName
        {
            get { return this.selectedTimeZone4DisplayName; }
            set { this.selectedTimeZone4DisplayName = value; OnPropertyChanged("SelectedTimeZone4DisplayName"); }
        }

        public void UpdateTimes()
        {
            time1 = UpdateDateTime(SelectedTimeZone1);
            time2 = UpdateDateTime(SelectedTimeZone2);
            time3 = UpdateDateTime(SelectedTimeZone3);
            time4 = UpdateDateTime(SelectedTimeZone4);

            CurrentTime1 = this.ConvertToDisplayFormat(time1, SelectedTimeZone1);
            CurrentTime2 = this.ConvertToDisplayFormat(time2, SelectedTimeZone2);
            CurrentTime3 = this.ConvertToDisplayFormat(time3, SelectedTimeZone3);
            CurrentTime4 = this.ConvertToDisplayFormat(time4, SelectedTimeZone4);

            // Analog Clock Hands
            Time1MinuteHand.Angle = time1.Minute * 6; OnPropertyChanged("Time1Minutes");
            Time1HourHand.Angle = (time1.Hour * 30) + (time1.Minute * 0.5); OnPropertyChanged("Time1Hours");

            Time2MinuteHand.Angle = time2.Minute * 6; OnPropertyChanged("Time1Minutes");
            Time2HourHand.Angle = (time2.Hour * 30) + (time2.Minute * 0.5); OnPropertyChanged("Time1Hours");

            Time3MinuteHand.Angle = time3.Minute * 6; OnPropertyChanged("Time1Minutes");
            Time3HourHand.Angle = (time3.Hour * 30) + (time3.Minute * 0.5); OnPropertyChanged("Time1Hours");
        }

        public DateTime UpdateDateTime(TimeZoneInfo selectedTimeZone)
        {
            if (selectedTimeZone == null || selectedTimeZone == TimeZoneInfo.Utc)
            {
                return DateTime.UtcNow;
            }

            //return DateTime.UtcNow.AddHours(selectedTimeZone.BaseUtcOffset.TotalHours);
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, selectedTimeZone);
        }

        public string ConvertToDisplayFormat(DateTime time, TimeZoneInfo selectedTimeZone)
        {
            if (selectedTimeZone == null || selectedTimeZone == TimeZoneInfo.Utc)
            {
                // Use 24hr time for Utc
                return time.ToString("HH:mm:ss");
            }

            return time.ToLongTimeString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void SetDefaultTimeZones()
        {
            SelectedTimeZone1 = TimeZoneInfo.GetSystemTimeZones().Where(tz => tz.DisplayName.Contains("London")).First();
            SelectedTimeZone2 = TimeZoneInfo.GetSystemTimeZones().Where(tz => tz.DisplayName.Contains("Eastern")).First();
            SelectedTimeZone3 = TimeZoneInfo.GetSystemTimeZones().Where(tz => tz.DisplayName.Contains("Pacific")).First();
            SelectedTimeZone4 = TimeZoneInfo.Utc;
        }

        public string GetShortTimeZoneName(string longName)
        {
            string[] tokens1 = longName.Split(')');
            string tempName = tokens1[1];
            string[] tokens2 = tempName.Split('(');
            string shortName = tokens2[0].Trim();

            if (shortName.StartsWith("Coordinated"))
            {
                shortName = "Utc";
            }

            if (shortName.Contains("London"))
            {
                shortName = "London";
            }

            return shortName;
        }

        // Can execute
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Minimize
        private void CommandBinding_Executed_Minimize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        // Maximize
        private void CommandBinding_Executed_Maximize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        // Restore
        private void CommandBinding_Executed_Restore(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        // Close
        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        // State change
        private void MainWindowStateChangeRaised(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MainWindowBorder.BorderThickness = new Thickness(8);
                RestoreButton.Visibility = Visibility.Visible;
                MaximizeButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MainWindowBorder.BorderThickness = new Thickness(0);
                RestoreButton.Visibility = Visibility.Collapsed;
                MaximizeButton.Visibility = Visibility.Visible;
            }
        }
    }
}
