using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompactExifLib;

namespace ExifReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String filePath;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectImage = new OpenFileDialog()
            {
                DefaultExt = "jpg",
                Filter = "JPEG Files|*.jpg",
                FilterIndex = 2
            };
            
            if (selectImage.ShowDialog() == DialogResult.OK)
            {
                filePath = selectImage.FileName;
            }
           
            
            Image img = Image.FromFile(selectImage.FileName);
            pictureBox1.Image = img;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            ExifData TestExif;
            DateTime DateTaken;
            
            TestExif = new ExifData(filePath);
            TestExif.GetTagValue(ExifTag.DateTimeOriginal, out DateTaken);
            TestExif.GetTagValue(ExifTag.Make, out string make, StrCoding.Utf8);
            TestExif.GetTagValue(ExifTag.Model, out string model, StrCoding.Utf8);
            TestExif.GetTagValue(ExifTag.Orientation, out int orientation);
            MessageBox.Show("Date: " + DateTaken + 
                                "\nMake: " + make + 
                                "\nModel: " + model + 
                                "\nOrientation: " + orientation);
        }
    }
}