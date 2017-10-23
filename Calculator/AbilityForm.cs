using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes;
using CharacterCreator.Classes.SpecialRules;

namespace CharacterCreator
{
    public partial class AbilityForm : Form
    {
        #region Variables
        public Character character;
        public Ability ability;
        #endregion
        public AbilityForm(Character character)
        {
            InitializeComponent();
            this.character = character;
            ability = new Ability();

            //Setup the delays for the tooltip
            toolTip1.AutoPopDelay = 20000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            //Setup the tooltip for the controls
            toolTip1.SetToolTip(nudDamageBase, "The basic amount of damage dealt by this ability.  Must be a multiple of 10.  Leave as 0 if this ability " +
                "is not meant to deal damage.");
            toolTip1.SetToolTip(nudTime, "The amount of time which must be spent to use this ability.  Characters are limited to 10 per round.  The " +
                "recommended amount of Time for an ability is 1 per 100.  The energy cost increases if Time is below the recommended amount, and the " +
                "reverse is also true.");
        }

        //===================================================================
        #region Methods
        private void updateAbility()
        {
            //TODO Whenever anything about this ability changes, this method needs to be called.
            ability.Time = nudTime.Value;
            ability.BaseDamage = nudDamageBase.Value;
            ability.Damage = nudDamageActual.Value;  //TODO Perhaps Ability should know how to set the actual damage instead of the form?
            List<SpecialRule> sr = new List<SpecialRule>();
            foreach (var i in listBoxSpecial.Items)
            {
                sr.Add((SpecialRule)i);
            }
            ability.SpecialRules = sr;

            //After updating everything about the Ability instance, update the energy cost and then record it.
            updateEnergyCost();
            ability.Energy = nudEnergy.Value;
        }
        private void updateEnergyCost()
        {
            //Get the basic energy cost of this ability based on the damage.
            var baseEnergy = nudDamageBase.Value / 2;
            var energy = baseEnergy;

            //Check the Time and adjust the cost accordingly, based on actual total damage.
            var time = nudTime.Value;
            var baseDamageTotal = nudDamageBase.Value * nudAttacks.Value;
            decimal expectedTime = (-1*(0 - (baseDamageTotal % 100)) + baseDamageTotal) / 100;
            var timeEnergyCost = ((expectedTime - time) * 0.2m)* baseDamageTotal;
            energy += timeEnergyCost;

            //Calculate the cost of the special rules and add them to the energy cost.
            var specialsBaseCost = getEnergyCostOfSpecials();
            energy += specialsBaseCost * nudAttacks.Value;

            //Set the ability's energy cost.
            nudEnergy.Value = energy;
        }
        private decimal getEnergyCostOfSpecials()
        {//TODO What about when the damage is 0?  Some special rules are going to care about that.
            decimal energy = 0;//TODO I need to test all of the energy cost methods to make sure they work correctly.
            foreach(var i in listBoxSpecial.Items)
            {
                SpecialRule rule = (SpecialRule)i;
                energy += rule.calculateEnergyCost(nudDamageBase.Value);
            }
            return energy;
        }
        #endregion
        //===================================================================

        //===================================================================
        #region Event Methods
        private void buttonAddSpecial_Click(object sender, EventArgs e)
        {
            SpecialForm sf = new SpecialForm(ability);
            sf.ShowDialog();
            updateAbility();
        }

        private void nudDamageBase_ValueChanged(object sender, EventArgs e)
        {
            if (nudDamageBase.Value % 10 != 0)
            {
                nudDamageBase.Value = nudDamageBase.Value - nudDamageBase.Value % 10;
                return;
            }
            if (character.Strength >= 6) nudDamageActual.Value = nudDamageBase.Value * (decimal)((character.Strength / 10) + 0.5);
            else nudDamageActual.Value = nudDamageBase.Value;
            updateAbility();
        }

        private void nudTime_ValueChanged(object sender, EventArgs e)
        {
            updateAbility();
        }

        private void nudAttacks_ValueChanged(object sender, EventArgs e)
        {
            updateAbility();
        }
        #endregion
        //===================================================================

    }
}
