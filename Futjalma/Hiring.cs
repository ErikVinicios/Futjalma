using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public class Hiring
    {
        private int? clubID;
        private int? playerID;
        private int? shirt;
        private DateTime closure;

        public string Club
        {
            get => clubID.ToString();
            set
            {
                if (value == null)
                {
                    clubID = null;
                }
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var data = entities.Clube.Where(c => c.Nome == value).Select(c => c.ID).FirstOrDefault();
                    if (data == 0)
                        return;
                    clubID = data;
                }
            }
        }
        public string Player
        {
            get => playerID.ToString();
            set
            {
                if (value == null)
                {
                    playerID = null;
                    return;
                }
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var data = entities.Jogador.Where(j => j.Nome == value).Select(j => j.ID).FirstOrDefault();
                    if (data == 0)
                        return;
                    playerID = data;
                }
            }
        }
        public decimal Shirt
        {
            get => (decimal)shirt;
            set
            { 
                if (value == 0)
                {
                    shirt = null;
                    return;
                }
                shirt = (int)value; 
            } 
        }
        public DateTime Closure { get => closure; set => closure = value; }
    }
}
