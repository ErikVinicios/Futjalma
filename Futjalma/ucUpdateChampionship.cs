using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public partial class ucUpdateChampionship : UserControl
    {
        Championship championship = new Championship();
        public ucUpdateChampionship()
        {
            InitializeComponent();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbSearchName.AutoCompleteCustomSource.AddRange(
                    entities.Campeonato.Select(c => c.Nome).ToArray());
            }
        }

        private void close()
        {
            this.Parent.Controls.Remove(this);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
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

        private void tbSearchName_TextChanged(object sender, EventArgs e)
        {
            pbLogo.Image = null;
            openFileDialog1.FileName = null;
            btChooseImage.Enabled = false;
            tbName.Text = null;
            tbName.Enabled = false;
            tbAward.Text = null;
            tbAward.Enabled = false;
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            btUpdate.Enabled = false;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var campeonato = entities.Campeonato.FirstOrDefault(c => c.Nome == tbSearchName.Text);
                if (campeonato == null)
                    return;
                btUpdate.Enabled = true;
                btChooseImage.Enabled = true;
                championship.Logo = campeonato.Logo;
                var img = campeonato.Logo;
                championship.Logo = img;
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbLogo.Image = Image.FromStream(ms);
                }
                tbName.Enabled = true;
                tbName.Text = campeonato.Nome;
                tbAward.Enabled = true;
                tbAward.Text = campeonato.Premiacao.ToString("N2");
                dtpStartDate.Enabled = true;
                dtpStartDate.Value = campeonato.Inicio;
                dtpEndDate.Enabled = true;
                dtpEndDate.Value = campeonato.Fim;
            }
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

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (tbName.Text != tbSearchName.Text)
            {
                if (championship.NameIsValid(tbName.Text) == false)
                    return;
            }
            else { championship.Name = tbName.Text; }
            championship.StartDate = dtpStartDate.Value;
            championship.EndDate = dtpEndDate.Value;
            championship.Award = tbAward.Text;
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var campeonato = entities.Campeonato.First(c => c.Nome == tbSearchName.Text);
                    campeonato.Logo = championship.Logo;
                    campeonato.Nome = championship.Name;
                    campeonato.Inicio = championship.StartDate;
                    campeonato.Fim = championship.EndDate;
                    campeonato.Premiacao = decimal.Parse(championship.Award);
                    entities.SaveChanges();
                }
                MessageBox.Show("Championship updated successfully! ",
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
