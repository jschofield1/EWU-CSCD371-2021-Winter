using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Assignment8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer dispatcherTimer = new();
        private DateTime _StartTime = DateTime.Now;
        private string _Description;
        private bool _IsStopped = true;
        private int count = 1;

        public MainWindow()
        {
            InitializeComponent();

            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Timer.Text = (DateTime.Now - _StartTime).ToString(@"hh\:mm\:ss");
        }

        private void StartAndStop_Click(object sender, RoutedEventArgs e)
        {
            if (StartAndStop.Content.ToString() == "Start")
            {
                _StartTime = DateTime.Now;
                dispatcherTimer.Start();
                _IsStopped = false;
                Save.Visibility = Visibility.Hidden;
                Description.Visibility = Visibility.Hidden;
                StartAndStop.Content = "Stop";
                StartAndStop.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000");
            }
            else
            {
                dispatcherTimer.Stop();
                _IsStopped = true;
                StartAndStop.Content = "Start";
                StartAndStop.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#00cc00");
                Save.Visibility = Visibility.Visible;
                Description.Visibility = Visibility.Visible;
                Description.Text = "Event " + count + " (" + _StartTime.ToString("MMM dd") + ", " + _StartTime.ToString("hh:mm tt") + ")";
            }
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            if (_IsStopped && Timer.Text != "00:00:00")
            {
                SavedBox.Items.Add($"{_Description}{" - "}{Timer.Text}");
                count++;
                Description.Text = "";
                Timer.Text = "00:00:00";
                Save.Visibility = Visibility.Hidden;
                Description.Visibility = Visibility.Hidden;
            }
        }

        private void SavedBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                SavedBox.Items.Remove(SavedBox.SelectedItem);
            }
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e) => _Description = Description.Text;
    }
}
