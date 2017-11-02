using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRules;

namespace CharacterCreator.Classes
{
    public class Character : INotifyPropertyChanged
    {
        //============================================================================
        #region Variables
        public string Name { get; set; }
        public double Might { get; set; }
        public double Speed { get; set; }
        public double Strength { get; set; }
        public double Marksmanship { get; set; }
        public double Tech { get; set; }
        public double CharacterPoints { get; set; }
        #endregion
        //============================================================================


        //============================================================================
        #region Properties
        private List<Ability> basicAttacks;
        public List<Ability> BasicAttacks
        {
            get
            {
                if (basicAttacks == null) basicAttacks = new List<Ability>();
                return basicAttacks;
            }
        }
        private List<Ability> specialAttacks;
        public List<Ability> SpecialAttacks
        {
            get
            {
                if (specialAttacks == null) specialAttacks = new List<Ability>();
                return specialAttacks;
            }
        }
        private List<Ability> specialAbilities;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<Ability> SpecialAbilities
        {
            get
            {
                if (specialAbilities == null) specialAbilities = new List<Ability>();
                return specialAbilities;
            }
        }
        #endregion
        //============================================================================


        //============================================================================
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
        public decimal getActualDamage(decimal baseDamage, List<SpecialRule> rules)
        {
            if (baseDamage == 0) return baseDamage;

            decimal actualDamage = 0;
            double stat = 0;

            //Determine which stat to get the bonus from
            if (rules.Contains(new Range())) stat = Marksmanship;
            else if (rules.Contains(new TechMelee()) || rules.Contains(new TechRange())) stat = Tech;
            else stat = Strength;

            //Calculate the actual damage based on the bonus
            if (stat >= 6) actualDamage = baseDamage * (decimal)((stat / 10) + 0.5);
            else actualDamage = baseDamage;
            return actualDamage;
        }
        public void addAbility(Ability ability)
        {
            //Remove the ability from any list it may be in.
            if (BasicAttacks.Contains(ability)) BasicAttacks.Remove(ability);
            if (SpecialAttacks.Contains(ability)) SpecialAttacks.Remove(ability);
            if (SpecialAbilities.Contains(ability)) SpecialAbilities.Remove(ability);

            //Add the ability to the appropriate container.
            if (ability.Type == Ability.AbilityType.Basic) BasicAttacks.Add(ability);
            if (ability.Type == Ability.AbilityType.Special) SpecialAttacks.Add(ability);
            if (ability.Type == Ability.AbilityType.Ability) SpecialAbilities.Add(ability);
        }
        #endregion
        //============================================================================
    }
}