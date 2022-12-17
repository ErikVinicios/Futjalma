using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public partial class ucDeletePlayer : UserControl
    {
        public ucDeletePlayer()
        {
            InitializeComponent();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbSearchName.AutoCompleteCustomSource.AddRange(
                    entities.Jogador.Select(c => c.Nome).ToArray());
            }
        }

        private void close()
        {
            this.Parent.Controls.Remove(this);
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void tbSearchName_TextChanged(object sender, EventArgs e)
        {
            pbPicture.Image = null;
            tbName.Text = null;
            btDelete.Enabled = false;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var jogador = entities.Jogador.FirstOrDefault(j => j.Nome == tbSearchName.Text);
                if (jogador == null)
                    return;
                btDelete.Enabled = true;
                var img = jogador.Foto;
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbPicture.Image = Image.FromStream(ms);
                }
                tbName.Text = jogador.Nome;
                dtpBirthDate.Value = jogador.DataNascimento;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var contratacao = entities.Contratacao.FirstOrDefault(c => c.Jogador.Nome == tbSearchName.Text);
                    if (contratacao != null)
                        entities.Contratacao.Remove(contratacao);
                    var jogador = entities.Jogador.FirstOrDefault(j => j.Nome == tbSearchName.Text);
                    if (jogador != null)
                        entities.Jogador.Remove(jogador);
                    entities.SaveChanges();
                }
                MessageBox.Show("Player deleted successfully! ",
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
