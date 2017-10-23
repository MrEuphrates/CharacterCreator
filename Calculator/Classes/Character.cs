using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Classes
{
    public class Character
    {
        #region Variables
        public string Name { get; set; }
        public double Might { get; set; }
        public double Speed { get; set; }
        public double Strength { get; set; }
        public double Marksmanship { get; set; }
        public double Tech { get; set; }
        public double CharacterPoints { get; set; }
        public List<Ability> Abilities { get; }
        #endregion

        #region Methods
        public double calculateMight()
        {
            this.Might = Math.Round(((Speed + Strength + Marksmanship + Tech) / 4.0));
            return Might;
        }
        public double calculateCharacterPoints()
        {
            double totalCP = 0;
            totalCP += Speed + Strength + Marksmanship + Tech;
            CharacterPoints = totalCP;
            return CharacterPoints;
        }
        #endregion
    }
}