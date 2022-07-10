using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQ8Alchemy
{
    public class Recipe
    {
        public string Name { get; set; }
        public string IngredientOne { get; set; }
        public string IngredientTwo { get; set; }
        public string? IngredientThree {get;set;}

        [JsonConstructor]
        public Recipe(string recName, string ignOne,string ingTwo, string? ingThree)
        {
            Name = recName;
            IngredientOne = ignOne;
            IngredientTwo = ingTwo;
            IngredientThree = ingThree;
        }

        public Recipe(string recName, string ignOne, string ingTwo)
        {
            Name = recName;
            IngredientOne = ignOne;
            IngredientTwo = ingTwo;
        }

        public override string ToString()
        {
            if (this.IngredientThree == null)
                return this.Name + "= " + this.IngredientOne + " + " + this.IngredientTwo;
            else
                return this.Name + "= " + this.IngredientOne + " + " + this.IngredientTwo + " + " + this.IngredientThree;
        }
    }
}
