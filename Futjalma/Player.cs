using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public class Player
    {
        private byte[] picture;
        private string name;
        private DateTime birthDate;

        public byte[] Picture
        {
            get => picture;
            set
            {
                if (value == null)
                {
                    picture = null;
                    return;
                }
                picture = value;
            }
        }
        public string Name 
        { 
            get => name;
            set 
            {
                if (value.Trim().Length == 0)
                {
                    name = null;
                    return;
                }
                name = value; 
            } 
        }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public bool NameIsValid(string name)
        {
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var date = entities.Jogador.FirstOrDefault(j => j.Nome == name);
                if (date == null)
                {
                    Name = name;
                    return true;
                }
                MessageBox.Show("Name in use",
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
