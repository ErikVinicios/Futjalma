using Microsoft.Win32;
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
    public partial class ucAddPlayer : UserControl
    {
        Player player = new Player();
        public ucAddPlayer()
        {
            InitializeComponent();
            DateTime limit = new DateTime(DateTime.Now.Year - 16, DateTime.Now.Month, DateTime.Now.Day);
            dtpBirthDate.MaxDate = limit;
        }

        private void close()
        {
            this.Parent.Controls.Remove(this);
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
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

        private void btSave_Click(object sender, EventArgs e)
        {
            if (player.NameIsValid(tbName.Text) == false)
                return;
            player.BirthDate = dtpBirthDate.Value;
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    Jogador jogador = new Jogador();
                    jogador.Foto = player.Picture;
                    jogador.Nome = player.Name;
                    jogador.DataNascimento = player.BirthDate;

                    entities.Jogador.Add(jogador);
                    entities.SaveChanges();
                }
                MessageBox.Show("Player successfully added! ", 
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
