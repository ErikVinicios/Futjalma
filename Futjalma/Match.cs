using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Futjalma
{
    public class Match
    {
        private int? championshipID;
        private int? club1ID;
        private int? club2ID;
        private int scoreboard1;
        private int scoreboard2;

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
                    var data = entities.Campeonato.Where(p => p.Nome == value).Select(p => p.ID).FirstOrDefault();
                    if (data == 0)
                        return;
                    championshipID = data;
                }
            }
        }
        public string Club1
        {
            get => club1ID.ToString();
            set
            {
                if (value == null)
                {
                    club1ID = null;
                    return;
                }
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var date = entities.Clube.Where(c => c.Nome == value).Select(c => c.ID).FirstOrDefault();
                    if (date == 0)
                        return;
                    club1ID = date;
                }
            }
        }
        public string Club2
        {
            get => club2ID.ToString();
            set
            {
                if (value == null)
                {
                    club2ID = null;
                    return;
                }
                using (FutjalmaEntities entities = new FutjalmaEntities())
                {
                    var date = entities.Clube.Where(c => c.Nome == value).Select(c => c.ID).FirstOrDefault();
                    if (date == 0)
                        return;
                    club2ID = date;
                }
            }
        }
        public decimal Scoreboard1 { get => (decimal)scoreboard1; set => scoreboard1 = (int)value; }
        public decimal Scoreboard2 { get => (decimal)scoreboard2; set => scoreboard2 = (int)value; }
    }
}
