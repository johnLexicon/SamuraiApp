using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
    public class Samurai
    {

        public Samurai()
        {
            Quotes = new List<Quote>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SwordLength { get; set; }
        public List<Quote> Quotes { get; set; }
        public List<SamuraiBattle> SamuraiBattles { get; set; }
        public SecretIdentity SecretIdentity { get; set; }

        public List<Battle> GetBattles()
        {
            List<Battle> battles = new List<Battle>();
            foreach (var join in SamuraiBattles)
            {
                battles.Add(join.Battle);
            }

            return battles;
        }
    }
}
