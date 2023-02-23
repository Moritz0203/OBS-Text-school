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
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        string path = "C:\\Users\\morit\\OneDrive\\Desktop\\school\\OBS Text\\OBSread.txt";
      

        private void Timer_Tick(object sender, EventArgs e)
        {

            string Windowtime = DateTime.Now.ToString("HH:mm:ss");
            string Windowdate = DateTime.Now.ToString("dd:MM:yyyy");
            Zeit.Text = Windowtime;
            datum.Text = Windowdate;

            string date = DateCheck.IsChecked == true ? DateTime.Now.ToString("dd:MM:yyyy") + " " : "";
            string time = TimeCheck.IsChecked == true ? DateTime.Now.ToString("HH:mm:ss") : "";
            string Eingabe = eingabe.Text.Length != 0 ? eingabe.Text : "";
            string Eingabe2 = eingabe2.Text.Length != 0 ? eingabe2.Text : "";
            string Eingabe3 = eingabe3.Text.Length != 0 ? eingabe3.Text : "";

            string output = "";

            if ( DateCheck.IsChecked == true || TimeCheck.IsChecked == true) {
                output = date + time + "\n";
            }
      
            File.WriteAllText(path, output + Eingabe + "\n" + Eingabe2 + "\n" + Eingabe3);


            
        }

    }
}
