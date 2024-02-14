using System;
using System.Diagnostics;
using System.IO;
using Ionic.Zip;
using System.Management;
using System.Net;
using System.Windows.Forms;
using System.Threading.Tasks;
using Loader.CustomFont;
using System.Drawing;

namespace Loader
{
    public partial class Authorize : Form
    {

        public Authorize()
        {
            InitializeComponent();

            FontFamily customFontFamily = FontManager.GetFont();
            if (customFontFamily != null)
            {
                foreach (Control c in this.Controls)
                {
                    Font oldFont = c.Font;
                    c.Font = new Font(customFontFamily, oldFont.Size, oldFont.Style);
                }
            }
        }
        private async void Authorize_Load(object sender, EventArgs e)
        {

        }


        private void _authorizeConfirm_Click(object sender, EventArgs e)
        {

                new BSFileOpened().Show(); //new AdForm().Show();
                this.Hide();
           
        }

        private void _appExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
