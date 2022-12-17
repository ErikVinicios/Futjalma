using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Xml.Linq;

namespace Futjalma
{
    public class Championship
    {
        private byte[] logo;
        private string name;
        private DateTime startDate;
        private DateTime endDate;
        private decimal award;

        public byte[] Logo
        {
            get => logo;
            set
            {
                if (value == null)
                    return;
                logo = value;
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
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public string Award 
        {
            get => award.ToString();
            set 
            {
                if (value.Trim().Length == 0)
                    return;
                award = decimal.Parse(value.Replace(".", "")); 
            } 
        }

        public bool NameIsValid(string name)
        {
            using (FutjalmaEntities entities = new FutjalmaEntities())
            {
                var data = entities.Campeonato.FirstOrDefault(c => c.Nome == name);
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
