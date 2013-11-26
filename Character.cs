using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ShadowrunCharacterMaker
{

    //the character class is meant to hold all character variables, essentially creating a c# profile of the character.            
    public class Character
    {

        public string name;
        public string race;
        //attributes
        public int buildPoints, agility, body, reaction, strength, logic, charisma, intuition, willpower, essence, edge, initiative, magic, resonance;

        //if true then one of the physical/mental attributes is at it's maximum value. Only one of these attributes can be maxed out
        public bool attributeMax;

        //no use for these yet, initiativePasses and nuyen will be used during the magic spell selecting and gear selecting phase
        public int initiativePasses, nuyen;

        //positive qualities
        public bool adept, ambidextrous, animalEmpathy, aptitude, astralChameleon, blandness, codeslinger, doubleJointed, erased, exceptionalAttribute,
            firstImpression, focusedConcentration, guts, highPainTolerance, homeGround, humanLooking, lucky, magician, magicResistance, mentorSpirit,
            murkyLink, mysticAdept, naturalHardening, naturalImmunity, photographicMemory, quickHealer, resistPathogens, spiritAffinity, technomancer,
            toughness, willToLive;

        public int adeptPowerPoints;


        //negative qualities
        public bool addiction, allergy, astralBeacon, badLuck, codeBlock, combatParalysis, elfPoser, gremlins, incompetent, infirm, lowPainTolerance,
            orkPoser, pacifist, scorched, sensitiveNeuralStructure, sensitiveSystem, simsenseVertigo, SINner, spiritBane, uncouth, uneducated,
            weakImmuneSystem;
        

        public void SetNewCharacterAttributes()
        {

        }

        //sets new character info, this might also be useful for changing race
        public void SetNewCharacterAttributes(NewCharacter newChar)
        {
            buildPoints = newChar.bp;
            agility = newChar.agility[0];
            strength = newChar.strength[0];
            reaction = newChar.reaction[0];
            body = newChar.body[0];
            logic = newChar.logic[0];
            intuition = newChar.intuition[0];
            willpower = newChar.willpower[0];
            charisma = newChar.charisma[0];
            edge = newChar.edge[0];
            initiative = newChar.reaction [0] + newChar.intuition[0];
            essence = newChar.essence;
            magic = newChar.magic;
            resonance = newChar.resonance;
            race = newChar.race;
        }

        //updates total buildpoints based on action made, true = spend points, false = acquire points
        //additionally tests for requirements that 0 buildpoints returns an error and spending > 200 buildpoints on attributes is an error
        public int BuildPointCost(int bp, int cost, bool trueIsSubtract, bool isAttribute = false)
        {
            int bptest;
            if (trueIsSubtract == true)
            {                
                bptest = bp - cost;
                if (bptest < 0)
                {
                    return 9999;
                }
                else
                {
                    return bp - cost;
                }
            }
            else if (trueIsSubtract == true & isAttribute == true)
            {                
                bptest = bp - cost;
                if (bptest < 200)
                {
                    return 9999;
                }
                else
                {
                    return bp - cost;
                }
            }
            else
            {
                return bp + cost;
            }
        }

        //serialize to XML
        public void SaveCharacter(Character character, String filename)
        {
            String fileNamed = filename + ".xml";
            XmlSerializer ser = new XmlSerializer(typeof(Character));
            StreamWriter streamy = new StreamWriter(fileNamed);
            ser.Serialize(streamy, character);
            streamy.Close();
        }

        //deserialize from XML
        public void LoadCharacter()
        {

        }
    }
}

