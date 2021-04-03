using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Cyberpad
{
    public partial class MainWindow : Window
    {
        private string samplesPath; // DISC:\\...\...\...\...\Samples
        private string songPath;    // DISC:\\...\...\...\...\Samples\<SongName>

        private bool playLock = false; // Equals true when you choose a song

        enum ButtonCodes
        {
            D1, D2, D3, D4, D5, D6, D7, D8, D9, D0,
            Q, W, E, R, T, Y, U, I, O, P,
            A, S, D, F, G, H, J, K, L, Oem1,
            Z, X, C, V, B, N, M, OemComma, OemPeriod, OemQuestion
        }

        MediaPlayer[] sounds = new MediaPlayer[40];
        Button[] buttons = new Button[40];

        string[] songs; // Contains songs from samplesPath (every song is a folder)

        public MainWindow()
        {
            InitializeComponent();

            samplesPath = Environment.CurrentDirectory + @"\Samples\";

            InitializeMediaPlayers();
            InitializeButtons();
            ReadSamplesFolder();
        }

        private void InitializeMediaPlayers()
        {
            // Sounds initialization takes half of Launchpad's Progress Bar
            double barValuePerSound = ((LaunchpadCondBar.Maximum / sounds.Length) / 2);

            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i] = new MediaPlayer();
                LaunchpadCondBar.Value += barValuePerSound;
            }
        }

        private void InitializeButtons()
        {
            // Buttons initialization takes half of Launchpad's Progress Bar
            double barValuePerButton = ((LaunchpadCondBar.Maximum / buttons.Length) / 2);

            const int rows = 4;  // Of buttons
            const int cols = 10; // Of buttons

            int amountOf = 0; // Amount of buttons

            const int step = 85; // Step per button
            int xStep = 0;
            int yStep = 0;

            const int numbersFontSize = 55;
            const int lettersFontSize = 50;

            int iterator = 0; // For loops (not the same as amountOf)

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[iterator] = new Button();

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
                        buttons[iterator].FontSize = numbersFontSize;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = Convert.ToString(amountOf + 1);
                    }
                    else if (amountOf == 9)
                    {
                        buttons[iterator].FontSize = numbersFontSize;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = "0";
                    }
                    else if (amountOf == 29)
                    {
                        buttons[iterator].FontSize = lettersFontSize;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = ":";
                    }
                    else if (amountOf == 37)
                    {
                        buttons[iterator].FontSize = lettersFontSize;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = "<";
                    }
                    else if (amountOf == 38)
                    {
                        buttons[iterator].FontSize = lettersFontSize;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = ">";
                    }
                    else if (amountOf == 39)
                    {
                        buttons[iterator].FontSize = lettersFontSize;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = "/";
                    }
                    //===================================================================
                    else
                    {
                        buttons[iterator].FontSize = lettersFontSize;
                        buttons[iterator].Name = Convert.ToString((ButtonCodes)amountOf);
                        buttons[iterator].Content = Convert.ToString((ButtonCodes)amountOf);
                    }

                    mainCanvas.Children.Add(buttons[iterator]);
                    amountOf++;

                    LaunchpadCondBar.Value += barValuePerButton;

                    xStep += step;
                    iterator++;
                }
                xStep = 0;
                yStep += step;
            }
        }

        private void ReadSamplesFolder()
        {
            songs = System.IO.Directory.GetDirectories(samplesPath);
            foreach (string song in songs)
            {
                songsListComboBox.Items.Add(song);
            }
        }

        private void songsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = songsListComboBox.SelectedIndex;
            songPath = songs[i];

            string songName = new DirectoryInfo(songPath).Name;
            songNameLabel.Content = songName;

            ReadHowToPlayFile(songPath);

            songsListComboBox.Visibility = Visibility.Hidden;
            f2ButtonText.Visibility = Visibility.Hidden;

            playLock = false;
        }

        private void ReadHowToPlayFile(string path)
        {
            path = path + @"\howtoplay.lp"; // DISC:\\...\...\...\...\Samples\<SongName>\howtoplay.lp
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    HowToPlayText.Content = sr.ReadToEnd();
                }
            }
            catch 
            {
                HowToPlayText.Content = "---\"howtoplay.lp\" \nnot found---";
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            KeyConverter k = new KeyConverter();

            for (int i = 0; i < buttons.Length; i++)
            {
                Key mykey = (Key)k.ConvertFromString(buttons[i].Name);
                if (e.Key == mykey && !playLock)
                {
                    buttons[i].Foreground = new SolidColorBrush(Colors.Red);
                    buttons[i].BorderBrush = new SolidColorBrush(Colors.Red);
                    try { sounds[i].Open(new Uri(songPath + "\\" + ((ButtonCodes)i) + ".wav")); } catch { }
                    sounds[i].Play();
                }
            }

            //===========================Specific Keys===================
            if (e.Key == Key.F1)
            {
                playLock = true;

                songsListComboBox.Visibility = Visibility.Visible;
                f2ButtonText.Visibility = Visibility.Visible;
            }
            if (e.Key == Key.F2)
            {
                playLock = false;

                songsListComboBox.Visibility = Visibility.Hidden;
                f2ButtonText.Visibility = Visibility.Hidden;
            }
            else if (e.Key == Key.F9) { }
            else if (e.Key == Key.Space) { StopSounds(); }
            else if (e.Key == Key.Up && !playLock) 
            { 
                if (HowToPlayText.FontSize < 100)
                    HowToPlayText.FontSize++; 
            }
            else if (e.Key == Key.Down && !playLock) 
            { 
                if (HowToPlayText.FontSize > 10)
                    HowToPlayText.FontSize--; 
            }
            else if (e.Key == Key.Escape) { Close(); }
            //===========================================================
        }

        void StopSounds()
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                sounds[i].Stop();
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Foreground = new SolidColorBrush(Colors.White);
                buttons[i].BorderBrush = new SolidColorBrush(Colors.White);
            }
        }
    }
}