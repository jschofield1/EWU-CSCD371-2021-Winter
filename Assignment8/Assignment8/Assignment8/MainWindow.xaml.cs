using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
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
        private int entryNumber = 1;

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
            if (StartAndStop.Content.ToString() == "Start new timer")
            {
                _StartTime = DateTime.Now;
                dispatcherTimer.Start();
                _IsStopped = false;
                StartAndStop.Content = "Stop timer";
                StartAndStop.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff0000");

                AddEntry.Visibility = Visibility.Hidden;
                Description.Visibility = Visibility.Hidden;
                if (EntryBox.Items.Count == 0)
                {
                    SaveEntries.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                dispatcherTimer.Stop();
                _IsStopped = true;
                StartAndStop.Content = "Start new timer";
                StartAndStop.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#00cc00");
              
                Description.Text = "Entry" + entryNumber + " (" + _StartTime.ToString("MMM dd") + ", " + _StartTime.ToString("hh:mm tt") + ")";

                AddEntry.Visibility = Visibility.Visible;
                Description.Visibility = Visibility.Visible;
            }
        }

        private void AddEntry_Click(object sender, RoutedEventArgs e)
        {
            if (_IsStopped && Timer.Text != "00:00:00")
            {
                EntryBox.Items.Add($"{_Description}{" - "}{Timer.Text}");
                Description.Text = "";
                Timer.Text = "00:00:00";

                entryNumber++;

                AddEntry.Visibility = Visibility.Hidden;
                Description.Visibility = Visibility.Hidden;
                SaveEntries.Visibility = Visibility.Visible;
            }
        }

        private void EntryBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                EntryBox.Items.Remove(EntryBox.SelectedItem);

                if (EntryBox.Items.Count == 0)
                {
                    SaveEntries.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Description_TextChanged(object sender, TextChangedEventArgs e) => _Description = Description.Text;

        private void SaveEntries_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new();
            SaveFileDialog saveFileDialog = new();

            if (saveFileDialog.ShowDialog() == true)
            {
                foreach (var item in EntryBox.Items)
                {
                    _ = stringBuilder.AppendLine(item.ToString());
                }
            }

            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, stringBuilder.ToString());
            }
        }

        private void LoadEntries_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                var fileLines = File.ReadAllLines(fileName);

                foreach (string line in fileLines)
                {
                    _ = EntryBox.Items.Add(line);
                }
            }
        }
    }
}
