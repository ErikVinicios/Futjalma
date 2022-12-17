using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public partial class ucAddSubscription : UserControl
    {
        public ucAddSubscription()
        {
            InitializeComponent();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbChampionship.AutoCompleteCustomSource.AddRange(
                entities.Campeonato.Select(c => c.Nome).ToArray());
            }
        }

        private void close()
        {
            this.Parent.Controls.Remove(this);
        }

        private void tbChampionship_TextChanged(object sender, EventArgs e)
        {
            tbClub.Text = null;
            tbClub.AutoCompleteCustomSource.Clear();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var data = (from cl in entities.Clube
                            join i in entities.Inscricao on cl.ID equals i.ClubeID
                            into _cl from c in _cl.DefaultIfEmpty()
                            join ca in entities.Campeonato on c.CampeonatoID equals ca.ID
                            into _ca from cam in _ca.DefaultIfEmpty()
                            where cam.Nome != tbChampionship.Text || cam.Nome == null
                            select cl.Nome).ToArray();
                tbClub.AutoCompleteCustomSource.AddRange(data);
            }
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Subscription subscription = new Subscription();
            subscription.Club = tbClub.Text;
            subscription.Championship = tbChampionship.Text;
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    Inscricao inscricao = new Inscricao();
                    inscricao.ClubeID = int.Parse(subscription.Club);
                    inscricao.CampeonatoID = int.Parse(subscription.Championship);

                    entities.Inscricao.Add(inscricao);
                    entities.SaveChanges();
                }
                MessageBox.Show("Subscription successfully added! ", 
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
