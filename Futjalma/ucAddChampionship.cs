using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace Futjalma
{
    public partial class ucAddChampionship : UserControl
    {
        Championship championship = new Championship();
        public ucAddChampionship()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today;
            dtpStartDate.MaxDate = DateTime.Today;
            dtpEndDate.MinDate = dtpStartDate.MaxDate;
        }

        private void close()
        {
            this.Parent.Controls.Remove(this);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }

        private void tbAward_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44)
                e.Handled = true;
            else if (e.KeyChar == 44)
            {
                TextBox txt = (TextBox)sender;
                if (txt.Text.Contains(","))
                    e.Handled = true;
            }
        }

        private void tbAward_Leave(object sender, EventArgs e)
        {
            if (tbAward.Text.Trim().Length != 0)
            {
                var num = Convert.ToDecimal(tbAward.Text);
                tbAward.Text = num.ToString("N2");
            }
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void btChooseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var img = Image.FromFile(openFileDialog1.FileName);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, ImageFormat.Jpeg);
                        championship.Logo = ms.GetBuffer();
                    }
                    pbLogo.Image = img;
                }
                catch
                {
                    MessageBox.Show("Invalid file. Please, choose another image.",
                        "ERROR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (championship.NameIsValid(tbName.Text) == false)
                return;
            championship.StartDate = dtpStartDate.Value;
            championship.EndDate = dtpEndDate.Value;
            championship.Award = tbAward.Text;
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    Campeonato campeonato = new Campeonato();
                    campeonato.Logo = championship.Logo;
                    campeonato.Nome = championship.Name;
                    campeonato.Inicio = championship.StartDate;
                    campeonato.Fim = championship.EndDate;
                    campeonato.Premiacao = decimal.Parse(championship.Award);

                    entities.Campeonato.Add(campeonato);
                    entities.SaveChanges();
                }
                MessageBox.Show("Championship successfully added! ",
                    "CONGRATULATION",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                close();
            }
            catch
            {
                MessageBox.Show("there was some error",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
