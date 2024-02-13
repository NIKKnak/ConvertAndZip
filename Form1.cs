using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ConvertAndZip
{
    public partial class ConvertAndZip : Form
    {
        public ConvertAndZip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenEndRear openEndRear = new OpenEndRear();
            openEndRear.Start();

            textBox2.Text = $"Программа сканирует папку.";

        }

    }
}
