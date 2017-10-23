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
    public partial class SpecialForm : Form
    {
        #region Variables
        Ability ability = new Ability();
        #endregion
        public SpecialForm(Ability ability)
        {
            InitializeComponent();
            this.ability = ability;
        }

        //======================================================
        #region Event Methods
        private void SpecialForm_Load(object sender, EventArgs e)
        {
            //TODO Populate the check box list with the names of special rules which aren't attached to the ability already.
            //TODO Until I find a better way, this list is typed manually.
            clbSpecials.Items.Add(new Acid());
            clbSpecials.Items.Add(new ArmorBuster());
            clbSpecials.Items.Add(new Blast());
            clbSpecials.Items.Add(new Blind());
            clbSpecials.Items.Add(new ChangeSpeed());
            clbSpecials.Items.Add(new ChangeStrength());
            clbSpecials.Items.Add(new ChangeMarksmanship());
            clbSpecials.Items.Add(new ChangeTech());
            clbSpecials.Items.Add(new CounterAttack());
            clbSpecials.Items.Add(new Deafen());
            clbSpecials.Items.Add(new DrainTime());
            clbSpecials.Items.Add(new Encase());
            clbSpecials.Items.Add(new Explosion());
            clbSpecials.Items.Add(new Fear());
            clbSpecials.Items.Add(new GreaterAcid());
            clbSpecials.Items.Add(new GreaterCounterAttack());
            clbSpecials.Items.Add(new GreaterIndirect());
            clbSpecials.Items.Add(new GreaterNoDeflect());
            clbSpecials.Items.Add(new GreaterNoDodge());
            clbSpecials.Items.Add(new Heal());
            clbSpecials.Items.Add(new IdentifyFriendFoe());
            clbSpecials.Items.Add(new Indirect());
            clbSpecials.Items.Add(new Leap());
            clbSpecials.Items.Add(new NoArmorReduction());
            clbSpecials.Items.Add(new NoDeflect());
            clbSpecials.Items.Add(new NoDodge());
            clbSpecials.Items.Add(new Paralyze());
            clbSpecials.Items.Add(new PoisonMalignant());
            clbSpecials.Items.Add(new PoisonResilient());
            clbSpecials.Items.Add(new Pull());
            clbSpecials.Items.Add(new Range());
            clbSpecials.Items.Add(new CharacterCreator.Classes.SpecialRules.Radius());
            clbSpecials.Items.Add(new RerollMisses());
            clbSpecials.Items.Add(new RerollHits());
            clbSpecials.Items.Add(new Reach());
            clbSpecials.Items.Add(new Roll());
            clbSpecials.Items.Add(new Slam());
            clbSpecials.Items.Add(new Stream());
            clbSpecials.Items.Add(new Stun());
            clbSpecials.Items.Add(new SuperbAcid());
            clbSpecials.Items.Add(new SuperbCounterAttack());
            clbSpecials.Items.Add(new SuperbIndirect());
            clbSpecials.Items.Add(new SuperbNoDeflect());
            clbSpecials.Items.Add(new SuperbNoDodge());
            clbSpecials.Items.Add(new TechAttack());
            clbSpecials.Items.Add(new TechBlast());
            clbSpecials.Items.Add(new TechBlind());
            clbSpecials.Items.Add(new TechDeafen());
            clbSpecials.Items.Add(new TechExplosion());
            clbSpecials.Items.Add(new TechEncase());
            clbSpecials.Items.Add(new TechMelee());
            clbSpecials.Items.Add(new TechParalyze());
            clbSpecials.Items.Add(new TechRange());
            clbSpecials.Items.Add(new Teleport());
            clbSpecials.Items.Add(new Throw());
            clbSpecials.Items.Add(new Trip());
        }
        //TODO Need to make sure incompatible selections are remarked on.
        private void clbSpecials_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO When a user clicks on a special rule, fill in the description box so they can understand more about it.
            var rule = (SpecialRule)clbSpecials.Items[clbSpecials.SelectedIndex];
            rtbSpecialDescription.Text = rule.Name;
            rtbSpecialDescription.Select(0, rule.Name.Length);
            rtbSpecialDescription.SelectionFont = new Font(rtbSpecialDescription.Font, FontStyle.Bold);

            //Get the description
            var description = "\n" + rule.Description;
            rtbSpecialDescription.AppendText(description);
            rtbSpecialDescription.Select(rule.Name.Length, rule.Name.Length + description.Length);
            rtbSpecialDescription.SelectionFont = new Font(rtbSpecialDescription.Font, FontStyle.Regular);

            //List the variables, if there are any.
            var variables = rule.listVariables();
            if (variables != "") rtbSpecialDescription.AppendText("\n\n" + variables);

            //The effects.
            rtbSpecialDescription.AppendText("\n\n" + rule.Effects);

            //List the negation and duration rules, if there are any.
            var negation = rule.NegationAndDuration;
            if (negation != "") rtbSpecialDescription.AppendText("\n\n" + negation);

            //Get the incompatability list
            //TODO Haven't implemented incompatibility yet.
            //var incompatibleRules = rule.listIncompatibleRules();
            //if (incompatibleRules != "")
            //{
            //    var incompatible = "\n\nIncompatible with " + incompatibleRules;
            //    rtbSpecialDescription.AppendText(incompatible);
            //}

            //TODO Show the character sheet syntax.
            rtbSpecialDescription.AppendText("\n\nAppears on the character sheet as " + rule.SyntaxSample + ".");
        }
        #endregion
        //======================================================
    }
}
