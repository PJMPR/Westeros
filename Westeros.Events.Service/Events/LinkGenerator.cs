using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Westeros.Events.Web.Services.Events
{
    public class LinkGenerator : ILinkGenerator
    {
        private String _RecipebaseAddress;
        public LinkGenerator(string RecipebaseAddress)
        {
            _RecipebaseAddress = RecipebaseAddress;
        }

        public string GenerateRecipeLink(int RecipeId)
        {
            return  "<a href=\""
                    +_RecipebaseAddress
                    +"Recipe/Details/" 
                    + RecipeId 
                    + "\">Recipe link</a>";

        }
    }
}
