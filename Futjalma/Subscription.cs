using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futjalma
{
    public class Subscription
    {
        private int? clubID;
        private int? championshipID;

        public string Club
        {
            get => clubID.ToString();
            set
            {
                if (value == null)
                {
                    clubID = null;
                    return;
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
        public string Championship
        {
            get => championshipID.ToString();
            set
            {
                if (value == null)
                {
                    championshipID = null;
                    return;
                }
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var data = entities.Campeonato.Where(c => c.Nome == value).Select(c => c.ID).FirstOrDefault();
                    if (data == 0)
                        return;
                    championshipID = data;
                }
            }
        }
    }
}
