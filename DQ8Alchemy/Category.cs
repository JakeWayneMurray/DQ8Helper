using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8Alchemy
{
    public class Category
    {
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }

        public Category(string name)
        {
            Name = name;
            Recipes = new List<Recipe>();
        }
        [JsonConstructor]
        public Category(string name, List<Recipe> list)
        {
            this.Name = name;
            this.Recipes = list;
        }
    }
}
