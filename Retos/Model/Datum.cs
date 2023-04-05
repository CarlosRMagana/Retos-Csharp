using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retos.Model
{
    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int level { get; set; }
        public string race { get; set; }
        public string attribute { get; set; }
        public Card_Set[] card_sets { get; set; }
        public Card_Image[] card_images { get; set; }
        public Card_Price[] card_prices { get; set; }
    }
}
