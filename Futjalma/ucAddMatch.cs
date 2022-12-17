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
    public partial class ucAddMatch : UserControl
    {
        public ucAddMatch()
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

        private void btCalcel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void tbChampionship_TextChanged(object sender, EventArgs e)
        {
            tbClub1.Text = null;
            tbClub2.Text = null;
            nudScoreboard1.Value = 0;
            nudScoreboard2.Value = 0;
            tbClub1.AutoCompleteCustomSource.Clear();
            tbClub2.AutoCompleteCustomSource.Clear();

            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var data = (from cl in entities.Clube
                            join i in entities.Inscricao on cl.ID equals i.ClubeID
                            join ca in entities.Campeonato on i.CampeonatoID equals ca.ID
                            where ca.Nome == tbChampionship.Text
                            select cl.Nome).ToArray();
                tbClub1.AutoCompleteCustomSource.AddRange(data);
                tbClub2.AutoCompleteCustomSource.AddRange(data);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbClub1.Text == tbClub2.Text)
                return;
            Match match = new Match();
            match.Championship = tbChampionship.Text;
            match.Club1 = tbClub1.Text;
            match.Club2 = tbClub2.Text;
            match.Scoreboard1 = nudScoreboard1.Value;
            match.Scoreboard2 = nudScoreboard2.Value;

            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    Partida partida = new Partida();
                    partida.CampeonatoID = int.Parse(match.Championship);
                    partida.Clube1ID = int.Parse(match.Club1);
                    partida.Clube2ID = int.Parse(match.Club2);
                    partida.Placar1 = (int)match.Scoreboard1;
                    partida.Placar2 = (int)match.Scoreboard2;

                    entities.Partida.Add(partida);
                    entities.SaveChanges();
                }
                MessageBox.Show("Match successfully added! ",
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
