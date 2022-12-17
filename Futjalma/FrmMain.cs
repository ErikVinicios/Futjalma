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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            if (pnMain.Controls.Count > 0)
                pnMain.Controls.Clear();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
            ucAddPlayer addPlayer = new ucAddPlayer();
            addPlayer.Dock = DockStyle.Fill;
            pnMain.Controls.Add(addPlayer);
            addPlayer.BringToFront();
        }
        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
            ucListPlayer listPlayer = new ucListPlayer();
            listPlayer.Dock = DockStyle.Fill;
            pnMain.Controls.Add(listPlayer);
            listPlayer.BringToFront();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Refresh();
            ucAddClub addClub = new ucAddClub();
            addClub.Dock = DockStyle.Fill;
            pnMain.Controls.Add(addClub);
            addClub.BringToFront();
        }

        private void adicionarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Refresh();
            ucaddHiring addHiring = new ucaddHiring();
            addHiring.Dock = DockStyle.Fill;
            pnMain.Controls.Add(addHiring);
            addHiring.BringToFront();
        }

        private void adicionarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Refresh();
            ucAddChampionship addChampionship = new ucAddChampionship();
            addChampionship.Dock = DockStyle.Fill;
            pnMain.Controls.Add(addChampionship);
            addChampionship.BringToFront();
        }

        private void adicionarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Refresh();
            ucAddSubscription addSubscription = new ucAddSubscription();
            addSubscription.Dock = DockStyle.Fill;
            pnMain.Controls.Add(addSubscription);
            addSubscription.BringToFront();
        }

        private void adicionarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Refresh();
            ucAddMatch addMatch = new ucAddMatch();
            addMatch.Dock = DockStyle.Fill;
            pnMain.Controls.Add(addMatch);
            addMatch.BringToFront();
        }

        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Refresh();
            ucListChampionship listChampionship = new ucListChampionship();
            listChampionship.Dock = DockStyle.Fill;
            pnMain.Controls.Add(listChampionship);
            listChampionship.BringToFront();
        }

        private void listarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Refresh();
            ucListMatch listmatch = new ucListMatch();
            listmatch.Dock = DockStyle.Fill;
            pnMain.Controls.Add(listmatch);
            listmatch.BringToFront();
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Refresh();
            ucListClub listClub = new ucListClub();
            listClub.Dock = DockStyle.Fill;
            pnMain.Controls.Add(listClub);
            listClub.BringToFront();
        }

        private void listarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Refresh();
            ucListHiring listHiring = new ucListHiring();
            listHiring.Dock = DockStyle.Fill;
            pnMain.Controls.Add(listHiring);
            listHiring.BringToFront();
        }

        private void listarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Refresh();
            ucListSubscription listSubscription = new ucListSubscription();
            listSubscription.Dock = DockStyle.Fill;
            pnMain.Controls.Add(listSubscription);
            listSubscription.BringToFront();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
            ucUpdatePlayer updatePlayer = new ucUpdatePlayer();
            updatePlayer.Dock = DockStyle.Fill;
            pnMain.Controls.Add(updatePlayer);
            updatePlayer.BringToFront();
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Refresh();
            ucUpdateChampionship updateChampionship = new ucUpdateChampionship();
            updateChampionship.Dock = DockStyle.Fill;
            pnMain.Controls.Add(updateChampionship);
            updateChampionship.BringToFront();
        }

        private void updateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Refresh();
            ucUpdateClub updateClub = new ucUpdateClub();
            updateClub.Dock = DockStyle.Fill;
            pnMain.Controls.Add(updateClub);
            updateClub.BringToFront();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
            ucDeletePlayer deletePlayer = new ucDeletePlayer();
            deletePlayer.Dock = DockStyle.Fill;
            pnMain.Controls.Add(deletePlayer);
            deletePlayer.BringToFront();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Refresh();
            ucDeleteClub deleteClub = new ucDeleteClub();
            deleteClub.Dock = DockStyle.Fill;
            pnMain.Controls.Add(deleteClub);
            deleteClub.BringToFront();
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Refresh();
            ucDeleteChampionship deleteChampionship = new ucDeleteChampionship();
            deleteChampionship.Dock = DockStyle.Fill;
            pnMain.Controls.Add(deleteChampionship);
            deleteChampionship.BringToFront();
        }
    }
}
