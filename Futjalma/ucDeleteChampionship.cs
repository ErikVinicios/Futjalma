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
    public partial class ucDeleteChampionship : UserControl
    {
        public ucDeleteChampionship()
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

        private void btCalcel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void tbSearchName_TextChanged(object sender, EventArgs e)
        {
            pbLogo.Image = null;
            tbName.Text = null;
            tbAward.Text = null;
            btDelete.Enabled = false;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var campeonato = entities.Campeonato.FirstOrDefault(c => c.Nome == tbSearchName.Text);
                if (campeonato == null)
                    return;
                btDelete.Enabled = true;
                var img = campeonato.Logo;
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbLogo.Image = Image.FromStream(ms);
                }
                tbName.Text = campeonato.Nome;
                tbAward.Text = campeonato.Premiacao.ToString("N2");
                dtpStartDate.Value = campeonato.Inicio;
                dtpEndDate.Value = campeonato.Fim;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var campeonato = entities.Campeonato.FirstOrDefault(c => c.Nome == tbSearchName.Text);
                    if (campeonato != null)
                        entities.Campeonato.Remove(campeonato);
                    entities.SaveChanges();
                }
                MessageBox.Show("Championship deleted successfully! ",
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
