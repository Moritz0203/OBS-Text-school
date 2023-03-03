using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace OBS_Text
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timerOutput = new();

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        string path = "H:\\SOF\\OBS-Text-school-master\\OBSread.txt";

        string output = "";
        private void Timer_Tick(object sender, EventArgs e)
        {
            string Windowtime = DateTime.Now.ToString("HH:mm:ss");
            string Windowdate = DateTime.Now.ToString("dd:MM:yyyy");
            Zeit.Text = Windowtime;
            datum.Text = Windowdate;

            string date = DateCheck.IsChecked == true ? DateTime.Now.ToString("dd:MM:yyyy") + " " : "";
            string time = TimeCheck.IsChecked == true ? DateTime.Now.ToString("HH:mm:ss") : "";

            if (DateCheck.IsChecked == true || TimeCheck.IsChecked == true)
            {
                output = date + time + "  ";
            }
        }

        double value = 0;
        private void SliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SliderSpeed.Value != value)
            {
                value = SliderSpeed.Value;
                timerOutput.Interval = TimeSpan.FromMilliseconds(value);
                timerOutput.Tick += TimerOutput_Tick;
                timerOutput.Start();
            }
        }

        private void TimerOutput_Tick(object? sender, EventArgs e)
        {
            string Eingabe = eingabe.Text.Length != 0 ? eingabe.Text + " ### " : "";
            string Eingabe2 = eingabe2.Text.Length != 0 ? eingabe2.Text + " ### " : "";
            string Eingabe3 = eingabe3.Text.Length != 0 ? eingabe3.Text + " ### " : "";



            string allText;
            allText = Eingabe + Eingabe2 + Eingabe3;

            Dispatcher.Invoke(() =>
            {
                OutputPreview.Text = $"{output}";
                Trace.WriteLine($"{allText}" + $"{allText.Length}");
            });



            //File.WriteAllText(path, output);



        }
    }
}