using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using CharacterCreator.Classes;

namespace CharacterCreator
{
    public partial class CharacterForm : Form
    {
        //============================================================================================================
        #region Variables
        Character character;
        BindingSource bindingSource;
        #endregion
        //============================================================================================================

        //============================================================================================================
        #region Methods
        public CharacterForm(double characterPoints)
        {
            InitializeComponent();
            character = new Character(characterPoints);
            refreshListBoxes();

            //Data bindings
            bindingSource = new BindingSource();
            bindingSource.DataSource = character;
            txtName.DataBindings.Add("Text", bindingSource, "Name",false, DataSourceUpdateMode.OnPropertyChanged);
            nudMight.DataBindings.Add("Value", bindingSource, "Might", false, DataSourceUpdateMode.OnPropertyChanged);
            nudCharacterPointsSpent.DataBindings.Add("Value", bindingSource, "CharacterPointsSpent", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCharacterPointsMax.DataBindings.Add("Text", bindingSource, "CharacterPointsMax", false, DataSourceUpdateMode.OnPropertyChanged);
            nudSpeed.DataBindings.Add("Value", bindingSource, "Speed", false, DataSourceUpdateMode.OnPropertyChanged);
            nudStrength.DataBindings.Add("Value", bindingSource, "Strength", false, DataSourceUpdateMode.OnPropertyChanged);
            nudMarksmanship.DataBindings.Add("Value", bindingSource, "Marksmanship", false, DataSourceUpdateMode.OnPropertyChanged);
            nudTech.DataBindings.Add("Value", bindingSource, "Tech", false, DataSourceUpdateMode.OnPropertyChanged);
            listBoxAttacksBasic.DataBindings.Add("DataSource", bindingSource, "BasicAttacks", false, DataSourceUpdateMode.OnPropertyChanged);
            listBoxAttacksBasic.DisplayMember = "Syntax";
            listBoxAttacksSpecial.DataBindings.Add("DataSource", bindingSource, "SpecialAttacks", false, DataSourceUpdateMode.OnPropertyChanged);
            listBoxAttacksSpecial.DisplayMember = "Syntax";
            listBoxAbilities.DataBindings.Add("DataSource", bindingSource, "SpecialAbilities", false, DataSourceUpdateMode.OnPropertyChanged);
            listBoxAbilities.DisplayMember = "Syntax";
            nudHealth.DataBindings.Add("Value", bindingSource, "Health", false, DataSourceUpdateMode.OnPropertyChanged);
            nudEnergy.DataBindings.Add("Value", bindingSource, "Energy", false, DataSourceUpdateMode.OnPropertyChanged);
            nudRecharge.DataBindings.Add("Value", bindingSource, "Recharge", false, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void Ability_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            refreshListBoxes();
        }

        private void refreshListBoxes()
        {
            //Bind the abilities lists to their appropriate listboxes.
            listBoxAttacksBasic.DataSource = null;
            listBoxAttacksBasic.DataSource = character.BasicAttacks;
            listBoxAttacksBasic.DisplayMember = "Syntax";

            listBoxAttacksSpecial.DataSource = null;
            listBoxAttacksSpecial.DataSource = character.SpecialAttacks;
            listBoxAttacksSpecial.DisplayMember = "Syntax";

            listBoxAbilities.DataSource = null;
            listBoxAbilities.DataSource = character.SpecialAbilities;
            listBoxAbilities.DisplayMember = "Syntax";
        }
        #endregion
        //============================================================================================================


        //============================================================================================================
        #region Event Methods

        private void buttonAddAbility_Click(object sender, EventArgs e)
        {
            AbilityForm af = new AbilityForm(character);
            var result = af.ShowDialog();
            if(result == DialogResult.OK)
            {
                character.addAbility(af.ability);
                af.ability.PropertyChanged += Ability_PropertyChanged;
                refreshListBoxes();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            character.Name = txtName.Text;
        }

        /*
         * Here I am recording information on what it takes to serialize my objects.
         * Regarding special rules, the SpecialRule base class (currently) has to have an XmlInclude attribute for every special rule to indicate they should be serialized.  Need a better way.
         * Regarding variables, I had to use a custom class, SerializableDictionary, to use a dictionary, and as with special rules, I had to add an XmlInclude attribute for every variable
         *      to the base class, SpecialRuleVariable.
         * */
        private void cmdSave_Click(object sender, EventArgs e)
        {
            string path = "C:\\CharacterCreatorTest\\testoutput.coca";
            FileStream outFile = File.Create(path);
            try
            {
                XmlSerializer formatter = new XmlSerializer(character.GetType());
                formatter.Serialize(outFile, character);
                MessageBox.Show("Saved");
            }
            catch (Exception exe)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Exception: " + exe.Message);
                if (exe.InnerException != null) sb.Append("\n\nInner Exception: " + exe.InnerException.Message);
                if (exe.InnerException.InnerException != null) sb.Append("\n\nInner x2 exception: " + exe.InnerException.InnerException.Message);
                if (exe.InnerException.InnerException.InnerException != null) sb.Append("\n\nInner x3 exception: " + exe.InnerException.InnerException.InnerException.Message);
                if (exe.InnerException.InnerException.InnerException.InnerException != null) sb.Append("\n\nInner x4 exception: " + exe.InnerException.InnerException.InnerException.InnerException.Message);
                if (exe.InnerException.InnerException.InnerException.InnerException.InnerException != null) sb.Append("\n\nInner x5 exception: " + exe.InnerException.InnerException.InnerException.InnerException.InnerException.Message);
                if (exe.InnerException.InnerException.InnerException.InnerException.InnerException.InnerException != null) sb.Append("\n\nInner x6 exception: " + exe.InnerException.InnerException.InnerException.InnerException.InnerException.InnerException.Message);
                MessageBox.Show(sb.ToString());
            }
            finally
            {
                outFile.Close();
            }
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            string file = "C:\\CharacterCreatorTest\\testoutput.coca";
            XmlSerializer formatter = new XmlSerializer(character.GetType());
            FileStream characterFile = new FileStream(file, FileMode.Open);
            byte[] buffer = new byte[characterFile.Length];
            characterFile.Read(buffer, 0, (int)characterFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            try
            {
                Character loadedCharacter = (Character)formatter.Deserialize(stream);
                character = loadedCharacter;
                bindingSource.DataSource = character;
                foreach(Ability ability in character.BasicAttacks) ability.PropertyChanged += Ability_PropertyChanged;
            }
            catch(Exception exe)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Exception: " + exe.Message);
                if (exe.InnerException != null) sb.Append("\n\nInner Exception: " + exe.InnerException.Message);
                MessageBox.Show(sb.ToString());
            }
            finally
            {
                stream.Close();
                characterFile.Close();
            }
            
        }
        private void listBoxAttacksBasic_SelectedIndexChanged(object sender, EventArgs e)
        {
            //I only want one index selected across the three listboxes.
            if(listBoxAttacksBasic.SelectedIndex != -1)
            {
                listBoxAttacksSpecial.ClearSelected();
                listBoxAbilities.ClearSelected();
            }
        }
        private void listBoxAttacksSpecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //I only want one index selected across the three listboxes.
            if (listBoxAttacksSpecial.SelectedIndex != -1)
            {
                listBoxAttacksBasic.ClearSelected();
                listBoxAbilities.ClearSelected();
            }
        }
        private void listBoxAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            //I only want one index selected across the three listboxes.
            if (listBoxAbilities.SelectedIndex != -1)
            {
                listBoxAttacksBasic.ClearSelected();
                listBoxAttacksSpecial.ClearSelected();
            }
        }
        private void cmdEditAbility_Click(object sender, EventArgs e)
        {
            Ability selectedAbility = null;
            if (listBoxAttacksBasic.SelectedIndex != -1) selectedAbility = (Ability)listBoxAttacksBasic.Items[listBoxAttacksBasic.SelectedIndex];
            if (listBoxAttacksSpecial.SelectedIndex != -1) selectedAbility = (Ability)listBoxAttacksSpecial.Items[listBoxAttacksSpecial.SelectedIndex];
            if (listBoxAbilities.SelectedIndex != -1) selectedAbility = (Ability)listBoxAbilities.Items[listBoxAbilities.SelectedIndex];
            if(selectedAbility != null)
            {
                var aform = new AbilityForm(character, selectedAbility);
                var result = aform.ShowDialog();
                if(result == DialogResult.OK)
                {
                    character.addAbility(aform.ability);
                    aform.ability.PropertyChanged += Ability_PropertyChanged;
                    refreshListBoxes();
                }
            }
        }

