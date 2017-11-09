using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRules;
using System.Windows.Forms;

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
                    updateAbilitiesActualDamage();
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
                    updateAbilitiesActualDamage();
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
                    updateAbilitiesActualDamage();
                    OnPropertyChanged("Tech");
                }
            }
        }
        private double characterPointsSpent = 0;
        public double CharacterPointsSpent
        {
            get { return characterPointsSpent; }
            set
            {
                if(value != characterPointsSpent)
                {
                    characterPointsSpent = value;
                    OnPropertyChanged("CharacterPointsSpent");
                }
            }
        }
        private double characterPointsMax;
        public double CharacterPointsMax
        {
            get { return characterPointsMax; }
            set
            {
                if (value != characterPointsMax)
                {
                    characterPointsMax = value;
                    OnPropertyChanged("CharacterPointsMax");
                }
            }
        }
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
        public List<Ability> SpecialAbilities
        {
            get
            {
                if (specialAbilities == null) specialAbilities = new List<Ability>();
                return specialAbilities;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private double health = 25;
        public double Health
        {
            get { return health; }
            set
            {
                if(value != health)
                {
                    health = value;
                    updateCharacterPoints();
                    OnPropertyChanged("Health");
                }
            }
        }
        private double energy = 50;
        public double Energy
        {
            get { return energy; }
            set
            {
                if(value != energy)
                {
                    energy = value;
                    updateCharacterPoints();
                    OnPropertyChanged("Energy");
                }
            }
        }
        public double Recharge
        {
            get
            {
                return energy / 10.0;
            }
        }
        #endregion
        //============================================================================


        //============================================================================
        #region Methods
        public Character() { }
        public Character(double characterPoints)
        {
            characterPointsMax = characterPoints;
            updateCharacterPoints();
        }
        public void updateMight()
        {
            this.Might = Math.Round(((Speed + Strength + Marksmanship + Tech) / 4.0));
        }
        private void updateCharacterPoints()
        {
            double spentPoints = 0;
            spentPoints += speed + strength + marksmanship + tech;
            spentPoints += (BasicAttacks.Count * 0.5);
            spentPoints += SpecialAttacks.Count;
            spentPoints += (health / 25.0 * 0.5);
            spentPoints += (energy / 50.0 * 0.5);
            CharacterPointsSpent = spentPoints;
        }
        private void updateAbilitiesActualDamage()
        {
            foreach (Ability ability in BasicAttacks) ability.Damage = getActualDamage(ability.BaseDamage, ability.SpecialRules);
            foreach (Ability ability in SpecialAttacks) ability.Damage = getActualDamage(ability.BaseDamage, ability.SpecialRules);
            foreach (Ability ability in SpecialAbilities) ability.Damage = getActualDamage(ability.BaseDamage, ability.SpecialRules);
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

            //Update the character points
            updateCharacterPoints();
        }
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
        public void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public bool isCharacterValid()
        {
            if(characterPointsSpent > characterPointsMax)
            {
                MessageBox.Show("The total character points spent, " + characterPointsSpent + ", exceeds the maximum, " + characterPointsMax + ".");
                return false;
            }
            return true;
        }
        #endregion
        //============================================================================
    }
}