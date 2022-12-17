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
    public partial class ucListHiring : UserControl
    {
        public ucListHiring()
        {
            InitializeComponent();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbClub.AutoCompleteCustomSource.AddRange(
                    entities.Clube.Select(c => c.Nome).ToArray());
                dataGridView1.DataSource = (from cl in entities.Clube
                                            join co in entities.Contratacao on cl.ID equals co.ClubeID
                                            join jo in entities.Jogador on co.JogadorID equals jo.ID
                                            orderby co.Fechamento descending
                                            select new
                                            {
                                                Clube = cl.Nome,
                                                Jogador = jo.Nome,
                                                Camisa = co.Camisa,
                                                Fechamento = co.Fechamento
                                            }).ToList();
            }
        }

        private void tbClub_TextChanged(object sender, EventArgs e)
        {
            pbShield.Image = null;

            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                if (tbClub.Text.Trim().Length == 0)
                {
                    dataGridView1.DataSource = (from cl in entities.Clube
                                                join co in entities.Contratacao on cl.ID equals co.ClubeID
                                                join jo in entities.Jogador on co.JogadorID equals jo.ID
                                                orderby co.Fechamento descending
                                                select new
                                                {
                                                    Clube = cl.Nome,
                                                    Jogador = jo.Nome,
                                                    Camisa = co.Camisa,
                                                    Fechamento = co.Fechamento
                                                }).ToList();
                    return;
                }
                var img = entities.Clube.Where(c => c.Nome == tbClub.Text).Select(c => c.Escudo).FirstOrDefault();
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbShield.Image = Image.FromStream(ms);
                }

                dataGridView1.DataSource = (from cl in entities.Clube
                                            join co in entities.Contratacao on cl.ID equals co.ClubeID
                                            join jo in entities.Jogador on co.JogadorID equals jo.ID
                                            where cl.Nome == tbClub.Text
                                            orderby co.Fechamento descending
                                            select new
                                            {
                                                Clube = cl.Nome,
                                                Jogador = jo.Nome,
                                                Camisa = co.Camisa,
                                                Fechamento = co.Fechamento
                                            }).ToList();
            }
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