        private void cmdDeleteAbility_Click(object sender, EventArgs e)
        {
            Ability selectedAbility = null;
            if (listBoxAttacksBasic.SelectedIndex != -1)
            {
                selectedAbility = (Ability)listBoxAttacksBasic.Items[listBoxAttacksBasic.SelectedIndex];
                character.BasicAttacks.Remove(selectedAbility);
            }
            if (listBoxAttacksSpecial.SelectedIndex != -1)
            {
                selectedAbility = (Ability)listBoxAttacksSpecial.Items[listBoxAttacksSpecial.SelectedIndex];
                character.SpecialAttacks.Remove(selectedAbility);
            }
            if (listBoxAbilities.SelectedIndex != -1)
            {
                selectedAbility = (Ability)listBoxAbilities.Items[listBoxAbilities.SelectedIndex];
                character.SpecialAbilities.Remove(selectedAbility);
            }
            refreshListBoxes();
        }

        private void buttonAddPassiveAbility_Click(object sender, EventArgs e)
        {
            PassiveAbilityForm af = new PassiveAbilityForm(character);
            var result = af.ShowDialog();
            if (result == DialogResult.OK)
            {
                character.addAbility(af.ability);
                af.ability.PropertyChanged += Ability_PropertyChanged;
                refreshListBoxes();
            }
        }
        #endregion
        //============================================================================================================
    }
}