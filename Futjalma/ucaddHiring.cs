using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public partial class ucaddHiring : UserControl
    {
        public ucaddHiring()
        {
            InitializeComponent();
            dtpClosure.MaxDate = DateTime.Today;
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                tbClub.AutoCompleteCustomSource.AddRange(
                    entities.Clube.Select(c => c.Nome).ToArray());
            }
        }

        private void close()
        {
            this.Parent.Controls.Remove(this);
        }

        private void tbClub_TextChanged(object sender, EventArgs e)
        {
            tbPlayer.Text = null;
            tbPlayer.AutoCompleteCustomSource.Clear();
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var data = (from jo in entities.Jogador
                            join co in entities.Contratacao on jo.ID equals co.JogadorID
                            into _jo from j in _jo.DefaultIfEmpty()
                            join cl in entities.Clube on j.ClubeID equals cl.ID
                            into _cl from c in _cl.DefaultIfEmpty()
                            where c.Nome != tbClub.Text || c.Nome == null
                            select jo.Nome).ToArray();

                tbPlayer.AutoCompleteCustomSource.AddRange(data);
            }
        }

        private void btCalcel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Hiring hiring = new Hiring();
            hiring.Club = tbClub.Text;
            hiring.Player = tbPlayer.Text;
            hiring.Shirt = nupShirt.Value;
            hiring.Closure = dtpClosure.Value;

            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    Contratacao contratacao = new Contratacao();
                    contratacao.ClubeID = int.Parse(hiring.Club);
                    contratacao.JogadorID = int.Parse(hiring.Player);
                    contratacao.Camisa = (int)hiring.Shirt;
                    contratacao.Fechamento = hiring.Closure;

                    entities.Contratacao.Add(contratacao);
                    entities.SaveChanges();
                }
                MessageBox.Show("Hiring successfully added! ", 
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
