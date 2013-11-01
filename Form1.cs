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
    public partial class Form1 : Form
    {

        private int bp, agility, body, reaction, strength, logic, intuition, willpower, charisma, edge, initiative, magic, resonance, essence;
        string name, race;

        int attributeValue;
        int attributeCost = 10;
        int skillCost = 4;
        int skillGroupCost = 10;

        Character newChar = new Character();

        public Form1(int charID)
        {
            InitializeComponent();

            ConnectShadowrun conChar = new ConnectShadowrun();

            //character object will load attributes from SQL
            newChar.SetAttribute(charID);
            
            //set int values during initialization according to what was loaded from SQL
            agility = newChar.GetCharInfoI("Agility");
            body = newChar.GetCharInfoI("Body");
            strength = newChar.GetCharInfoI("Strength");
            reaction = newChar.GetCharInfoI("Reaction");
            logic = newChar.GetCharInfoI("Logic");
            intuition = newChar.GetCharInfoI("Intuition");
            willpower = newChar.GetCharInfoI("Willpower");
            charisma = newChar.GetCharInfoI("Charisma");
            edge = newChar.GetCharInfoI("Edge");
            initiative = (reaction + intuition); //initative is a derived value
            magic = newChar.GetCharInfoI("Magic");
            resonance = newChar.GetCharInfoI("Resonance");
            essence = newChar.GetCharInfoI("Essence");
            bp = newChar.GetCharInfoI("BP");

            name = newChar.GetCharacterInfoS("Name");
            race = newChar.GetCharacterInfoS("Race");

            //initialize starting values prior to any changes
            AgilityText.Text = agility.ToString();
            BodyText.Text = body.ToString();
            StrengthText.Text = strength.ToString();
            ReactionText.Text = reaction.ToString();
            LogicText.Text = logic.ToString();
            IntuitionText.Text = intuition.ToString();
            WillpowerText.Text = willpower.ToString();
            CharismaText.Text = charisma.ToString();
            EdgeText.Text = edge.ToString();
            buildPoints.Text = bp.ToString();
            EssenceText.Text = essence.ToString();
            InitiativeText.Text = (reaction + intuition).ToString();
            charName.Text = name;
          
                         
        }
        //loads attribute to be changed
        public void AttributeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AttributeChanger.ReadOnly = false;
            ChangeLabel.Text = "Change " + AttributeComboBox.Text;
            switch (AttributeComboBox.Text)
            {
                case "Agility":
                    attributeValue = agility;
                    AttributeChanger.Value = agility;                    
                    break;
                case "Body":
                    attributeValue = body;
                    AttributeChanger.Value = body;                    
                    break;
                case "Reaction":
                    attributeValue = reaction;
                    AttributeChanger.Value = reaction;                    
                    break;
                case "Strength":
                    attributeValue = strength;
                    AttributeChanger.Value = strength;                    
                    break;
                case "Logic":
                    attributeValue = logic;
                    AttributeChanger.Value = logic;                    
                    break;
                case "Intuition":
                    attributeValue = intuition;
                    AttributeChanger.Value = intuition;                    
                    break;
                case "Charisma":
                    attributeValue = charisma;
                    AttributeChanger.Value = charisma;                    
                    break;
                case "Willpower":
                    attributeValue = willpower;
                    AttributeChanger.Value = willpower;                    
                    break;
                case "Edge":
                    attributeValue = edge;
                    AttributeChanger.Value = edge;                  
                    break;
                default: break;
            }
        }
        //tests change to determine if bps are added or subtracted
        //updates attribute vars, attributeText.Text with new info
        //note derived value of InitiativeText.Text & initiative changes
        public void AttributeChanger_ValueChanged(object sender, EventArgs e)
        {

            if (AttributeChanger.Value > attributeValue)
            {
                bp = newChar.BuildPointCost(bp, attributeCost, true, true); //final true is an optional argument indicating attribute
                buildPoints.Text = bp.ToString();
                attributeValue = (int)AttributeChanger.Value;
            }
            else if (AttributeChanger.Value < attributeValue)
            {
                bp = newChar.BuildPointCost(bp, attributeCost, false, true); //final true is an optional argument
                buildPoints.Text = bp.ToString();
                attributeValue = (int)AttributeChanger.Value;
            }
            else
            {
                buildPoints.Text = bp.ToString();
                attributeValue = (int)AttributeChanger.Value;
            }

            switch (AttributeComboBox.Text)
            {
                case "Agility": agility = attributeValue; AgilityText.Text = agility.ToString();
                    break;
                case "Body": body = attributeValue; BodyText.Text = body.ToString();
                    break;
                case "Strength": strength = attributeValue; StrengthText.Text = strength.ToString();
                    break;
                case "Reaction": reaction = attributeValue; ReactionText.Text = reaction.ToString();
                    InitiativeText.Text = (reaction + intuition).ToString();
                    initiative = (reaction + intuition);
                    break;
                case "Logic": logic = attributeValue; LogicText.Text = logic.ToString();
                    break;
                case "Intuition": intuition = attributeValue; IntuitionText.Text = intuition.ToString();
                    InitiativeText.Text = (reaction + intuition).ToString();
                    initiative = (reaction + intuition);
                    break;
                case "Charisma": charisma = attributeValue; CharismaText.Text = charisma.ToString();
                    break;
                case "Willpower": willpower = attributeValue; WillpowerText.Text = willpower.ToString();
                    break;
                case "Edge": edge = attributeValue; EdgeText.Text = edge.ToString();
                    break;
                default: break;
            }
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            if (CharacterChanger(newChar.GetCharInfoI("CharID")) == true)
            {
                MessageBox.Show("Character Successfully Saved");
            }
            else
            {
                MessageBox.Show("Character Not Saved!");
            }
        }


        //saves the characterInfo to the character class
        private bool CharacterChanger(int charID)
        {
            try
            {
                ConnectShadowrun connShad = new ConnectShadowrun();

                name = charName.Text;

                connShad.SetCharacterInfoI(charID, "agility", agility);
                connShad.SetCharacterInfoI(charID, "body", body);
                connShad.SetCharacterInfoI(charID, "reaction", reaction);
                connShad.SetCharacterInfoI(charID, "strength", strength);
                connShad.SetCharacterInfoI(charID, "logic", logic);
                connShad.SetCharacterInfoI(charID, "intuition", intuition);
                connShad.SetCharacterInfoI(charID, "willpower", willpower);
                connShad.SetCharacterInfoI(charID, "charisma", charisma);
                connShad.SetCharacterInfoI(charID, "edge", edge);
                connShad.SetCharacterInfoI(charID, "magic", magic);
                connShad.SetCharacterInfoI(charID, "resonance", resonance);
                connShad.SetCharacterInfoI(charID, "essence", essence);
                connShad.SetCharacterInfoI(charID, "initiative", initiative);
                connShad.SetCharacterInfoI(charID, "charBP", bp);

                return true;
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }




    }
}
