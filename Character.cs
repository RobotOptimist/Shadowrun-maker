using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace ShadowrunCharacterMaker
{

    //the character class is meant to hold all character variables, essentially creating a c# profile of the character.            
    public class Character
    {

        public string name;
        public string race;

        //attributes
        public int buildPoints, attributeAccum, agility, body, reaction, strength, logic, charisma, intuition, willpower, essence, edge, initiative, magic, resonance;

        //if true then one of the physical/mental attributes is at it's maximum value. Only one of these attributes can be maxed out
        public bool attributeMax;
        
        //if greater than -1 then a race was selected and can be changed. If changed then the UI will refund build points
        public int raceRefundPossible = -1;

        //no use for these yet, initiativePasses and nuyen will be used during the magic spell selecting and gear selecting phase
        public int initiativePasses, nuyen;

        //positive qualities
        public bool adept, ambidextrous, animalEmpathy, aptitude, astralChameleon, blandness, codeslinger, doubleJointed, erasedCriminalSin, erasedAnySin, exceptionalAttribute,
            firstImpression, focusedConcentration, focusedConcentration2, guts, highPainTolerance, highPainTolerance2, highPainTolerance3, homeGround, humanLooking, lucky, magician,
            magicResistance, magicResistance2, magicResistance3, magicResistance4, mentorSpirit, murkyLink, mysticAdept, naturalHardening, naturalImmunity, naturalImmunity2, naturalImmunity3,
            photographicMemory, quickHealer, resistPathogens, resistPathogens2, spiritAffinity, technomancer, toughness, willToLive, willToLive2, willToLive3;

        //for adepts and mystic adepts. 
        public int adeptPowerPoints;


        //negative qualities
        public bool addiction, allergy, astralBeacon, badLuck, codeBlock, combatParalysis, elfPoser, gremlins, incompetent, infirm, lowPainTolerance,
            orkPoser, pacifist, scorched, sensitiveNeuralStructure, sensitiveSystem, simsenseVertigo, SINner, spiritBane, uncouth, uneducated,
            weakImmuneSystem;

        
        //agility skills
        public int archery, automatics, blades, clubs, escapeArtist, exoticMelee, exoticRanged, forgery, gunnery, gymnastics,
                heavyWeapons, infiltration, locksmith, longarms, palming, pistols, throwingWeapons, unarmedCombat;
        


        public List<string> listOfUnselectedPositiveQualities;
        public List<string> listOfSelectedPositiveQualities;
        

        public void SetNewCharacterAttributes()
        {

        }

        public void PopulateQualityList(ListBox listbox, List<string> list)
        {
            list = listbox.Items.OfType<string>().ToList();
        }


        public void RetrieveQualityList(ListBox listbox, List<string> list)
        {
            if (list != null)
            {
                listbox.Items.AddRange(list.ToArray());
            }
        }


        //sets new character info
        public void SetNewCharacterAttributes(NewCharacter newChar)
        {
                buildPoints = newChar.startingBP;
                BuildPointCost(this, newChar.bp, true);
                raceRefundPossible = newChar.bp;
                agility = newChar.agility[0];
                strength = newChar.strength[0];
                reaction = newChar.reaction[0];
                body = newChar.body[0];
                logic = newChar.logic[0];
                intuition = newChar.intuition[0];
                willpower = newChar.willpower[0];
                charisma = newChar.charisma[0];
                edge = newChar.edge[0];
                initiative = newChar.reaction[0] + newChar.intuition[0];
                essence = newChar.essence;
                magic = newChar.magic;
                resonance = newChar.resonance;
                race = newChar.race;
                attributeAccum = 200;
        }

        //calculates refund cost of attributes upon race switch
        public int AttributeRaceSwitch(NewCharacter newchar, Character character)
        {
            int refundAgility, refundStrength, refundReaction, refundBody, refundLogic, refundCharisma, refundIntuition, refundWillpower, refundEdge;
            if (newchar.created == true)
            {
                if (character.agility != newchar.agility[1])
                {
                    refundAgility = (character.agility - newchar.agility[0]) * 10;
                }
                else
                {
                    character.agility = character.agility - 1;
                    refundAgility = ((character.agility - newchar.agility[0]) * 10) + 25;
                }

                if (character.strength != newchar.strength[1])
                {
                    refundStrength = (character.strength - newchar.strength[0]) * 10;
                }
                else
                {
                    character.strength = character.strength - 1;
                    refundStrength = ((character.strength - newchar.strength[0]) * 10) + 25;
                }

                if (character.reaction != newchar.reaction[1])
                {
                    refundReaction = (character.reaction - newchar.reaction[0]) * 10;
                }
                else
                {
                    character.reaction = character.reaction - 1;
                    refundReaction = ((character.reaction - newchar.reaction[0]) * 10) + 25;
                }

                if (character.body != newchar.body[1])
                {
                    refundBody = (character.body - newchar.body[0]) * 10;
                }
                else
                {
                    character.body = character.body - 1;
                    refundBody = ((character.body - newchar.body[0]) * 10) + 25;
                }

                if (character.logic != newchar.logic[1])
                {
                    refundLogic = (character.logic - newchar.logic[0]) * 10;
                }
                else
                {
                    character.logic = character.logic - 1;
                    refundLogic = ((character.logic - newchar.logic[0]) * 10) + 25;
                }

                if (character.charisma != newchar.charisma[1])
                {
                    refundCharisma = (character.charisma - newchar.charisma[0]) * 10;
                }
                else
                {
                    character.charisma = character.charisma - 1;
                    refundCharisma = ((character.charisma - newchar.charisma[0]) * 10) + 25;
                }

                if (character.intuition != newchar.intuition[1])
                {
                    refundIntuition = (character.intuition - newchar.intuition[0]) * 10;
                }
                else
                {
                    character.intuition = character.intuition - 1;
                    refundIntuition = ((character.intuition - newchar.intuition[0]) * 10) + 25;
                }

                if (character.willpower != newchar.willpower[1])
                {
                    refundWillpower = (character.willpower - newchar.willpower[0]) * 10;
                }
                else
                {
                    character.willpower = character.willpower - 1;
                    refundWillpower = ((character.willpower - newchar.willpower[0]) * 10) + 25;
                }

                if (character.edge != newchar.edge[1])
                {
                    refundEdge = (character.edge - newchar.edge[0]) * 10;
                }
                else
                {
                    character.edge = character.edge - 1;
                    refundEdge = ((character.edge - newchar.edge[0]) * 10) + 25;
                }
            }
            else
            {
                refundAgility = 0;
                refundStrength = 0;
                refundReaction = 0;
                refundBody = 0;
                refundLogic = 0;
                refundCharisma = 0;
                refundIntuition = 0;
                refundWillpower = 0;
                refundEdge = 0;
            }
            return (refundAgility + refundStrength + refundReaction + refundBody + refundLogic + refundCharisma + 
                refundLogic + refundIntuition + refundWillpower + refundEdge + newchar.bp);
        }

        //qualities functions, toggles quality bools on and off
        public void Adept(bool activate)
        {

            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                adept = BPInsufficient(buildPoints, 5);
                magic = 1;
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                adept = false;
                magic = 0;
            }
        }

        public void Ambidextrous(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                ambidextrous = BPInsufficient(buildPoints, 5);
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                ambidextrous = false;
            }
        }

        public void AnimalEmpathy(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                animalEmpathy = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                animalEmpathy = false;
            }
        }

        public void Aptitude(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                aptitude = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                aptitude = false;
            }
        }

        public void AstralChameleon(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                astralChameleon = BPInsufficient(buildPoints, 5);
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                astralChameleon = false;
            }
        }

        public void Blandness(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                blandness = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                blandness = false;
            }
        }

        public void Codeslinger(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                codeslinger = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                codeslinger = false;
            }
        }

        public void DoubleJointed(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                doubleJointed = BPInsufficient(buildPoints, 5);
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                doubleJointed = false;
            }
            
        }

        public void ErasedCriminalSin(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                erasedCriminalSin = BPInsufficient(buildPoints, 5);
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                erasedCriminalSin = false;
            }
        }

        public void ErasedAnySin(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                erasedAnySin = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                erasedAnySin = false;
            }
        }

        public void ExceptionalAttribute(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 20, true);
                exceptionalAttribute = BPInsufficient(buildPoints, 20);
            }
            else
            {
                buildPoints = BuildPointCost(this, 20, false);
                exceptionalAttribute = false;
            }
        }

        public void FirstImpression(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                firstImpression = BPInsufficient(buildPoints, 5);
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                firstImpression = false;
            }
        }

        public void FocusedConcentration(bool activate, int rating)
        {
            if (activate == true && rating >=0 && magic > 0)
            {
                buildPoints = BuildPointCost(this, 10, true);
                focusedConcentration = BPInsufficient(buildPoints, 10);
                if (rating == 2)
                {
                    buildPoints = BuildPointCost(this, 10, true);
                    focusedConcentration2 = BPInsufficient(buildPoints, 10);
                }
                else if (rating == 1 && focusedConcentration2 == true)
                {
                    buildPoints = BuildPointCost(this, 10, false);
                    focusedConcentration2 = false;
                }
            }
            else
            {
                if (focusedConcentration2 == true)
                {
                    buildPoints = BuildPointCost(this, 10, false);
                    focusedConcentration2 = false;
                }
                buildPoints = BuildPointCost(this, 10, false);
                focusedConcentration = false;
            }
        }

        public void Guts(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                guts = BPInsufficient(buildPoints, 5);
            }
            else 
            {
                buildPoints = BuildPointCost(this, 5, false);
                guts = false;
            }
        }

        public void HighPainTolerance(bool activate, int rating = 1)
        {
            if (activate == true && rating >= 1)
            {
                buildPoints = BuildPointCost(this, 5, true);
                highPainTolerance = BPInsufficient(buildPoints, 5);
                if (rating >= 2)
                {
                    buildPoints = BuildPointCost(this, 5, true);
                    highPainTolerance2 = BPInsufficient(buildPoints, 5);
                    if (rating == 3)
                    {
                        buildPoints = BuildPointCost(this, 5, true);
                        highPainTolerance3 = BPInsufficient(buildPoints, 5);
                    }
                    else if (rating < 3 && highPainTolerance3 == true)
                    {
                        buildPoints = BuildPointCost(this, 5, false);
                        highPainTolerance3 = false;
                    }
                }
                else if (rating < 2 && highPainTolerance2 == true)
                {
                    if (highPainTolerance3 == true)
                    {
                        buildPoints = BuildPointCost(this, 5, false);
                        highPainTolerance3 = false;
                    }
                    buildPoints = BuildPointCost(this, 5, false);
                    highPainTolerance2 = false;
                }
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                highPainTolerance = false;
                if (highPainTolerance2 == true)
                {
                    if (highPainTolerance3 == true)
                    {
                        highPainTolerance3 = false;
                        buildPoints = BuildPointCost(this, 5, false);
                    }
                    highPainTolerance2 = false;
                    buildPoints = BuildPointCost(this, 5, false);
                }
            }
        }

        public void HomeGround(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                homeGround = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                homeGround = false;
            }
        }

        public void HumanLooking(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                humanLooking = BPInsufficient(buildPoints, 5);
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                humanLooking = false;
            }
        }

        public void Lucky(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 20, true);
                lucky = BPInsufficient(buildPoints, 20);
            }
            else
            {
                buildPoints = BuildPointCost(this, 20, false);
                lucky = false;
            }
        }

        public void Magician(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 15, true);
                magician = BPInsufficient(buildPoints, 15);
                magic = 1;
            }
            else
            {
                buildPoints = BuildPointCost(this, 15, false);
                magician = false;
                magic = 0;
            }
        }

        public void MagicResistance(bool activate, int rating)
        {
            if (activate == true && rating >= 1)
            {
                buildPoints = BuildPointCost(this, 5, true);
                magicResistance = BPInsufficient(buildPoints, 5);
                if (rating >= 2)
                {
                    buildPoints = BuildPointCost(this, 5, true);
                    magicResistance2 = BPInsufficient(buildPoints, 5);
                    if (rating >= 3)
                    {
                        buildPoints = BuildPointCost(this, 5, true);
                        magicResistance3 = BPInsufficient(buildPoints, 5);
                        if (rating == 4)
                        {
                            buildPoints = BuildPointCost(this, 5, true);
                            magicResistance4 = BPInsufficient(buildPoints, 5);
                        }
                        else if (rating < 4 && magicResistance4 == true)
                        {
                            buildPoints = BuildPointCost(this, 5, false);
                            magicResistance4 = false;
                        }
                    }
                    else if (rating < 3 && magicResistance3 == true)
                    {
                        if (magicResistance4 == true)
                        {
                            buildPoints = BuildPointCost(this, 5, false);
                            magicResistance4 = false;
                        }
                        buildPoints = BuildPointCost(this, 5, false);
                        magicResistance3 = false;
                    }
                }
                else if (rating < 2 && magicResistance2 == true)
                {
                    if (magicResistance3 == true)
                    {
                        if (magicResistance4 == true)
                        {
                            buildPoints = BuildPointCost(this, 5, false);
                            magicResistance4 = false;
                        }
                        buildPoints = BuildPointCost(this, 5, false);
                        magicResistance3 = false;
                    }
                    buildPoints = BuildPointCost(this, 5, false);
                    magicResistance2 = false;
                }
            }
            else
            {
                if (magicResistance2 == true)
                {
                    if (magicResistance3 == true)
                    {
                        if (magicResistance4 == true)
                        {
                            buildPoints = BuildPointCost(this, 5, false);
                            magicResistance4 = false;
                        }
                        buildPoints = BuildPointCost(this, 5, false);
                        magicResistance3 = false;
                    }
                    buildPoints = BuildPointCost(this, 5, false);
                    magicResistance2 = false;
                }
                buildPoints = BuildPointCost(this, 5, false);
                magicResistance = false;
            }

        }

        public void MentorSpirit(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                mentorSpirit = BPInsufficient(buildPoints, 5);
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                mentorSpirit = false;
            }
        }

        public void MurkyLink(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                murkyLink = BPInsufficient(buildPoints, 10);           
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                murkyLink = false;
            }
        }

        public void MysticAdept(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                mysticAdept = BPInsufficient(buildPoints, 10);
                magic = 1;
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                mysticAdept = false;
                magic = 0;
            }
        }

        public void NaturalHardening(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                naturalHardening = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                naturalHardening = false;
            }
        }

        public void NaturalImmunity(bool activate, int rating)
        {
            if (activate == true && rating >= 1)
            {
                buildPoints = BuildPointCost(this, 5, true);
                naturalImmunity = BPInsufficient(buildPoints, 5);
                if (rating == 2)
                {
                    buildPoints = BuildPointCost(this, 15, true);
                    naturalImmunity2 = BPInsufficient(buildPoints, 15);
                }
                else if (rating == 1 && naturalImmunity2 == true)
                {
                    buildPoints = BuildPointCost(this, 15, false);
                    naturalImmunity2 = false;
                }
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                naturalImmunity = false;
            }
        }

        public void PhotographicMemory(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                photographicMemory = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                photographicMemory = false;
            }
        }

        public void QuickHealer(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                quickHealer = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                quickHealer = false;
            }
        }

        public void ResistPathogens(bool activate, int rating)
        {
            if (activate == true && rating >= 1)
            {
                buildPoints = BuildPointCost(this, 5, true);
                resistPathogens = BPInsufficient(buildPoints, 5);
                if (rating == 2)
                {
                    buildPoints = BuildPointCost(this, 5, true);
                    resistPathogens2 = BPInsufficient(buildPoints, 5);
                }
                else if (rating < 2 && resistPathogens2 == true)
                {
                    buildPoints = BuildPointCost(this, 5, false);
                    resistPathogens2 = false;
                }
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                resistPathogens = false;
                if (resistPathogens2 == true)
                {
                    buildPoints = BuildPointCost(this, 5, false);
                    resistPathogens2 = false;
                }
            }
        }

        public void SpiritAffinity(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                spiritAffinity = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                spiritAffinity = false;
            }
        }

        public void Technomancer(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 5, true);
                technomancer = BPInsufficient(buildPoints, 5);
                resonance = 1;
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                technomancer = false;
                resonance = 0;
            }
        }

        public void Toughness(bool activate)
        {
            if (activate == true)
            {
                buildPoints = BuildPointCost(this, 10, true);
                toughness = BPInsufficient(buildPoints, 10);
            }
            else
            {
                buildPoints = BuildPointCost(this, 10, false);
                toughness = false;
            }
        }

        public void WillToLive(bool activate, int rating)
        {
            if(activate == true && rating >= 1)
            {
                buildPoints = BuildPointCost(this, 5, true);
                willToLive = BPInsufficient(buildPoints, 5);
                if (rating >= 2)
                {
                    buildPoints = BuildPointCost(this, 5, true);
                    willToLive2 = BPInsufficient(buildPoints, 5);
                    if (rating == 3)
                    {
                        buildPoints = BuildPointCost(this, 5, true);
                        willToLive3 = BPInsufficient(buildPoints, 5);
                    }
                    else if (rating < 3 && willToLive3 == true)
                    {
                        buildPoints = BuildPointCost(this, 5, false);
                        willToLive3 = false;
                    }
                }
                else if (rating < 2 && willToLive2 == true)
                {
                    buildPoints = BuildPointCost(this, 5, false);
                    willToLive2 = false;
                }
            }
            else
            {
                buildPoints = BuildPointCost(this, 5, false);
                willToLive = false;
                if (willToLive2 == true)
                {
                    buildPoints = BuildPointCost(this, 5, false);
                    willToLive2 = false;
                    if (willToLive3 == true)
                    {
                        buildPoints = BuildPointCost(this, 5, false);
                        willToLive3 = false;
                    }
                }
            }
        }
        
        //updates total buildpoints based on action made, true = spend points, false = acquire points
        //additionally tests for requirements that 0 buildpoints returns an error and spending > 200 buildpoints on attributes is an error
        public int BuildPointCost(Character character, int cost, bool trueIsSubtract, bool isAttribute = false)
        {            
            
            if (trueIsSubtract == true && isAttribute == false)
            {
                buildPoints = character.buildPoints - cost;
                return buildPoints;
            }
            else if (trueIsSubtract == true & isAttribute == true)
            {
                attributeAccum = character.attributeAccum - cost;
                character.buildPoints = character.buildPoints - cost;
                return attributeAccum;
                    
            }
            else if (trueIsSubtract == false & isAttribute == true)
            {
                character.buildPoints = character.buildPoints + cost;
                character.attributeAccum = character.attributeAccum + cost;
            }
            else
            {
                character.buildPoints = character.buildPoints + cost;
                return character.buildPoints;
            }
            return buildPoints;
        }

        private bool BPInsufficient(int bp, int bpcost)
        {
            if (bp <= 0)
            {
                MessageBox.Show("Insufficient Build Points");
                BuildPointCost(this, bpcost, false);
                return false;
            }
            else
            {
                return true;
            }

        }


        //serialize to XML
        public void SaveCharacter(Character character, String filename)
        {
            String fileNamed = filename;
            XmlSerializer ser = new XmlSerializer(typeof(Character));
            StreamWriter streamy = new StreamWriter(fileNamed);
            ser.Serialize(streamy, character);
            streamy.Close();
        }

        //deserialize from XML
        public Character LoadCharacter(Character character, String filename)
        {
            String fileNamed = filename;
            XmlSerializer reader = new XmlSerializer(typeof(Character));
            StreamReader file = new StreamReader(fileNamed);
            character = (Character)reader.Deserialize(file);
            return character;
        }
    }

    public class CharacterRaceSwitched
    {
        public int humanAgility, humanStrength, humanBody, humanReaction, humanLogic, humanCharisma, humanWillpower, humanIntuition, humanEdge, humanAttributeCost;
        public int orkAgility, orkStrength, orkBody, orkReaction, orkLogic, orkCharisma, orkWillpower, orkIntuition, orkEdge, orkAttributeCost;
        public int dwarfAgility, dwarfStrength, dwarfBody, dwarfReaction, dwarfLogic, dwarfCharisma, dwarfWillpower, dwarfIntuition, dwarfEdge, dwarfAttributeCost;
        public int elfAgility, elfStrength, elfBody, elfReaction, elfLogic, elfCharisma, elfWillpower, elfIntuition, elfEdge, elfAttributeCost;
        public int trollAgility, trollStrength, trollBody, trollReaction, trollLogic, trollCharisma, trollWillpower, trollIntuition, trollEdge, trollAttributeCost;
        public int humanAttributeAccum, orkAttributeAccum, dwarfAttributeAccum, elfAttributeAccum, trollAttributeAccum;
        public bool humanAttributeMax, orkAttributeMax, dwarfAttributeMax, elfAttributeMax, trollAttributeMax;
        public bool humanSwitch, orkSwitch, dwarfSwitch, elfSwitch, trollSwitch, costTest;

        public void StoreValues(Character character, NewCharacter newchar)
        {
            switch(character.race)
            {
                case "Human":
                    humanAgility = character.agility;
                    humanStrength = character.strength;
                    humanBody = character.body;
                    humanReaction = character.reaction;
                    humanLogic = character.logic;
                    humanCharisma = character.charisma;
                    humanWillpower = character.willpower;
                    humanIntuition = character.intuition;
                    humanEdge = character.edge;
                    humanAttributeAccum = character.attributeAccum;
                    humanAttributeCost = character.AttributeRaceSwitch(newchar, character);
                    character.BuildPointCost(character, humanAttributeCost, false, false);
                    humanAttributeMax = character.attributeMax;
                    humanSwitch = true;
                    break;
                case "Ork": 
                    orkAgility = character.agility;
                    orkStrength = character.strength;
                    orkBody = character.body;
                    orkReaction = character.reaction;
                    orkLogic = character.logic;
                    orkCharisma = character.charisma;
                    orkWillpower = character.willpower;
                    orkIntuition = character.intuition;
                    orkEdge = character.edge;
                    orkAttributeAccum = character.attributeAccum;
                    orkAttributeCost = character.AttributeRaceSwitch(newchar, character);
                    character.BuildPointCost(character, orkAttributeCost, false, false);
                    orkAttributeMax = character.attributeMax;
                    orkSwitch = true;
                    break;
                case "Dwarf": 
                    dwarfAgility = character.agility;
                    dwarfStrength = character.strength;
                    dwarfBody = character.body;
                    dwarfReaction = character.reaction;
                    dwarfLogic = character.logic;
                    dwarfCharisma = character.charisma;
                    dwarfWillpower = character.willpower;
                    dwarfIntuition = character.intuition;
                    dwarfEdge = character.edge;
                    dwarfAttributeAccum = character.attributeAccum;
                    dwarfAttributeCost = character.AttributeRaceSwitch(newchar, character);
                    character.BuildPointCost(character, dwarfAttributeCost, false, false);
                    dwarfAttributeMax = character.attributeMax;
                    dwarfSwitch = true;
                    break;
                case "Elf": 
                    elfAgility = character.agility;
                    elfStrength = character.strength;
                    elfBody = character.body;
                    elfReaction = character.reaction;
                    elfLogic = character.logic;
                    elfCharisma = character.charisma;
                    elfWillpower = character.willpower;
                    elfIntuition = character.intuition;
                    elfEdge = character.edge;
                    elfAttributeAccum = character.attributeAccum;
                    elfAttributeCost = character.AttributeRaceSwitch(newchar, character);
                    character.BuildPointCost(character, elfAttributeCost, false, false);
                    elfAttributeMax = character.attributeMax;
                    elfSwitch = true;
                    break;
                case "Troll": 
                    trollAgility = character.agility;
                    trollStrength = character.strength;
                    trollBody = character.body;
                    trollReaction = character.reaction;
                    trollLogic = character.logic;
                    trollCharisma = character.charisma;
                    trollWillpower = character.willpower;
                    trollIntuition = character.intuition;
                    trollEdge = character.edge;
                    trollAttributeAccum = character.attributeAccum;
                    trollAttributeCost = character.AttributeRaceSwitch(newchar, character);                    
                    character.BuildPointCost(character, trollAttributeCost, false, false);
                    trollAttributeMax = character.attributeMax;
                    trollSwitch = true;
                    break;
                default: break;
            }
        }

        public void GetRaceValues(Character character)
        {
            switch (character.race)
            {
                case "Human":
                    character.agility = humanAgility;
                    character.body = humanBody;
                    character.strength = humanStrength;
                    character.reaction = humanReaction;
                    character.logic = humanLogic;
                    character.charisma = humanCharisma;
                    character.willpower = humanWillpower;
                    character.intuition = humanIntuition;
                    character.edge = humanEdge;
                    character.attributeMax = humanAttributeMax;
                    character.attributeAccum = humanAttributeAccum; 
                    character.BuildPointCost(character, humanAttributeCost, true, false);
                    break;
                case "Ork": character.agility = orkAgility;
                    character.body = orkBody;
                    character.strength = orkStrength;
                    character.reaction = orkReaction;
                    character.logic = orkLogic;
                    character.charisma = orkCharisma;
                    character.willpower = orkWillpower;
                    character.intuition = orkIntuition;
                    character.edge = orkEdge;
                    character.attributeMax = orkAttributeMax;
                    character.attributeAccum = orkAttributeAccum;
                    character.BuildPointCost(character, orkAttributeCost, true, false);
                    break;
                case "Dwarf": 
                    character.agility   =   dwarfAgility;
                    character.body      =   dwarfBody;
                    character.strength  =   dwarfStrength;
                    character.reaction  =   dwarfReaction;
                    character.logic     =   dwarfLogic;
                    character.charisma  =   dwarfCharisma;
                    character.willpower =   dwarfWillpower;
                    character.intuition =   dwarfIntuition;
                    character.edge      =   dwarfEdge;
                    character.attributeMax = dwarfAttributeMax;
                    character.attributeAccum = dwarfAttributeAccum;
                    character.BuildPointCost(character, orkAttributeCost, true, false);
                    break;
                case "Elf": 
                    character.agility = elfAgility;
                    character.body = elfBody;
                    character.strength = elfStrength;
                    character.reaction = elfReaction;
                    character.logic = elfLogic;
                    character.charisma = elfCharisma;
                    character.willpower = elfWillpower;
                    character.intuition = elfIntuition;
                    character.edge = elfEdge;
                    character.attributeMax = elfAttributeMax;
                    character.attributeAccum = elfAttributeAccum;
                    character.BuildPointCost(character, elfAttributeCost, true, false);
                    break;
                case "Troll": 
                    character.agility   =   trollAgility;
                    character.body      =   trollBody;
                    character.strength  =   trollStrength;
                    character.reaction  =   trollReaction;
                    character.logic     =   trollLogic;
                    character.charisma  =   trollCharisma;
                    character.willpower =   trollWillpower;
                    character.intuition =   trollIntuition;
                    character.edge      =   trollEdge;
                    character.attributeMax = trollAttributeMax;
                    character.attributeAccum = trollAttributeAccum;
                    character.BuildPointCost(character, trollAttributeCost, true, false);
                    break;
                default: break;
            }
        }
    }
}

