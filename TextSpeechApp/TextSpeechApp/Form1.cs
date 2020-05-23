using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using WinForms = System.Windows.Forms;
using System.IO;

namespace TextSpeechApp
{
    public partial class Form_Speech : Form
    {
        public Form_Speech()
        {
            InitializeComponent();
        }

        private void FormSpeech_Load(object sender, EventArgs e)
        {
            LangList.Items.Add("tr-TR");
            LangList.Items.Add("en-US");
            LangList.Items.Add("de-DE");
            LangList.Items.Add("fr-FR");

            SpeecherList.Items.Add("A");
            SpeecherList.Items.Add("B");
            SpeecherList.Items.Add("C");
            SpeecherList.Items.Add("D");
            SpeecherList.Items.Add("E");

            Save_btn.Enabled = false;
            TextBox.Text = "/Soru 1\r| Seçenek 1 | Seçenek 2 | Seçenek 3 | Seçenek 4\r\r/ Soru 2\r| Seçenek 1 | Seçenek 2";
         
        }

        private void Speech_Btn_Click(object sender, EventArgs e)
        {
            string TempDir = System.IO.Path.GetTempPath() + "seslendirici\\";

            if (Directory.Exists(TempDir))
            {
                Directory.Delete(TempDir, true);
            }

            Directory.CreateDirectory(TempDir);

            if (LangList.SelectedIndex < 1)
            {
                LangList.SelectedIndex = 0;
            }

            if (SpeecherList.SelectedIndex < 1)
            {
                SpeecherList.SelectedIndex = 1;
            }

            var SelectedLang = LangList.Text;
            string[] Qs = { "soru", "question", "frage", "question" };
            string Q = Qs[LangList.SelectedIndex];
            string[] Os = { "şıkkı", "option", "option", "option" };
            string O = Os[LangList.SelectedIndex];
            string Speecher = SpeecherList.Text;


            var key = "%_YOUR_GOOGLE_TTS_AUTH_%";
            string alltext = TextBox.Text;
            var filename = "";
            alltext = alltext.Replace("\n", "");
            alltext = alltext.Replace("\r", "");
            string txt;
            string[] Qall = alltext.Split('/');
            int counterQ = 0;
            foreach (var q in Qall)
            {
                if (String.IsNullOrWhiteSpace(q))
                {
                    continue;
                }
                counterQ++;
                string[] Aall = q.Split('|');
                int counterA = -1;


                foreach (var a in Aall)
                {
                    if (String.IsNullOrWhiteSpace(a))
                    {
                        continue;

                    }
                    counterA++;
                    if (counterQ >= 1 && counterA == 0)
                    {
                        filename = counterQ + ".";
                        txt = counterQ + ". " + Q + " " + a;
                    }
                    else
                    {
                        filename = counterQ + "-" + counterA + ".";
                        txt = Convert.ToString((9 + counterA), 16) + " " + O + " " + a;
                    }

                    // MessageBox.Show(a+"/  "+counterQ + "--"+counterA+"\r"+filename);

                    var client = new RestClient("https://texttospeech.googleapis.com/v1beta1/text:synthesize?key=" + key);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    var prm = "{\"input\":{\"text\":\"" + txt + "\"},\"voice\":{\"languageCode\":\"" + SelectedLang + "\",\"name\":\"" + SelectedLang + "-Wavenet-" + Speecher + "\"}," +
                        " \"audioConfig\":{\"audioEncoding\":\"MP3\",\"pitch\":\"1.00\",\"speakingRate\":\"1.0\"}}";
                    request.AddParameter("text/plain", prm, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);

                    dynamic content = JsonConvert.DeserializeObject(response.Content);
                    string type = content.audioContent;
                    byte[] binaryData = Convert.FromBase64String(type);

                    var path3 = TempDir + filename + "mp3";
                    File.WriteAllBytes(path3, binaryData);

                    string pathw = TempDir + filename + "wav";
                    using (var reader = new Mp3FileReader(path3))
                    {
                        var newFormat = new WaveFormat(16000, 8, 1);
                        using (var conversionStream = new WaveFormatConversionStream(newFormat, reader))
                        {
                            WaveFileWriter.CreateWaveFile(pathw, conversionStream);
                        }
                    }

                    File.Delete(path3);

                    if (LivePlay.Checked == true)
                    {
                        SoundPlayer simpleSound = new SoundPlayer(pathw);
                        simpleSound.PlaySync();
                    }


                }

            }
            MessageBox.Show("Seslendirme Başarıyla Tamamlandı!");
            Save_btn.Enabled = true;

        }/*
   */
        private void Save_btn_Click(object sender, EventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            WinForms.DialogResult result = folderDialog.ShowDialog();
            string TempDir = System.IO.Path.GetTempPath() + "seslendirici\\";

            if (result == WinForms.DialogResult.OK)
            {
                String NewPath = folderDialog.SelectedPath + "\\Seslendirici" + DateTime.Now.ToString("_dd-MM-yy_hh-mm-ss") + "\\";

                if (Directory.Exists(TempDir))
                {
                    System.IO.Directory.Move(TempDir, NewPath);
                }
                else
                {
                    MessageBox.Show("Dosyalar Oluşturulmamış");
                }
                MessageBox.Show("Dosyalar " + NewPath + " Konmuna Kopyalandı");
                Save_btn.Enabled = false;


            }
        }

        private void Info_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soruların başına / işareti koyunuz ve altına | işareti ile başlayan şıklarını yazın seslendire tıkladıktan sonra kaydet butonu ile kaydetin. Varsayılan dil türkçe seslendirmen B'dir.");
        }
    }
}
