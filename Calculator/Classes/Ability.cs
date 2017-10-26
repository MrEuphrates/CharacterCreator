using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes
{
    public class Ability
    {
        #region Properties
        public decimal Time { get; set; }
        public string Name { get; set; }
        public decimal Energy { get; set; }
        public decimal BaseDamage { get; set; }
        public decimal Damage { get; set; }
        public decimal Attacks { get; set; }
        public double CharacterPoints { get; }
        private List<SpecialRule> specialRules;
        public List<SpecialRule> SpecialRules
        {
            get
            {
                if (specialRules == null) specialRules = new List<SpecialRule>();
                return specialRules;
            }
            set
            {
                specialRules = value;
            }
        }
        #endregion

        #region Methods
        public decimal getEnergyModifier()
        {
            decimal baseMod = BaseDamage * 0.2m;
            if (baseMod % 5 != 0) baseMod = baseMod + (5 - (baseMod % 5));
            return baseMod;
        }
        public decimal getEnergyModifier(decimal baseDamage)
        {
            decimal baseMod = baseDamage * 0.2m;
            if (baseMod % 5 != 0) baseMod = baseMod + (5 - (baseMod % 5));
            return baseMod;
        }
        #endregion
    }
}
