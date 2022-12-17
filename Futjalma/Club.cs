using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public class Club
    {
        private byte[] shield;
        private string name;
        private DateTime foundation;

        public byte[] Shield
        {
            get => shield;
            set
            {
                if (value == null)
                    return;
                shield = value;
            }
        }
        public string Name 
        {
            get => name;
            set 
            {
                if (value.Trim().Length == 0)
                    return;
                name = value; 
            } 
        }
        public DateTime Foundation { get => foundation; set => foundation = value; }

        public bool NameIsValid(string name)
        {
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var data = entities.Clube.FirstOrDefault(c => c.Nome == name);
                if (data == null)
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
