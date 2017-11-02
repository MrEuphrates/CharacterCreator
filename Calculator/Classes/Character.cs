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
        #region Properties
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if(value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private double might = 2;
        public double Might
        {
            get { return might; }
            set
            {
                if(value != might)
                {
                    might = value;
                }
            }
        }
        private double speed = 2;
        public double Speed
        {
            get { return speed; }
            set
            {
                if(value != speed)
                {
                    speed = value;
                    updateCharacterPoints();
                    updateMight();
                    OnPropertyChanged("Speed");
                }
            }
        }
        private double strength = 2;
        public double Strength
        {
            get { return strength; }
            set
            {
                if (value != strength)
                {
                    strength = value;
                    updateCharacterPoints();
                    updateMight();
                    OnPropertyChanged("Strength");
                }
            }
        }
        private double marksmanship = 2;
        public double Marksmanship
        {
            get { return marksmanship; }
            set
            {
                if (value != marksmanship)
                {
                    marksmanship = value;
                    updateCharacterPoints();
                    updateMight();
                    OnPropertyChanged("Marksmanship");
                }
            }
        }
        private double tech = 2;
        public double Tech
        {
            get { return tech; }
            set
            {
                if (value != tech)
                {
                    tech = value;
                    updateCharacterPoints();
                    updateMight();
                    OnPropertyChanged("Tech");
                }
            }
        }
        public double CharacterPoints { get; set; }
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
        public void updateMight()
        {
            this.Might = Math.Round(((Speed + Strength + Marksmanship + Tech) / 4.0));
        }
        public void updateCharacterPoints()
        {
            double totalCP = 0;
            totalCP += Speed + Strength + Marksmanship + Tech;
            CharacterPoints = totalCP;
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
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        //============================================================================
    }
}