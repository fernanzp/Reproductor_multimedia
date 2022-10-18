using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reproductor_multimedia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lb_lista_archivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = lb_lista_archivos.SelectedItem as MediaFile;
            if(file != null)
            {
                mpMediaPlayer.URL = file.Path;
                mpMediaPlayer.Ctlcontrols.play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv" })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> file = new List<MediaFile>();
                    foreach(string FileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(FileName);
                        file.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), Path = fi.FullName });
                    }
                    lb_lista_archivos.DataSource = file;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lb_lista_archivos.ValueMember = "Path";
            lb_lista_archivos.DisplayMember = "FileName";
        }
    }
}
