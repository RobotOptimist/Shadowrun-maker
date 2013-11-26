using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ShadowrunCharacterMaker
{
    public partial class CharUpdater : Form
    {

        int attributeCost = 10;
        int skillCost = 4;
        int skillGroupCost = 10;

        NewCharacter newChar = new NewCharacter();
        Character character = new Character();        

        public CharUpdater()
        {
            InitializeComponent();

            System.Collections.Generic.List<AttributeUpDown> upDowns = new System.Collections.Generic.List<AttributeUpDown>();
            upDowns.Add(agilityUpDown);
            upDowns.Add(strengthUpDown);
            upDowns.Add(bodyUpDown);
            upDowns.Add(reactionUpDown);
            upDowns.Add(logicUpDown);
            upDowns.Add(charismaUpDown);
            upDowns.Add(intuitionUpDown);
            upDowns.Add(willpowerUpDown);
            upDowns.Add(magicUpDown);
            upDowns.Add(resonanceUpDown);
            upDowns.Add(edgeUpDown);

            foreach (AttributeUpDown n in upDowns)
            {
                n.SetParamCharacter(character, buildPoints);
            }
        }

        //adjusts attributes according to race per the methods in NewCharacter
        public void raceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (raceBox.Text)
            {
                case "Human": newChar.CreateHuman(charName.Text);
                    character.SetNewCharacterAttributes(newChar);
                    this.PopulateValues();
                    break;
                case "Troll": newChar.CreateTroll(charName.Text);
                    character.SetNewCharacterAttributes(newChar);
                    this.PopulateValues();
                    break;
                case "Ork": newChar.CreateOrk(charName.Text);
                    character.SetNewCharacterAttributes(newChar);
                    this.PopulateValues();
                    break;
                case "Elf": newChar.CreateElf(charName.Text);
                    character.SetNewCharacterAttributes(newChar);
                    this.PopulateValues();
                    break;
                case "Dwarf": newChar.CreateDwarf(charName.Text);
                    character.SetNewCharacterAttributes(newChar);
                    this.PopulateValues();
                    break;
                default: break;

            }
        }

        public void PopulateValues()
        {
            agilityUpDown.Minimum = newChar.agility[0];
            agilityUpDown.Maximum = newChar.agility[1];
            agilityUpDown.Value = character.agility;

            strengthUpDown.Minimum = newChar.strength[0];
            strengthUpDown.Maximum = newChar.strength[1];
            strengthUpDown.Value = character.strength;

            reactionUpDown.Minimum = newChar.reaction[0];
            reactionUpDown.Maximum = newChar.reaction[1];
            reactionUpDown.Value = character.reaction;

            bodyUpDown.Minimum = newChar.body[0];
            bodyUpDown.Maximum = newChar.body[1];
            bodyUpDown.Value = character.body;

            logicUpDown.Minimum = newChar.logic[0];
            logicUpDown.Maximum = newChar.logic[1];
            logicUpDown.Value = character.logic;

            willpowerUpDown.Minimum = newChar.willpower[0];
            willpowerUpDown.Maximum = newChar.willpower[1];
            willpowerUpDown.Value = character.willpower;

            intuitionUpDown.Minimum = newChar.intuition[0];
            intuitionUpDown.Maximum = newChar.intuition[1];
            intuitionUpDown.Value = character.intuition;

            charismaUpDown.Minimum = newChar.charisma[0];
            charismaUpDown.Maximum = newChar.charisma[1];
            charismaUpDown.Value = character.charisma;

            edgeUpDown.Minimum = newChar.edge[0];
            edgeUpDown.Maximum = newChar.edge[1];
            edgeUpDown.Value = character.edge;

            magicUpDown.Maximum = newChar.essence;
            magicUpDown.Value = character.magic;

            resonanceUpDown.Maximum = newChar.essence;
            resonanceUpDown.Value = character.resonance;
            
            InitiativeText.Text = character.initiative.ToString();

            buildPoints.Text = character.buildPoints.ToString();

            EssenceText.Text = character.essence.ToString();
        }

        public void AttributeUpDown_ValueChanged(object sender, EventArgs e)
        {
            AttributeUpDown attribute = (AttributeUpDown)sender;

            System.Collections.Generic.List<AttributeUpDown> upDowns = new System.Collections.Generic.List<AttributeUpDown>();
            upDowns.Add(agilityUpDown);
            upDowns.Add(strengthUpDown);
            upDowns.Add(bodyUpDown);
            upDowns.Add(reactionUpDown);
            upDowns.Add(logicUpDown);
            upDowns.Add(charismaUpDown);
            upDowns.Add(intuitionUpDown);
            upDowns.Add(willpowerUpDown);
            

            if (character.attributeMax == false)
            {
                if (attribute.Value == attribute.Maximum)
                {
                    upDowns.Remove(attribute);

                    foreach (AttributeUpDown n in upDowns)
                    {
                        n.Maximum = n.Maximum - 1;
                        n.maxReached = true;
                    }

                    character.attributeMax = true;
                }
            }
            else if (character.attributeMax == true && attribute.maxReached == false)
            {
                upDowns.Remove(attribute);

                foreach (AttributeUpDown n in upDowns)
                {
                    n.Maximum = n.Maximum + 1;
                    n.maxReached = false;
                }

                character.attributeMax = false;
            }
        }

        public void positiveButton_Click(object sender, EventArgs e)
        {
            PositiveQualities posQual = new PositiveQualities(character, QualitiesSelected, this);
            posQual.ShowDialog();
        }

        public void InitializeMagic()
        {
            magicUpDown.Minimum = 1;
            magicUpDown.Value = 1;
            character.magic = 1;
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {

        }


    }
}
