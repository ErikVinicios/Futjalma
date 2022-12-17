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
    public partial class ucListClub : UserControl
    {
        public ucListClub()
        {
            InitializeComponent();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbClub.AutoCompleteCustomSource.AddRange(
                    entities.Clube.Select(c => c.Nome).ToArray());
            }
        }

        private void showPlayer(int shirt, TextBox tbName, PictureBox pbPhoto)
        {
            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    tbName.Text = (from cl in entities.Clube
                                   join co in entities.Contratacao on cl.ID equals co.ClubeID
                                   join jo in entities.Jogador on co.JogadorID equals jo.ID
                                   where cl.Nome == tbClub.Text && co.Camisa == shirt
                                   orderby co.Fechamento descending
                                   select jo.Nome).FirstOrDefault();

                    var img = (from cl in entities.Clube
                               join co in entities.Contratacao on cl.ID equals co.ClubeID
                               join jo in entities.Jogador on co.JogadorID equals jo.ID
                               where cl.Nome == tbClub.Text && co.Camisa == shirt
                               orderby co.Fechamento descending
                               select jo.Foto).FirstOrDefault();
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pbPhoto.Image = Image.FromStream(ms);
                    }
                }
            }
            catch { return; }
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void tbClub_TextChanged(object sender, EventArgs e)
        {
            pbShield.Image = null;
            pbGoalkeeper.Image = null;
            tbGoalkeeper.Text = null;
            pbRightBack.Image = null;
            tbRightBack.Text = null;
            pbLeftBack.Image = null;
            tbLeftBack.Text = null;
            pbCenterBack1.Image = null;
            tbCenterBack2.Text = null;
            pbCenterBack2.Image = null;
            tbCenterBack2.Text = null;
            pbCenterMidfield1.Image = null;
            tbCenterMidfield1.Text = null;
            pbCenterMidfield2.Image = null;
            tbCenterMidfield2.Text = null;
            pbRightMidfield.Image = null;
            tbRightMidfield.Text = null;
            pbLeftMidfield.Image = null;
            tbLeftMidfield.Text = null;
            pbRightForward.Image = null;
            tbRightForward.Text = null;
            pbLeftForward.Image = null;
            tbLeftForward.Text = null;

            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var img = entities.Clube.Where(c => c.Nome == tbClub.Text).Select(c => c.Escudo).FirstOrDefault();
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbShield.Image = Image.FromStream(ms);
                }
            }

            showPlayer(1, tbGoalkeeper, pbGoalkeeper);
            showPlayer(2, tbCenterBack1, pbCenterBack1);
            showPlayer(3, tbCenterBack2, pbCenterBack2);
            showPlayer(4, tbRightBack, pbRightBack);
            showPlayer(5, tbCenterMidfield1, pbCenterMidfield1);
            showPlayer(6, tbLeftBack, pbLeftBack);
            showPlayer(7, tbRightMidfield, pbRightMidfield);
            showPlayer(8, tbCenterMidfield2, pbCenterMidfield2);
            showPlayer(9, tbLeftMidfield, pbLeftMidfield);
            showPlayer(10, tbRightForward, pbRightForward);
            showPlayer(11, tbLeftForward, pbLeftForward);
        }
    }
}
