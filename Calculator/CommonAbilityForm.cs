using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes;
using CharacterCreator.Classes.SpecialRules;

namespace CharacterCreator
{
    public partial class CommonAbilityForm : Form
    {
        #region Variables
        Ability ability = new Ability();
        #endregion
        public CommonAbilityForm(Ability ability)
        {
            InitializeComponent();
            this.ability = ability;
        }
        
        
        //======================================================
        #region Event Methods
        private void SpecialForm_Load(object sender, EventArgs e)
        {
            //Until I find a better way, this list is typed manually.
            //TODO Replace this stuff with ability stuff.
            //Rules attached to this ability should be added first, for editing.
            if (ability.SpecialRules != null) foreach (SpecialRule rule in ability.SpecialRules) clbAbilities.Items.Add(rule,true);

            //Add the rest of the rules, but don't add ones already added from the ability.
            SpecialRule nRule = new Acid();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new ArmorBuster();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Blast();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Blind();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new ChangeSpeed();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new ChangeStrength();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new ChangeMarksmanship();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new ChangeTech();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new CounterAttack();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Deafen();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new DrainTime();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Encase();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Explosion();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Fear();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new GreaterAcid();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new GreaterCounterAttack();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new GreaterIndirect();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new GreaterNoDeflect();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new GreaterNoDodge();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Heal();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new IdentifyFriendFoe();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Indirect();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Leap();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new NoArmorReduction();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new NoDeflect();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new NoDodge();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Paralyze();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new PoisonMalignant();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new PoisonResilient();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Pull();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Range();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new CharacterCreator.Classes.SpecialRules.Radius();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new RerollMisses();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new RerollHits();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Reach();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Roll();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Slam();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Stream();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Stun();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new SuperbAcid();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new SuperbCounterAttack();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new SuperbIndirect();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new SuperbNoDeflect();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new SuperbNoDodge();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new TechAttack();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new TechBlast();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new TechBlind();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new TechDeafen();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new TechExplosion();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new TechEncase();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new TechMelee();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new TechParalyze();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new TechRange();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Teleport();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Throw();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
            nRule = new Trip();
            if (!ability.SpecialRules.Contains(nRule)) clbAbilities.Items.Add(nRule);
        }
        
        private void clbSpecials_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the name
            var rule = (SpecialRule)clbAbilities.Items[clbAbilities.SelectedIndex];
            rtbAbilityDescription.Text = rule.Name;
            rtbAbilityDescription.Select(0, rule.Name.Length);
            rtbAbilityDescription.SelectionFont = new Font(rtbAbilityDescription.Font, FontStyle.Bold);

            //Get the description
            var description = "\n" + rule.Description;
            rtbAbilityDescription.AppendText(description);
            rtbAbilityDescription.Select(rule.Name.Length, rule.Name.Length + description.Length);
            rtbAbilityDescription.SelectionFont = new Font(rtbAbilityDescription.Font, FontStyle.Regular);

            //List the variables, if there are any.
            var variables = rule.listVariables();
            if (variables != "") rtbAbilityDescription.AppendText("\n\n" + variables);

            //The effects.
            rtbAbilityDescription.AppendText("\n\n" + rule.Effects);

            //List the negation and duration rules, if there are any.
            var negation = rule.NegationAndDuration;
            if (negation != "") rtbAbilityDescription.AppendText("\n\n" + negation);

            //Get the incompatability list
            var incompatibleRules = rule.listIncompatibleRules();
            if (incompatibleRules != "")
            {
                var incompatible = "\n\n" + incompatibleRules;
                rtbAbilityDescription.AppendText(incompatible);
            }

            //Disply how the energy cost is calculated
            var cost = rule.howIsEnergyCostCalculated();
            rtbAbilityDescription.AppendText("\n\nThe Energy cost for " + rule.Name + " is " + cost + ".");

            //Get the character sheet syntax.
            rtbAbilityDescription.AppendText("\n\nAppears on the character sheet as " + rule.SyntaxSample + ".");
        }

        private void commandOK_Click(object sender, EventArgs e)
        {
            //Get selected rules
            var rules = getSelectedRules();

            //Make sure the chosen rules are compatible.
            if (!checkRulesCompatible(rules)) return;

            //Make sure the chosen rules are valid.
            foreach(SpecialRule rule in rules) if (!rule.specialRuleIsValid(ability, rules)) return;

            //After confirming all selected rules are compatible, cycle through those with parameters and have the user provide them.
            foreach(SpecialRule rule in rules)
            {
                if (rule.Variables.Count == 0) continue;
                ParameterForm pform = new ParameterForm(rule);
                pform.ShowDialog();
            }
            ability.SpecialRules = rules;

            this.Dispose();
        }

        private bool checkRulesCompatible(List<SpecialRule> rules)
        {
            //Check that every selected rule is compatible with every other selected rule.
            foreach(SpecialRule rule in rules) if (!rule.IsCompatibleWith(rules)) return false;
            return true;
        }

        private List<SpecialRule> getSelectedRules()
        {
            //Gather the chosen rules into a list
            List<SpecialRule> rules = new List<SpecialRule>();
            for (int i = 0; i < clbAbilities.CheckedItems.Count; ++i) rules.Add((SpecialRule)clbAbilities.CheckedItems[i]);
            return rules;
        }

        private void clbSpecials_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                var rules = getSelectedRules();
                SpecialRule rule = (SpecialRule)clbAbilities.Items[e.Index];
                if (!rule.specialRuleIsValid(this.ability, rules)) e.NewValue = e.CurrentValue;
            }
        }
        #endregion
        //======================================================
    }
}