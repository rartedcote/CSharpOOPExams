using HAD.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HAD.Entities.Items
{
    public class RecipeItem : BaseItem, IRecipe
    {
        public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, params string[] requiredItems) 
            : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {
            RequiredItems = requiredItems;
        }

        public IReadOnlyList<string> RequiredItems { get; private set; }
    }
}