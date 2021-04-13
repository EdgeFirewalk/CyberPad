using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using NAudio.Wave;

namespace Cyberpad
{
    public partial class MainWindow : Window
    {
        private string programPath;

        private string samplesPath; // DISC:\\...\...\...\...\Samples
        private string songPath;    // DISC:\\...\...\...\...\Samples\<SongName>

        string[] songs; // Contains songs from samplesPath (every song is a folder with sounds)

        private bool playLock = false; // Equals true when you choosing a song

        enum ButtonCodes
        {
            D1, D2, D3, D4, D5, D6, D7, D8, D9, D0,
            Q, W, E, R, T, Y, U, I, O, P,
            A, S, D, F, G, H, J, K, L, Oem1,
            Z, X, C, V, B, N, M, OemComma, OemPeriod, OemQuestion
        }

        Button[] buttons = new Button[40];

        MediaPlayer[] samples = new MediaPlayer[40];

        public MainWindow()
        {
            InitializeComponent();

            programPath = Environment.CurrentDirectory;

            samplesPath = programPath + @"\Samples\"; // DISC:\\...\...\...\<ProgramFloder>\Samples

            InitializeButtons();
            ReadSamplesFolder();
            LaunchpadCondBar.Foreground = Brushes.Yellow;

            volumeSlider.Visibility = Visibility.Hidden;
            entAndVolTextLabel.Visibility = Visibility.Hidden;

            if (File.Exists(programPath + @"\sets.lp")) { }
            else
            {
                Process.Start(programPath + @"\Fonts\Glitch inside.otf");
                MessageBox.Show("Please add \"Glitch Inside\" font for better experience.", "Font Message");
                File.Create(programPath + @"\sets.lp");
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

            LoadSamples();
            ReadHowToPlayFile();

            songsListComboBox.Visibility = Visibility.Hidden;
            f2ButtonText.Visibility = Visibility.Hidden;

            LaunchpadCondBar.Foreground = Brushes.LightGreen;
            playLock = false;
        }

        private void LoadSamples()
        {
            for (int i = 0; i < samples.Length; i++)
            {
                samples[i] = new MediaPlayer();
                samples[i].Volume = 0;
                samples[i].Open(new Uri(songPath + "\\" + ((ButtonCodes)i) + ".wav"));
                volumeSlider.Value = samples[i].Volume;
            }
            volumeSlider.Visibility = Visibility.Visible;
            entAndVolTextLabel.Visibility = Visibility.Visible;
        }

        private void ReadHowToPlayFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(songPath + @"\howtoplay.lp"))
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

                    try
                    {
                        //samples[i].Volume = 1;
                        samples[i].Play();
                        samples[i].Open(new Uri(songPath + "\\" + ((ButtonCodes)i) + ".wav"));
                    }
                    catch { }

                    break;
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
            else if (e.Key == Key.F9) 
            {
                if (File.Exists(programPath + @"\help.txt"))
                {
                    Process.Start(programPath + @"\help.txt");
                }
                else
                {
                    FileInfo helpFile = new FileInfo(programPath + @"\help.txt");
                    using (StreamWriter streamWriter = helpFile.CreateText())
                    {
                        streamWriter.WriteLine(@"  _              _    _ _   _  _____ _    _ _____        _____  
 | |        /\  | |  | | \ | |/ ____| |  | |  __ \ /\   |  __ \ 
 | |       /  \ | |  | |  \| | |    | |__| | |__) /  \  | |  | |
 | |      / /\ \| |  | | . ` | |    |  __  |  ___/ /\ \ | |  | |
 | |____ / ____ \ |__| | |\  | |____| |  | | |  / ____ \| |__| |
 |______/_/    \_\____/|_| \_|\_____|_|  |_|_| /_/    \_\_____/ 
                                                   by EdgeFirewalk");

                        streamWriter.Write(@"
1) How to load a song:
    * Press F1
    * Choose a song from the list
    * Press 'ENTER' and adjust volume on the slidebar
    * Enjoy (･ω<)☆

    ---FUNCTIONS---
    [Keyboard buttons] - Play
    [Up Arrow] - Make text on your right bigger
    [Down Arrow] - Make text on your right smaller
    [Space] - Stop all sound");
                    }

                    Process.Start(programPath + @"\help.txt");
                }
            }
            else if (e.Key == Key.Enter)
            {
                volumeSlider.IsEnabled = true;
                entAndVolTextLabel.Content = "Volume: " + (volumeSlider.Value * 100);
            }
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

        private void StopSounds()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                samples[i].Stop();
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

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            for (int i = 0; i < samples.Length; i++)
            {
                samples[i].Volume = volumeSlider.Value;
                entAndVolTextLabel.Content = "Volume: " + Math.Round((volumeSlider.Value * 100), 0);
            }
        }
    }
}