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
    public partial class ucListSubscription : UserControl
    {
        public ucListSubscription()
        {
            InitializeComponent();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbChampionship.AutoCompleteCustomSource.AddRange(
                    entities.Campeonato.Select(c => c.Nome).ToArray());
                dataGridView1.DataSource = (from cl in entities.Clube
                                            join i in entities.Inscricao on cl.ID equals i.ClubeID
                                            join ca in entities.Campeonato on i.CampeonatoID equals ca.ID
                                            orderby ca.Nome, cl.Nome
                                            select new
                                            {
                                                Campeonato = ca.Nome,
                                                Clube = cl.Nome
                                            }).ToList();
            }
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void tbChampionship_TextChanged(object sender, EventArgs e)
        {
            pbLogo.Image = null;
            dataGridView1.DataSource = null;

            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var img = entities.Campeonato.Where(c => c.Nome == tbChampionship.Text).Select(c => c.Logo).FirstOrDefault();
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbLogo.Image = Image.FromStream(ms);
                }

                if (tbChampionship.Text.Trim().Length == 0)
                {
                    dataGridView1.DataSource = (from cl in entities.Clube
                                                join i in entities.Inscricao on cl.ID equals i.ClubeID
                                                join ca in entities.Campeonato on i.CampeonatoID equals ca.ID
                                                orderby ca.Nome, cl.Nome
                                                select new
                                                {
                                                    Campeonato = ca.Nome,
                                                    Clube = cl.Nome
                                                }).ToList();
                    return;
                }
                dataGridView1.DataSource = (from cl in entities.Clube
                                            join i in entities.Inscricao on cl.ID equals i.ClubeID
                                            join ca in entities.Campeonato on i.CampeonatoID equals ca.ID
                                            where ca.Nome == tbChampionship.Text
                                            orderby cl.Nome
                                            select new
                                            {
                                                Campeonato = ca.Nome,
                                                Clube = cl.Nome
                                            }).ToList();
            }
        }
    }
}
