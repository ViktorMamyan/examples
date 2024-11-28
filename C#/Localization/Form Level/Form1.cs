using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Localization
{
    public partial class Form1 : Form
    {

        public void Reset()
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }

        public static void ChangeCulture(CultureInfo newCulture)
        {
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            CultureInfo.DefaultThreadCurrentCulture = newCulture;
            CultureInfo.DefaultThreadCurrentUICulture = newCulture;
        }

        public Form1()
        {
            InitializeComponent();

            ChangeCulture(new CultureInfo("hy-AM"));
            Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeCulture(new CultureInfo("en-US"));
            Reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeCulture(new CultureInfo("hy-AM"));
            Reset();
        }
    }
}