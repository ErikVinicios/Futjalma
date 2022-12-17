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
    public partial class ucUpdatePlayer : UserControl
    {
        Player player = new Player();
        public ucUpdatePlayer()
        {
            InitializeComponent();
            DateTime limit = new DateTime(DateTime.Now.Year - 16, DateTime.Now.Month, DateTime.Now.Day);
            dtpBirthDate.MaxDate = limit;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbSearchName.AutoCompleteCustomSource.AddRange(
                    entities.Jogador.Select(j => j.Nome).ToArray());
            }
        }

        private void close()
        {
            this.Parent.Controls.Remove(this);
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }

        private void tbSearchName_TextChanged(object sender, EventArgs e)
        {
            pbPicture.Image = null;
            btChooseImage.Enabled = false;
            openFileDialog1.FileName = null;
            tbName.Text = null;
            tbName.Enabled = false;
            dtpBirthDate.Enabled = false;
            btUpdate.Enabled = false;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var jogador = entities.Jogador.FirstOrDefault(j => j.Nome == tbSearchName.Text);
                if (jogador == null)
                    return;
                btUpdate.Enabled = true;
                btChooseImage.Enabled = true;
                var img = jogador.Foto;
                player.Picture = img;
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbPicture.Image = Image.FromStream(ms);
                }
                tbName.Enabled = true;
                tbName.Text = jogador.Nome;
                dtpBirthDate.Enabled = true;
                dtpBirthDate.Value = jogador.DataNascimento;
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
                        player.Picture = ms.GetBuffer();
                    }
                    pbPicture.Image = img;
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
                if (player.NameIsValid(tbName.Text) == false)
                    return;
            }
            else { player.Name = tbName.Text; }
            player.BirthDate = dtpBirthDate.Value;
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var jogador = entities.Jogador.First(j => j.Nome == tbSearchName.Text);
                    jogador.Foto = player.Picture;
                    jogador.Nome = player.Name;
                    jogador.DataNascimento = player.BirthDate;
                    entities.SaveChanges();
                }
                MessageBox.Show("Player updated successfully! ",
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
