using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public partial class ucListChampionship : UserControl
    {
        public ucListChampionship()
        {
            InitializeComponent();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbChampionship.AutoCompleteCustomSource.AddRange(
                    entities.Campeonato.Select(c => c.Nome).ToArray());
                dataGridView1.DataSource = (from ca in entities.Campeonato
                                            join ic in entities.InfoCampeonato on ca.ID equals ic.CampeonatoID
                                            join cl in entities.Clube on ic.ClubeID equals cl.ID
                                            orderby ca.Nome, ic.Qnt_Pontos descending, ic.Qnt_Vitorias descending, ic.Qnt_Gols descending
                                            select new
                                            {
                                                Campeonato = ca.Nome,
                                                Clube = cl.Nome,
                                                Gols = ic.Qnt_Gols,
                                                Vitórias = ic.Qnt_Vitorias,
                                                Empates = ic.Qnt_Empates,
                                                Derrotas = ic.Qnt_Derrotas,
                                                Pontos = ic.Qnt_Pontos
                                            }).ToList();
            }
        }

        private void tbChampionship_TextChanged(object sender, EventArgs e)
        {
            pbLogo.Image = null;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                if (tbChampionship.Text.Trim().Length == 0)
                {
                    dataGridView1.DataSource = (from ca in entities.Campeonato
                                                join ic in entities.InfoCampeonato on ca.ID equals ic.CampeonatoID
                                                join cl in entities.Clube on ic.ClubeID equals cl.ID
                                                orderby ca.Nome, ic.Qnt_Pontos descending, ic.Qnt_Vitorias descending, ic.Qnt_Gols descending
                                                select new
                                                {
                                                    Campeonato = ca.Nome,
                                                    Clube = cl.Nome,
                                                    Gols = ic.Qnt_Gols,
                                                    Vitórias = ic.Qnt_Vitorias,
                                                    Empates = ic.Qnt_Empates,
                                                    Derrotas = ic.Qnt_Derrotas,
                                                    Pontos = ic.Qnt_Pontos
                                                }).ToList();
                    return;
                }
                var img = entities.Campeonato.Where(c => c.Nome == tbChampionship.Text).Select(c => c.Logo).FirstOrDefault();
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbLogo.Image = Image.FromStream(ms);
                }

                dataGridView1.DataSource = (from ca in entities.Campeonato
                                            join ic in entities.InfoCampeonato on ca.ID equals ic.CampeonatoID
                                            join cl in entities.Clube on ic.ClubeID equals cl.ID
                                            where ca.Nome == tbChampionship.Text
                                            orderby ca.Nome, ic.Qnt_Pontos descending, ic.Qnt_Vitorias descending, ic.Qnt_Gols descending
                                            select new
                                            {
                                                Campeonato = ca.Nome,
                                                Clube = cl.Nome,
                                                Gols = ic.Qnt_Gols,
                                                Vitórias = ic.Qnt_Vitorias,
                                                Empates = ic.Qnt_Empates,
                                                Derrotas = ic.Qnt_Derrotas,
                                                Pontos = ic.Qnt_Pontos
                                            }).ToList();
            }
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
