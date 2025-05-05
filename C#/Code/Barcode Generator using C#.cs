Barcode Generator using C#

Install-Package ZXing.Net


using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace BarcodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Please enter text to generate barcode.");
                return;
            }

            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 300,
                    Height = 100,
                    Margin = 10
                }
            };

            Bitmap bitmap = writer.Write(inputText);
            pictureBox1.Image = bitmap;
        }
    }
}


