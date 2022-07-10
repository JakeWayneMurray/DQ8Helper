using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8Alchemy
{
    public class Monster
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string CoinType { get; set; }
        public string HP { get; set; }
        public string MP { get; set; }
        public string ATK { get; set; }
        public string DEF { get; set; }
        public string AGL { get; set; }
        public string Gold { get; set; }
        public string EXP { get; set; }
        public string Regions { get; set; }
        public string Condition { get; set; }
        public string Teams { get; set; }
        public string Perks { get; set; }
        public string Link { get; set; }

        [JsonConstructor]
        public Monster (string name, string species, string cointype, string hp, string mp, string atk,
            string def, string agl, string gold, string experience, string regions, string conditions, string perks, string teams, string link)
        {
            this.Name = name;
            this.Species = species;
            this.CoinType= cointype;
            this.HP = hp;
            this.MP = mp;
            this.ATK = atk;
            this.DEF = def;
            this.AGL = agl;
            this.Gold = gold;
            this.EXP = experience;
            this.Regions = regions;
            this.Condition=conditions;
            this.Teams = teams;
            this.Perks = perks;
            this.Link = link;

        }

    }
}
