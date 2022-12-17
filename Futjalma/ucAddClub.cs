using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public partial class ucAddClub : UserControl
    {
        Club club = new Club();
        public ucAddClub()
        {
            InitializeComponent();
            dtpFoundation.Value = DateTime.Today;
            dtpFoundation.MaxDate = DateTime.Today;
        }

        private void close()
        {
            this.Parent.Controls.Remove(this);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            close();
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32 && e.KeyChar != 45)
                e.Handled = true;
        }

        private void btChooseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var img = Image.FromFile(openFileDialog1.FileName);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, ImageFormat.Jpeg);
                        club.Shield = ms.GetBuffer();
                    }
                    pbShield.Image = img;
                }
                catch
                {
                    MessageBox.Show("Invalid file. Please, choose another image.", 
                        "ERROR", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (club.NameIsValid(tbName.Text) == false)
                return;
            club.Foundation = dtpFoundation.Value;

            try
            {
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    Clube clube = new Clube();
                    clube.Escudo = club.Shield;
                    clube.Nome = club.Name;
                    clube.Fundacao = club.Foundation;

                    entities.Clube.Add(clube);
                    entities.SaveChanges();
                }
                MessageBox.Show("Club successfully added! ",
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
