using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRules;

namespace CharacterCreator.Classes
{
    public class Ability
    {
        public enum AbilityType { Basic, Special, Ability }

        #region Properties
        public decimal Time { get; set; }
        public string Name { get; set; }
        public decimal Energy { get; set; }
        public decimal BaseDamage { get; set; }
        public decimal Damage { get; set; }
        public decimal Attacks { get; set; }
        public double CharacterPoints { get; }
        public bool RequiresInput { get; set; }
        public string InputDescription { get; set; }
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
        public string Syntax
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Convert.ToInt32(Time) + " ");
                sb.Append(Name + " ");
                sb.Append(Convert.ToInt32(Energy) + "/");
                if (BaseDamage == Damage) sb.Append(Convert.ToInt32(BaseDamage) + "  ");
                else sb.Append(Convert.ToInt32(BaseDamage) + " (" + Convert.ToInt32(Damage) + ")  ");
                if (Attacks > 1) sb.Append(Convert.ToInt32(Attacks) + " attacks.  ");
                if (SpecialRules.Count == 1) sb.Append(SpecialRules[0].SyntaxActual);
                else if (SpecialRules.Count > 1)
                {
                    sb.Append(SpecialRules[0].SyntaxActual);
                    for (int i = 1; i < SpecialRules.Count; ++i) sb.Append(", " + SpecialRules[i].SyntaxActual);
                }
                if (RequiresInput) sb.Append("  *** " + InputDescription);
                return sb.ToString();
            }
        }
        private AbilityType abilityType;
        public AbilityType Type
        {
            get
            {
                if (BaseDamage == 0) return AbilityType.Ability;
                var countOfRules = SpecialRules.Count;
                if (SpecialRules.Contains(new Range()) || SpecialRules.Contains(new TechRange())) --countOfRules;
                if (BaseDamage > 100 || countOfRules > 1) return AbilityType.Special;
                return AbilityType.Basic;
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

        public override bool Equals(object obj)
        {
            //If the param is null, return False
            if (obj == null) return false;

            //If param cannot be cast as Ability, return false
            Ability r = obj as Ability;
            if ((System.Object)r == null) return false;

            //If the names of the abilities match, they are considered equal
            if (this.Name == r.Name) return true;

            return false;
        }

        public bool Equals(SpecialRule r)
        {
            if ((object)r == null) return false;

            //If the names of the abilities match, they are considered equal
            if (this.Name == r.Name) return true;

            return false;
        }
        #endregion
    }
}