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
    public partial class ucListPlayer : UserControl
    {
        public ucListPlayer()
        {
            InitializeComponent();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbPlayer.AutoCompleteCustomSource.AddRange(
                    entities.Jogador.Select(j => j.Nome).ToArray());
            }
        }

        private void tbPlayer_TextChanged(object sender, EventArgs e)
        {
            pbPicture.Image = null;
            pbShield.Image = null;
            tbNumber.Text = null;
            using(FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbNumber.Text = (from jo in entities.Jogador
                                 join co in entities.Contratacao on jo.ID equals co.JogadorID
                                 join cl in entities.Clube on co.ClubeID equals cl.ID
                                 where jo.Nome == tbPlayer.Text
                                 orderby co.Fechamento descending
                                 select co.Camisa.ToString()).FirstOrDefault();
                var picture = entities.Jogador.Where(j => j.Nome == tbPlayer.Text).Select(j => j.Foto).FirstOrDefault();
                var logo = (from jo in entities.Jogador
                            join co in entities.Contratacao on jo.ID equals co.JogadorID
                            join cl in entities.Clube on co.ClubeID equals cl.ID
                            where jo.Nome == tbPlayer.Text
                            orderby co.Fechamento descending
                            select cl.Escudo).FirstOrDefault();
                if (picture != null)
                {
                    MemoryStream ms = new MemoryStream(picture);
                    pbPicture.Image = Image.FromStream(ms);
                }
                if (logo != null)
                {
                    MemoryStream ms = new MemoryStream(logo);
                    pbShield.Image = Image.FromStream(ms);
                }
            }
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
