using Loader.CustomFont;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Loader
{
    public partial class BSFileOpened : Form
    {
        public static string _bsFile_HD_Common;
        public static string _bsFile_BluestacksExe;

        public BSFileOpened()
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

        private void _appExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _bsFileOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdBluestacks = new OpenFileDialog())
            {
                MessageBox.Show("Выберите файл Bluestacks.exe");

                if (ofdBluestacks.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetFileName(ofdBluestacks.FileName) == "Bluestacks.exe")
                    {
                        _bsFile_BluestacksExe = ofdBluestacks.FileName;

                        using (OpenFileDialog ofdHDCommon = new OpenFileDialog())
                        {
                            MessageBox.Show("Выберите файл HD-Common.dll");

                            if (ofdHDCommon.ShowDialog() == DialogResult.OK)
                            {
                                if (Path.GetFileName(ofdHDCommon.FileName) == "HD-Common.dll")
                                {
                                    _bsFile_HD_Common = ofdHDCommon.FileName;

                                    if (_bsFile_BluestacksExe != null && _bsFile_HD_Common != null)
                                    {
                                        new BlueStacks().Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Сначала выберите файл Bluestacks.exe и HD-Common.dll");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Выбран неправильный файл. Выберите HD-Common.dll.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Отменено пользователем.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выбран неправильный файл. Выберите Bluestacks.exe.");
                    }
                }
                else
                {
                    MessageBox.Show("Отменено пользователем.");
                }
            }
        }
    }
}
