using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace EdgeTTS.Framework.Test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        EdgeTTSClient et = new EdgeTTSClient();
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            //et.Sec_MS_GEC_UpDate_Url = "http://123.207.46.66:8086/api/getGec";
            var str = tbSayContent.Text;
            var voice = CbSpeaker.Text;
            var rate = srate.Value;//13
            Task.Run(() =>
            {
                var ms = et.SynthesisAsync(str, voice, pitch: $"{(rate >= 0 ? "+" : "")}{rate.ToString("f2")}Hz").Result;
                if (ms.Code != ResultCode.Success)
                {
                    MessageBox.Show("生成失败");
                    return;
                }
                var dtn = DateTime.Now.Ticks.ToString();
                var file = $"test-{dtn}.mp3";
                FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
                BinaryWriter w = new BinaryWriter(fs);
                w.Write(ms.Data.ToArray());
                fs.Close();
                fs.Dispose();
                w.Dispose();
                Dispatcher.Invoke(() =>
                {
                    Player.Clock = new MediaTimeline(new Uri(Path.Combine(Environment.CurrentDirectory, file))).CreateClock();
                    Player.Play();
                });
            });

        }
    }
}
