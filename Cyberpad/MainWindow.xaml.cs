using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Cyberpad
{
    public partial class MainWindow : Window
    {
        private string currentDirectory;
        private string samplesPath;

        enum ButtonCodes
        {
            D1, D2, D3, D4, D5, D6, D7, D8, D9, D0,
            Q, W, E, R, T, Y, U, I, O, P,
            A, S, D, F, G, H, J, K, L, Oem1,
            Z, X, C, V, B, N, M, OemComma, OemPeriod, OemQuestion
        }

        MediaPlayer[] sounds = new MediaPlayer[40];
        Button[] buttons = new Button[40];

        public MainWindow()
        {
            InitializeComponent();

            currentDirectory = Environment.CurrentDirectory;
            LaunchpadCondBar.Value = 0;
            SongNameBox.Visibility = Visibility.Hidden;
            LoadTrackButton.Visibility = Visibility.Hidden;

            InitialiseMediaPlayers();
            InitialiseButtons();
        }

        private void InitialiseMediaPlayers()
        {
            double barValuePerButton = (LaunchpadCondBar.Maximum / 40) / 2;

            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i] = new MediaPlayer();
                sounds[i].Volume = 1;
                LaunchpadCondBar.Value += barValuePerButton;
            }
        }

        private void InitialiseButtons()
        {
            double barValuePerButton = (LaunchpadCondBar.Maximum / 40) / 2;

            int rows = 4;
            int cols = 10;

            int amountOf = -1;

            int xStep = 0;
            int yStep = 0;

            int iterator = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[iterator] = new Button();
                    amountOf++;

                    buttons[iterator].Width = 80;
                    buttons[iterator].Height = 80;

                    buttons[iterator].Foreground = Brushes.White;
                    buttons[iterator].Background = null;
                    buttons[iterator].BorderBrush = Brushes.White;
                    buttons[iterator].BorderThickness = new Thickness(5);

                    buttons[iterator].FontFamily = new FontFamily("Glitch inside");

                    buttons[iterator].VerticalContentAlignment = VerticalAlignment.Center;
                    buttons[iterator].HorizontalContentAlignment = HorizontalAlignment.Center;

                    buttons[iterator].Margin = new Thickness(70 + xStep, 245 + yStep, 0, 0);

                    //===========================Specific Buttons Here===================
                    if (amountOf < 9)
                    {
                        buttons[iterator].FontSize = 55;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = Convert.ToString(amountOf + 1);
                    }
                    else if (amountOf == 9)
                    {
                        buttons[iterator].FontSize = 55;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = "0";
                    }
                    else if (amountOf == 29)
                    {
                        buttons[iterator].FontSize = 50;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = ":";
                    }
                    else if (amountOf == 37)
                    {
                        buttons[iterator].FontSize = 50;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = "<";
                    }
                    else if (amountOf == 38)
                    {
                        buttons[iterator].FontSize = 50;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = ">";
                    }
                    else if (amountOf == 39)
                    {
                        buttons[iterator].FontSize = 50;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = "/";
                    }
                    //===================================================================
                    else
                    {
                        buttons[iterator].FontSize = 50;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = Convert.ToString((ButtonCodes)amountOf);
                    }

                    mainCanvas.Children.Add(buttons[iterator]);
                    LaunchpadCondBar.Value += barValuePerButton;
                    xStep += 85;
                    iterator++;
                }
                xStep = 0;
                yStep += 85;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter k = new KeyConverter();

            for (int i = 0; i < buttons.Length; i++)
            {
                Key mykey = (Key)k.ConvertFromString(buttons[i].Name);
                if (e.Key == mykey)
                {
                    buttons[i].Foreground = new SolidColorBrush(Colors.Red);
                    buttons[i].BorderBrush = new SolidColorBrush(Colors.Red);
                    try { sounds[i].Open(new Uri(samplesPath + "\\" + ((ButtonCodes)i) + ".wav")); } catch { }
                    sounds[i].Play();
                }
            }

            //===========================Specific Keys===================
            if (e.Key == Key.F1)
            {
                SongNameBox.Visibility = Visibility.Visible;
                LoadTrackButton.Visibility = Visibility.Visible;
            }
            else if (e.Key == Key.F9) { }
            else if (e.Key == Key.Space) { StopSounds(); }
            else if (e.Key == Key.Escape) { Close(); }
            else if (e.Key == Key.Up) { HowToPlayText.FontSize++; }
            else if (e.Key == Key.Down) { HowToPlayText.FontSize--; }
            //===========================================================
        }

        void StopSounds()
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i].Stop();
            }
        }

        private void LoadTrackButton_Click(object sender, RoutedEventArgs e)
        {
            samplesPath = currentDirectory + "\\Samples\\" + SongNameBox.Text;
            ReadHowToPlayFile(samplesPath);
            SongNameBox.Visibility = Visibility.Hidden;
            LoadTrackButton.Visibility = Visibility.Hidden;
            songNameLabel.Content = SongNameBox.Text;
        }

        private void ReadHowToPlayFile(string path)
        {
            HowToPlayText.Content = String.Empty;
            path = path + "\\howtoplay.lp";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    HowToPlayText.Content = sr.ReadToEnd();
                }
            }
            catch { }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Foreground = new SolidColorBrush(Colors.White);
                buttons[i].BorderBrush = new SolidColorBrush(Colors.White);
            }
        }

        private void SongNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SongNameBox.Text = String.Empty;
        }
    }
}