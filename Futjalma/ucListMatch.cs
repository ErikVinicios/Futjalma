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
    public partial class ucListMatch : UserControl
    {
        public ucListMatch()
        {
            InitializeComponent();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbChampionship.AutoCompleteCustomSource.AddRange(
                    entities.Campeonato.Select(c => c.Nome).ToArray());
            }
        }

        private void tbChampionship_TextChanged(object sender, EventArgs e)
        {
            pbLogo.Image = null;
            tbMatch.Text = null;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var img = entities.Campeonato.Where(c => c.Nome == tbChampionship.Text).Select(c => c.Logo).FirstOrDefault();
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbLogo.Image = Image.FromStream(ms);
                }

                var data = (from cl1 in entities.Clube
                            join pa in entities.Partida on cl1.ID equals pa.Clube1ID
                            join cl2 in entities.Clube on pa.Clube2ID equals cl2.ID
                            join ca in entities.Campeonato on pa.CampeonatoID equals ca.ID
                            where ca.Nome == tbChampionship.Text
                            select cl1.Nome + " X " + cl2.Nome + " - " + pa.ID).ToArray();

                tbMatch.AutoCompleteCustomSource.AddRange(data);
            }
        }

        private void tbMatch_TextChanged(object sender, EventArgs e)
        {
            pbShield1.Image = null;
            pbShield2.Image = null;
            tbClub1.Text = "Club 1";
            tbClub2.Text = "Club 2";
            tbScoreboard1.Text = "00";
            tbScoreboard2.Text = "00";
            try
            {
                string[] separator = tbMatch.Text.Split('X','-');
                string club1 = separator[0].Trim();
                string club2 = separator[1].Trim();
                int id = int.Parse(separator[2].Trim());
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var img = entities.Clube.Where(c => c.Nome == club1).Select(c => c.Escudo).FirstOrDefault();
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pbShield1.Image = Image.FromStream(ms);
                    }

                    img = entities.Clube.Where(c => c.Nome == club2).Select(c => c.Escudo).FirstOrDefault();
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pbShield2.Image = Image.FromStream(ms);
                    }

                    tbScoreboard1.Text = entities.Partida.Where(p => p.Clube.Nome == club1 && p.Clube1.Nome == club2 && p.ID == id)
                        .Select(p => p.Placar1.ToString()).FirstOrDefault();

                    tbScoreboard2.Text = entities.Partida.Where(p => p.Clube.Nome == club1 && p.Clube1.Nome == club2 && p.ID == id)
                        .Select(p => p.Placar2.ToString()).FirstOrDefault();

                    tbClub1.Text = club1;
                    tbClub2.Text = club2;
                }
            }
            catch { return; }
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
