using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsApp.Models
{
    class StarWarsCharacter
    {
        private string character;

        public StarWarsCharacter(string character)
        {
            this.character = character;
        }

        public string name { get; set; }
    }
}
