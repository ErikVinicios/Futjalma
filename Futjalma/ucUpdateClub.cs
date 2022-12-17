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
    public partial class ucUpdateClub : UserControl
    {
        Club club = new Club();
        public ucUpdateClub()
        {
            InitializeComponent();
            dtpFoundation.MaxDate = DateTime.Today;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbSearchName.AutoCompleteCustomSource.AddRange(
                    entities.Clube.Select(c => c.Nome).ToArray());
            }
        }

        private void close()
        {
            this.Parent.Controls.Remove(this);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void tbSearchName_TextChanged(object sender, EventArgs e)
        {
            pbShield.Image = null;
            btChooseImage.Enabled = false;
            openFileDialog1.FileName = null;
            tbName.Text = null;
            tbName.Enabled = false;
            dtpFoundation.Enabled = false;
            btUpdate.Enabled = false;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var clube = entities.Clube.FirstOrDefault(c => c.Nome == tbSearchName.Text);
                if (clube == null)
                    return;
                btUpdate.Enabled = true;
                btChooseImage.Enabled = true;
                var img = clube.Escudo;
                club.Shield = img;
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbShield.Image = Image.FromStream(ms);
                }
                tbName.Enabled = true;
                tbName.Text = clube.Nome;
                dtpFoundation.Enabled = true;
                dtpFoundation.Value = clube.Fundacao;
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32 && e.KeyChar != 45)
                e.Handled = true;
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
                        club.Shield = ms.GetBuffer();
                    }
                    pbShield.Image = img;
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

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (tbName.Text != tbSearchName.Text)
            {
                if (club.NameIsValid(tbName.Text) == false)
                    return;
            }
            else { club.Name = tbName.Text; }
            club.Foundation = dtpFoundation.Value;
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var clube = entities.Clube.First(j => j.Nome == tbSearchName.Text);
                    clube.Escudo = club.Shield;
                    clube.Nome = club.Name;
                    clube.Fundacao = club.Foundation;
                    entities.SaveChanges();
                }
                MessageBox.Show("Club updated successfully! ",
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
