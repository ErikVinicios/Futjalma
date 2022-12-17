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
    public partial class ucDeleteClub : UserControl
    {
        public ucDeleteClub()
        {
            InitializeComponent();
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
            tbName.Text = null;
            btDelete.Enabled = false;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var clube = entities.Clube.FirstOrDefault(c => c.Nome == tbSearchName.Text);
                if (clube == null)
                    return;
                btDelete.Enabled = true;
                var img = clube.Escudo;
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbShield.Image = Image.FromStream(ms);
                }
                tbName.Text = clube.Nome;
                dtpFoundation.Value = clube.Fundacao;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var contratacao = entities.Contratacao.FirstOrDefault(c => c.Clube.Nome == tbSearchName.Text);
                    if (contratacao != null)
                        entities.Contratacao.Remove(contratacao);
                    var infoCampeonato = entities.InfoCampeonato.FirstOrDefault(i => i.Clube.Nome == tbSearchName.Text);
                    if (infoCampeonato != null)
                        entities.InfoCampeonato.Remove(infoCampeonato);
                    var inscricao = entities.Inscricao.FirstOrDefault(i => i.Clube.Nome == tbSearchName.Text);
                    if (inscricao != null)
                        entities.Inscricao.Remove(inscricao);
                    var partida1 = entities.Partida.FirstOrDefault(p => p.Clube.Nome == tbSearchName.Text);
                    if (partida1 != null)
                        entities.Partida.Remove(partida1);
                    var partida2 = entities.Partida.FirstOrDefault(p => p.Clube1.Nome == tbSearchName.Text);
                    if (partida2 != null)
                        entities.Partida.Remove(partida2);
                    var clube = entities.Clube.FirstOrDefault(c => c.Nome == tbSearchName.Text);
                    if (clube != null)
                        entities.Clube.Remove(clube);
                    entities.SaveChanges();
                }
                MessageBox.Show("Club deleted successfully! ",
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
