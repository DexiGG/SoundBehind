using Microsoft.Win32;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace HomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread SoundBehindYourEars;
        public MainWindow()
        {
            InitializeComponent();
            soundbehind.MediaEnded += SoundBehind;
            soundbehind.Source = new Uri($@"{AppDomain.CurrentDomain.BaseDirectory}\music.mp3");

            SoundBehindYourEars = new Thread(soundbehind.Play) { IsBackground = true };
            SoundBehindYourEars.Start();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(targetPrint, "Текстовый элемент и кнопка");
            }
        }

        private void SoundBehind(object sender, RoutedEventArgs e)
        {
            soundbehind.Position = TimeSpan.FromMinutes(0);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
