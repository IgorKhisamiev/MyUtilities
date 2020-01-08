﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtilites
{
    public partial class MainForm : Form
    {
        int count = 0;
        Random rnd;
        char[] spec_chars = new char[] {'%', '*', ')', '?', '#','$', '^', '&', '~'};
        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа мои утилиты", "О программе ");
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCount.Text = count.ToString();
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCount.Text = count.ToString();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            lblCount.Text = "0";
            count = 0;
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void BtnRandom_Click(object sender, EventArgs e)
        {
            int n;
            n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value) + 1);
            lblRandom.Text = n.ToString();
            if (cbRandonReplay.Checked)
            {
                while (tbRandom.Text.IndexOf(n.ToString()) != -1)
                    n = rnd.Next(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value) + 1);
                tbRandom.AppendText(n + "\n");
            }
            else tbRandom.AppendText(n + "\n");


        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            tbRandom.Clear();
        }

        private void BtnRandomCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRandom.Text);
        }

        private void TsmiInsertDate_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortDateString()+"\n");
        }

        private void TsmiInsertTime_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void TsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotepad.SaveFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Error SAVE", "ERROR");
            }
            
        }

        void LoadNotepad()
        {
            try
            {
                rtbNotepad.LoadFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Error LOAD", "ERROR");
            }
        }


        private void TsmiLoad_Click(object sender, EventArgs e)
        {
            LoadNotepad();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadNotepad();
            clbPassword.SetItemChecked(0, true);
            clbPassword.SetItemChecked(1, true);
        }

        private void BtnCreatePassword_Click(object sender, EventArgs e)
        {
            if (clbPassword.CheckedItems.Count == 0) return;
            string password = "";
            for (int i=0; i<nudPassLenght.Value;i++)
            {
                int n = rnd.Next(0, clbPassword.CheckedItems.Count);
                string s = clbPassword.CheckedItems[n].ToString();
                switch (s)
                {
                    case "Цифры": password += rnd.Next(10).ToString();
                        break;
                    case "ПРОПИСНЫЕ БУКВЫ":
                        password += Convert.ToChar(rnd.Next(65, 88));
                        break;
                    case "строчные буквы":
                        password += Convert.ToChar(rnd.Next(97, 122));
                        break;
                    default:
                        password += spec_chars[rnd.Next(spec_chars.Length)];
                            break;
                }

                tbPassword.Text = password;
                //Clipboard.SetText(password); copy in  bufers
            }
        }

        private void BtnCopyPassword_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbPassword.Text);
        }
    }
}
