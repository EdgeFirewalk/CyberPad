using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cyberpad
{
    public partial class MainWindow : Window
    {
        string currentDirectory;
        string samplesPath;
        bool nameBoxIsHidden = true;
        bool canPlay = true;

        MediaPlayer d1 = new MediaPlayer();
        MediaPlayer d2 = new MediaPlayer();
        MediaPlayer d3 = new MediaPlayer();
        MediaPlayer d4 = new MediaPlayer();
        MediaPlayer d5 = new MediaPlayer();
        MediaPlayer d6 = new MediaPlayer();
        MediaPlayer d7 = new MediaPlayer();
        MediaPlayer d8 = new MediaPlayer();
        MediaPlayer d9 = new MediaPlayer();
        MediaPlayer d0 = new MediaPlayer();

        MediaPlayer q = new MediaPlayer();
        MediaPlayer w = new MediaPlayer();
        MediaPlayer e = new MediaPlayer();
        MediaPlayer r = new MediaPlayer();
        MediaPlayer t = new MediaPlayer();
        MediaPlayer y = new MediaPlayer();
        MediaPlayer u = new MediaPlayer();
        MediaPlayer i = new MediaPlayer();
        MediaPlayer o = new MediaPlayer();
        MediaPlayer p = new MediaPlayer();

        MediaPlayer a = new MediaPlayer();
        MediaPlayer s = new MediaPlayer();
        MediaPlayer d = new MediaPlayer();
        MediaPlayer f = new MediaPlayer();
        MediaPlayer g = new MediaPlayer();
        MediaPlayer h = new MediaPlayer();
        MediaPlayer j = new MediaPlayer();
        MediaPlayer k = new MediaPlayer();
        MediaPlayer l = new MediaPlayer();
        MediaPlayer Oem1 = new MediaPlayer();

        MediaPlayer z = new MediaPlayer();
        MediaPlayer x = new MediaPlayer();
        MediaPlayer c = new MediaPlayer();
        MediaPlayer v = new MediaPlayer();
        MediaPlayer b = new MediaPlayer();
        MediaPlayer n = new MediaPlayer();
        MediaPlayer m = new MediaPlayer();
        MediaPlayer OemComma = new MediaPlayer();
        MediaPlayer OemPeriod = new MediaPlayer();
        MediaPlayer OemQuestion = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            currentDirectory = Environment.CurrentDirectory;
            LaunchpadCondBar.Value = 0;
            SongNameBox.Visibility = Visibility.Hidden;
            LoadTrackButton.Visibility = Visibility.Hidden;
        }

        private void Window_KeyDown(object sender, KeyEventArgs ev)
        {
            if (ev.Key == Key.D1 && canPlay == true)
            {
                _1.Foreground = new SolidColorBrush(Colors.Red);
                _1.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d1.Open(new System.Uri(samplesPath + "\\1.wav")); } catch { }
                d1.Play();
            }
            if (ev.Key == Key.D2 && canPlay == true)
            {
                _2.Foreground = new SolidColorBrush(Colors.Red);
                _2.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d2.Open(new System.Uri(samplesPath + "\\2.wav")); } catch { }
                d2.Play();
            }
            if (ev.Key == Key.D3 && canPlay == true)
            {
                _3.Foreground = new SolidColorBrush(Colors.Red);
                _3.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d3.Open(new System.Uri(samplesPath + "\\3.wav")); } catch { }
                d3.Play();
            }
            if (ev.Key == Key.D4 && canPlay == true)
            {
                _4.Foreground = new SolidColorBrush(Colors.Red);
                _4.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d4.Open(new System.Uri(samplesPath + "\\4.wav")); } catch { }
                d4.Play();
            }
            if (ev.Key == Key.D5 && canPlay == true)
            {
                _5.Foreground = new SolidColorBrush(Colors.Red);
                _5.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d5.Open(new System.Uri(samplesPath + "\\5.wav")); } catch { }
                d5.Play();
            }
            if (ev.Key == Key.D6 && canPlay == true)
            {
                _6.Foreground = new SolidColorBrush(Colors.Red);
                _6.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d6.Open(new System.Uri(samplesPath + "\\6.wav")); } catch { }
                d6.Play();
            }
            if (ev.Key == Key.D7 && canPlay == true)
            {
                _7.Foreground = new SolidColorBrush(Colors.Red);
                _7.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d7.Open(new System.Uri(samplesPath + "\\7.wav")); } catch { }
                d7.Play();
            }
            if (ev.Key == Key.D8 && canPlay == true)
            {
                _8.Foreground = new SolidColorBrush(Colors.Red);
                _8.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d8.Open(new System.Uri(samplesPath + "\\8.wav")); } catch { }
                d8.Play();
            }
            if (ev.Key == Key.D9 && canPlay == true)
            {
                _9.Foreground = new SolidColorBrush(Colors.Red);
                _9.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d9.Open(new System.Uri(samplesPath + "\\9.wav")); } catch { }
                d9.Play();
            }
            if (ev.Key == Key.D0 && canPlay == true)
            {
                _0.Foreground = new SolidColorBrush(Colors.Red);
                _0.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d0.Open(new System.Uri(samplesPath + "\\0.wav")); } catch { }
                d0.Play();
            }

            if (ev.Key == Key.Q && canPlay == true)
            {
                _q.Foreground = new SolidColorBrush(Colors.Red);
                _q.BorderBrush = new SolidColorBrush(Colors.Red);
                try { q.Open(new System.Uri(samplesPath + "\\q.wav")); } catch { }
                q.Play();
            }
            if (ev.Key == Key.W && canPlay == true)
            {
                _w.Foreground = new SolidColorBrush(Colors.Red);
                _w.BorderBrush = new SolidColorBrush(Colors.Red);
                try { w.Open(new System.Uri(samplesPath + "\\w.wav")); } catch { }
                w.Play();
            }
            if (ev.Key == Key.E && canPlay == true)
            {
                _e.Foreground = new SolidColorBrush(Colors.Red);
                _e.BorderBrush = new SolidColorBrush(Colors.Red);
                try { e.Open(new System.Uri(samplesPath + "\\e.wav")); } catch { }
                e.Play();
            }
            if (ev.Key == Key.R && canPlay == true)
            {
                _r.Foreground = new SolidColorBrush(Colors.Red);
                _r.BorderBrush = new SolidColorBrush(Colors.Red);
                try { r.Open(new System.Uri(samplesPath + "\\r.wav")); } catch { }
                r.Play();
            }
            if (ev.Key == Key.T && canPlay == true)
            {
                _t.Foreground = new SolidColorBrush(Colors.Red);
                _t.BorderBrush = new SolidColorBrush(Colors.Red);
                try { t.Open(new System.Uri(samplesPath + "\\t.wav")); } catch { }
                t.Play();
            }
            if (ev.Key == Key.Y && canPlay == true)
            {
                _y.Foreground = new SolidColorBrush(Colors.Red);
                _y.BorderBrush = new SolidColorBrush(Colors.Red);
                try { y.Open(new System.Uri(samplesPath + "\\y.wav")); } catch { }
                y.Play();
            }
            if (ev.Key == Key.U && canPlay == true)
            {
                _u.Foreground = new SolidColorBrush(Colors.Red);
                _u.BorderBrush = new SolidColorBrush(Colors.Red);
                try { u.Open(new System.Uri(samplesPath + "\\u.wav")); } catch { }
                u.Play();
            }
            if (ev.Key == Key.I && canPlay == true)
            {
                _i.Foreground = new SolidColorBrush(Colors.Red);
                _i.BorderBrush = new SolidColorBrush(Colors.Red);
                try { i.Open(new System.Uri(samplesPath + "\\i.wav")); } catch { }
                i.Play();
            }
            if (ev.Key == Key.O && canPlay == true)
            {
                _o.Foreground = new SolidColorBrush(Colors.Red);
                _o.BorderBrush = new SolidColorBrush(Colors.Red);
                try { o.Open(new System.Uri(samplesPath + "\\o.wav")); } catch { }
                o.Play();
            }
            if (ev.Key == Key.P && canPlay == true)
            {
                _p.Foreground = new SolidColorBrush(Colors.Red);
                _p.BorderBrush = new SolidColorBrush(Colors.Red);
                try { p.Open(new System.Uri(samplesPath + "\\p.wav")); } catch { }
                p.Play();
            }

            if (ev.Key == Key.A && canPlay == true)
            {
                _a.Foreground = new SolidColorBrush(Colors.Red);
                _a.BorderBrush = new SolidColorBrush(Colors.Red);
                try { a.Open(new System.Uri(samplesPath + "\\a.wav")); } catch { }
                a.Play();
            }
            if (ev.Key == Key.S && canPlay == true)
            {
                _s.Foreground = new SolidColorBrush(Colors.Red);
                _s.BorderBrush = new SolidColorBrush(Colors.Red);
                try { s.Open(new System.Uri(samplesPath + "\\s.wav")); } catch { }
                s.Play();
            }
            if (ev.Key == Key.D && canPlay == true)
            {
                _d.Foreground = new SolidColorBrush(Colors.Red);
                _d.BorderBrush = new SolidColorBrush(Colors.Red);
                try { d.Open(new System.Uri(samplesPath + "\\d.wav")); } catch { }
                d.Play();
            }
            if (ev.Key == Key.F && canPlay == true)
            {
                _f.Foreground = new SolidColorBrush(Colors.Red);
                _f.BorderBrush = new SolidColorBrush(Colors.Red);
                try { f.Open(new System.Uri(samplesPath + "\\f.wav")); } catch { }
                f.Play();
            }
            if (ev.Key == Key.G && canPlay == true)
            {
                _g.Foreground = new SolidColorBrush(Colors.Red);
                _g.BorderBrush = new SolidColorBrush(Colors.Red);
                try { g.Open(new System.Uri(samplesPath + "\\g.wav")); } catch { }
                g.Play();
            }
            if (ev.Key == Key.H && canPlay == true)
            {
                _h.Foreground = new SolidColorBrush(Colors.Red);
                _h.BorderBrush = new SolidColorBrush(Colors.Red);
                try { h.Open(new System.Uri(samplesPath + "\\h.wav")); } catch { }
                h.Play();
            }
            if (ev.Key == Key.J && canPlay == true)
            {
                _j.Foreground = new SolidColorBrush(Colors.Red);
                _j.BorderBrush = new SolidColorBrush(Colors.Red);
                try { j.Open(new System.Uri(samplesPath + "\\j.wav")); } catch { }
                j.Play();
            }
            if (ev.Key == Key.K && canPlay == true)
            {
                _k.Foreground = new SolidColorBrush(Colors.Red);
                _k.BorderBrush = new SolidColorBrush(Colors.Red);
                try { k.Open(new System.Uri(samplesPath + "\\k.wav")); } catch { }
                k.Play();
            }
            if (ev.Key == Key.L && canPlay == true)
            {
                _l.Foreground = new SolidColorBrush(Colors.Red);
                _l.BorderBrush = new SolidColorBrush(Colors.Red);
                try { l.Open(new System.Uri(samplesPath + "\\l.wav")); } catch { }
                l.Play();
            }
            if (ev.Key == Key.Oem1 && canPlay == true)
            {
                _Oem1.Foreground = new SolidColorBrush(Colors.Red);
                _Oem1.BorderBrush = new SolidColorBrush(Colors.Red);
                try { Oem1.Open(new System.Uri(samplesPath + "\\Oem1.wav")); } catch { }
                Oem1.Play();
            }

            if (ev.Key == Key.Z && canPlay == true)
            {
                _z.Foreground = new SolidColorBrush(Colors.Red);
                _z.BorderBrush = new SolidColorBrush(Colors.Red);
                try { z.Open(new System.Uri(samplesPath + "\\z.wav")); } catch { }
                z.Play();
            }
            if (ev.Key == Key.X && canPlay == true)
            {
                _x.Foreground = new SolidColorBrush(Colors.Red);
                _x.BorderBrush = new SolidColorBrush(Colors.Red);
                try { x.Open(new System.Uri(samplesPath + "\\x.wav")); } catch { }
                x.Play();
            }
            if (ev.Key == Key.C && canPlay == true)
            {
                _c.Foreground = new SolidColorBrush(Colors.Red);
                _c.BorderBrush = new SolidColorBrush(Colors.Red);
                try { c.Open(new System.Uri(samplesPath + "\\c.wav")); } catch { }
                c.Play();
            }
            if (ev.Key == Key.V && canPlay == true)
            {
                _v.Foreground = new SolidColorBrush(Colors.Red);
                _v.BorderBrush = new SolidColorBrush(Colors.Red);
                try { v.Open(new System.Uri(samplesPath + "\\v.wav")); } catch { }
                v.Play();
            }
            if (ev.Key == Key.B && canPlay == true)
            {
                _b.Foreground = new SolidColorBrush(Colors.Red);
                _b.BorderBrush = new SolidColorBrush(Colors.Red);
                try { b.Open(new System.Uri(samplesPath + "\\b.wav")); } catch { }
                b.Play();
            }
            if (ev.Key == Key.N && canPlay == true)
            {
                _n.Foreground = new SolidColorBrush(Colors.Red);
                _n.BorderBrush = new SolidColorBrush(Colors.Red);
                try { n.Open(new System.Uri(samplesPath + "\\n.wav")); } catch { }
                n.Play();
            }
            if (ev.Key == Key.M && canPlay == true)
            {
                _m.Foreground = new SolidColorBrush(Colors.Red);
                _m.BorderBrush = new SolidColorBrush(Colors.Red);
                try { m.Open(new System.Uri(samplesPath + "\\m.wav")); } catch { }
                m.Play();
            }
            if (ev.Key == Key.OemComma && canPlay == true)
            {
                _OemComma.Foreground = new SolidColorBrush(Colors.Red);
                _OemComma.BorderBrush = new SolidColorBrush(Colors.Red);
                try { OemComma.Open(new System.Uri(samplesPath + "\\OemComma.wav")); } catch { }
                OemComma.Play();
            }
            if (ev.Key == Key.OemPeriod && canPlay == true)
            {
                _OemPeriod.Foreground = new SolidColorBrush(Colors.Red);
                _OemPeriod.BorderBrush = new SolidColorBrush(Colors.Red);
                try { OemPeriod.Open(new System.Uri(samplesPath + "\\OemPeriod.wav")); } catch { }
                OemPeriod.Play();
            }
            if (ev.Key == Key.OemQuestion && canPlay == true)
            {
                _OemQuestion.Foreground = new SolidColorBrush(Colors.Red);
                _OemQuestion.BorderBrush = new SolidColorBrush(Colors.Red);
                try { OemQuestion.Open(new System.Uri(samplesPath + "\\OemQuestion.wav")); } catch { }
                OemQuestion.Play();
            }

            if (ev.Key == Key.Space && canPlay == true)
            {
                _space.Foreground = new SolidColorBrush(Colors.Red);
                _space.BorderBrush = new SolidColorBrush(Colors.Red);
                StopSounds();
            }

            if (ev.Key == Key.F1 && nameBoxIsHidden == true && canPlay == true)
            {
                _f1.Background = new SolidColorBrush(Color.FromRgb(63, 133, 249));
                SongNameBox.Text = "";
                SongNameBox.Visibility = Visibility.Visible;
                LoadTrackButton.Visibility = Visibility.Visible;
                canPlay = false;
                LaunchpadCondBar.Value = 30;
            }

            if (ev.Key == Key.Up && canPlay == true)
            {
                _up.Background = new SolidColorBrush(Color.FromRgb(63, 133, 249));
                HowToPlayText.FontSize++;
            }
            else if (ev.Key == Key.Down && canPlay == true)
            {
                _down.Background = new SolidColorBrush(Color.FromRgb(63, 133, 249));
                HowToPlayText.FontSize--;
            }

            if (ev.Key == Key.F9 && canPlay == true)
            {
                _f9.Background = new SolidColorBrush(Color.FromRgb(63, 133, 249));
            }

            if (ev.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }

        private void LoadTrackButton_Click(object sender, RoutedEventArgs e)
        {
            samplesPath = currentDirectory + "\\Samples\\" + SongNameBox.Text;
            ReadHowToPlayFile(samplesPath);
            SongNameBox.Visibility = Visibility.Hidden;
            LoadTrackButton.Visibility = Visibility.Hidden;
            songNameLabel.Content = SongNameBox.Text;
            LaunchpadCondBar.Value = 100;
            canPlay = true;
        }

        void StopSounds()
        {
            d1.Stop();
            d2.Stop();
            d3.Stop();
            d4.Stop();
            d5.Stop();
            d6.Stop();
            d7.Stop();
            d8.Stop();
            d9.Stop();
            d0.Stop();

            q.Stop();
            w.Stop();
            e.Stop();
            r.Stop();
            t.Stop();
            y.Stop();
            u.Stop();
            i.Stop();
            o.Stop();
            p.Stop();

            a.Stop();
            s.Stop();
            d.Stop();
            f.Stop();
            g.Stop();
            h.Stop();
            j.Stop();
            k.Stop();
            l.Stop();
            Oem1.Stop();

            z.Stop();
            x.Stop();
            c.Stop();
            v.Stop();
            b.Stop();
            n.Stop();
            m.Stop();
            OemComma.Stop();
            OemPeriod.Stop();
            OemQuestion.Stop();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            _1.Foreground = new SolidColorBrush(Colors.White);
            _1.BorderBrush = new SolidColorBrush(Colors.White);
            _2.Foreground = new SolidColorBrush(Colors.White);
            _2.BorderBrush = new SolidColorBrush(Colors.White);
            _3.Foreground = new SolidColorBrush(Colors.White);
            _3.BorderBrush = new SolidColorBrush(Colors.White);
            _4.Foreground = new SolidColorBrush(Colors.White);
            _4.BorderBrush = new SolidColorBrush(Colors.White);
            _5.Foreground = new SolidColorBrush(Colors.White);
            _5.BorderBrush = new SolidColorBrush(Colors.White);
            _6.Foreground = new SolidColorBrush(Colors.White);
            _6.BorderBrush = new SolidColorBrush(Colors.White);
            _7.Foreground = new SolidColorBrush(Colors.White);
            _7.BorderBrush = new SolidColorBrush(Colors.White);
            _8.Foreground = new SolidColorBrush(Colors.White);
            _8.BorderBrush = new SolidColorBrush(Colors.White);
            _9.Foreground = new SolidColorBrush(Colors.White);
            _9.BorderBrush = new SolidColorBrush(Colors.White);
            _0.Foreground = new SolidColorBrush(Colors.White);
            _0.BorderBrush = new SolidColorBrush(Colors.White);

            _q.Foreground = new SolidColorBrush(Colors.White);
            _q.BorderBrush = new SolidColorBrush(Colors.White);
            _w.Foreground = new SolidColorBrush(Colors.White);
            _w.BorderBrush = new SolidColorBrush(Colors.White);
            _e.Foreground = new SolidColorBrush(Colors.White);
            _e.BorderBrush = new SolidColorBrush(Colors.White);
            _r.Foreground = new SolidColorBrush(Colors.White);
            _r.BorderBrush = new SolidColorBrush(Colors.White);
            _t.Foreground = new SolidColorBrush(Colors.White);
            _t.BorderBrush = new SolidColorBrush(Colors.White);
            _y.Foreground = new SolidColorBrush(Colors.White);
            _y.BorderBrush = new SolidColorBrush(Colors.White);
            _u.Foreground = new SolidColorBrush(Colors.White);
            _u.BorderBrush = new SolidColorBrush(Colors.White);
            _i.Foreground = new SolidColorBrush(Colors.White);
            _i.BorderBrush = new SolidColorBrush(Colors.White);
            _o.Foreground = new SolidColorBrush(Colors.White);
            _o.BorderBrush = new SolidColorBrush(Colors.White);
            _p.Foreground = new SolidColorBrush(Colors.White);
            _p.BorderBrush = new SolidColorBrush(Colors.White);

            _a.Foreground = new SolidColorBrush(Colors.White);
            _a.BorderBrush = new SolidColorBrush(Colors.White);
            _s.Foreground = new SolidColorBrush(Colors.White);
            _s.BorderBrush = new SolidColorBrush(Colors.White);
            _d.Foreground = new SolidColorBrush(Colors.White);
            _d.BorderBrush = new SolidColorBrush(Colors.White);
            _f.Foreground = new SolidColorBrush(Colors.White);
            _f.BorderBrush = new SolidColorBrush(Colors.White);
            _g.Foreground = new SolidColorBrush(Colors.White);
            _g.BorderBrush = new SolidColorBrush(Colors.White);
            _h.Foreground = new SolidColorBrush(Colors.White);
            _h.BorderBrush = new SolidColorBrush(Colors.White);
            _j.Foreground = new SolidColorBrush(Colors.White);
            _j.BorderBrush = new SolidColorBrush(Colors.White);
            _k.Foreground = new SolidColorBrush(Colors.White);
            _k.BorderBrush = new SolidColorBrush(Colors.White);
            _l.Foreground = new SolidColorBrush(Colors.White);
            _l.BorderBrush = new SolidColorBrush(Colors.White);
            _Oem1.Foreground = new SolidColorBrush(Colors.White);
            _Oem1.BorderBrush = new SolidColorBrush(Colors.White);

            _z.Foreground = new SolidColorBrush(Colors.White);
            _z.BorderBrush = new SolidColorBrush(Colors.White);
            _x.Foreground = new SolidColorBrush(Colors.White);
            _x.BorderBrush = new SolidColorBrush(Colors.White);
            _c.Foreground = new SolidColorBrush(Colors.White);
            _c.BorderBrush = new SolidColorBrush(Colors.White);
            _v.Foreground = new SolidColorBrush(Colors.White);
            _v.BorderBrush = new SolidColorBrush(Colors.White);
            _b.Foreground = new SolidColorBrush(Colors.White);
            _b.BorderBrush = new SolidColorBrush(Colors.White);
            _n.Foreground = new SolidColorBrush(Colors.White);
            _n.BorderBrush = new SolidColorBrush(Colors.White);
            _m.Foreground = new SolidColorBrush(Colors.White);
            _m.BorderBrush = new SolidColorBrush(Colors.White);
            _OemComma.Foreground = new SolidColorBrush(Colors.White);
            _OemComma.BorderBrush = new SolidColorBrush(Colors.White);
            _OemPeriod.Foreground = new SolidColorBrush(Colors.White);
            _OemPeriod.BorderBrush = new SolidColorBrush(Colors.White);
            _OemQuestion.Foreground = new SolidColorBrush(Colors.White);
            _OemQuestion.BorderBrush = new SolidColorBrush(Colors.White);

            _space.Foreground = new SolidColorBrush(Colors.White);
            _space.BorderBrush = new SolidColorBrush(Colors.White);

            _f1.Background = null;
            _up.Background = null;
            _down.Background = null;
            _f9.Background = null;
        }

        void ReadHowToPlayFile(string path)
        {
            HowToPlayText.Content = "";
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
    }
}
