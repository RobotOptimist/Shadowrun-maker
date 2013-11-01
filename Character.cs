using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;

namespace ShadowrunCharacterMaker
{   //the character class is meant to hold all character variables, essentially creating a c# profile of the character.
    //It's meant to be somewhat of a clone of the SQL information for the character
    class Character
    {
        
        private string name;
        private string race;
        private int buildPoints;
        private int agility;
        private int body;
        private int reaction;
        private int strength;
        private int logic;
        private int charisma;
        private int intuition;
        private int willpower;
        private int essence;
        private int edge;
        private int initiative;
        private int magic;
        private int resonance;
        private int characterID;


        //updates total buildpoints based on action made, true = spend points, false = acquire points
        //additionally tests for requirements that 0 buildpoints returns an error and spending > 200 buildpoints on attributes is an error
        public int BuildPointCost(int bp, int cost, bool mod, bool isAttribute = false)
        {
            if (mod == true)
            {
                int bptest;
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
            else if (mod == true & isAttribute == true)
            {
                int bptest;
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

        //loads info for the character from the characters table in sql
        public void SetAttribute(int charID)
        {
            ConnectShadowrun conShad = new ConnectShadowrun();
            buildPoints = (int)conShad.GetCharacterInfoI("CharBP", charID);
            agility = (int)conShad.GetCharacterInfoI("Agility", charID);
            body = (int)conShad.GetCharacterInfoI("Body", charID);
            reaction = (int)conShad.GetCharacterInfoI("Reaction", charID);
            strength = (int)conShad.GetCharacterInfoI("Strength", charID);
            logic = (int)conShad.GetCharacterInfoI("Logic", charID);
            charisma = (int)conShad.GetCharacterInfoI("Charisma", charID);
            intuition = (int)conShad.GetCharacterInfoI("Intuition", charID);
            willpower = (int)conShad.GetCharacterInfoI("Willpower", charID);
            edge = (int)conShad.GetCharacterInfoI("Edge", charID);
            initiative = (int)conShad.GetCharacterInfoI("Initiative", charID);
            magic = (int)conShad.GetCharacterInfoI("Magic", charID);
            resonance = (int)conShad.GetCharacterInfoI("Resonance", charID);
            essence = (int)conShad.GetCharacterInfoI("Essence", charID);
            characterID = charID;
            name = conShad.GetCharacterInfoS("CharName", charID);
            race = conShad.GetCharacterInfoS("CharRace", charID);
        }


        //retrieves character data for the integer datatype
        public int GetCharInfoI(string charInfo)
        {
            switch (charInfo)
            {
                case "BP": return buildPoints;          
                case "Agility": return agility;                    
                case "Body": return body;
                case "Reaction": return reaction;
                case "Strength": return strength;
                case "Logic": return logic;
                case "Intuition": return intuition;
                case "Charisma": return charisma;
                case "Willpower": return willpower;
                case "Edge": return edge;
                case "Initiative": return initiative;
                case "Magic": return magic;
                case "Resonance": return resonance;
                case "CharID": return characterID;
                case "Essence": return essence;
                default: return 0;

            }
        }

        //gets character info for a string datatype
        public string GetCharacterInfoS(string charinfo)
        {
            switch (charinfo)
            {
                case "Name": return name;
                case "Race": return race;
                default: return "Error";
            }
        }

        //sets character info for integer datatype I don't think I've used this at all yet
        public void SetCharacterInfoI(string charInfo, int newValue)
        {
            switch (charInfo)
            {
                case "BP": buildPoints = newValue;
                    break;
                case "Agility": agility = newValue;
                    break;
                case "Body": body = newValue;
                    break;
                case "Reaction": reaction = newValue;
                    break;
                case "Strength": strength = newValue;
                    break;
                case "Logic": logic = newValue;
                    break;
                case "Intuition": intuition = newValue;
                    break;
                case "Charisma": charisma = newValue;
                    break;
                case "Willpower": willpower = newValue;
                    break;
                case "Edge": edge = newValue;
                    break;
                case "Initiative": initiative = newValue;
                    break;
                case "Magic": magic = newValue;
                    break;
                case "Resonance": resonance = newValue;
                    break;
                default: break;

            }
        }
        //sets character info for string datatype I don't think I've used this at all yet
        public void SetCharacterInfoS(string charInfo, string newValue)
        {
            switch (charInfo)
            {
                case "Name": name = newValue;
                    break;
                case "Race": race = newValue;
                    break;
                default: break;
            }
        }
      
    }
    //the ConnectShadowrun class handles all calls to SQL to find info, update, and insert
    class ConnectShadowrun
    {
        SqlConnection con;
        SqlCommand cmd;

        public string constr = @"Data Source=MACIVOR-PC\SQLEXPRESS;Initial Catalog=Shadowrun;Integrated Security=True";

        //creates a character in the db
        public int InsertCharacterName(string Name, string Race)
        {
            string insertCharStatement;
            string getCharID;
            int charID;
            con = new SqlConnection();
            con.ConnectionString = constr;
            con.Open();
                insertCharStatement = "dbo.CreateCharacter";
                cmd = new SqlCommand(insertCharStatement, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@race", Race);
                cmd.ExecuteNonQuery();
                cmd.CommandType = System.Data.CommandType.Text;
                getCharID = "select max(charid) from Characters";
                cmd.CommandText = getCharID;
                charID = (int)cmd.ExecuteScalar();
            con.Close();
            return charID;
        }

        //gets string info from the db (characters table only)
        public string GetCharacterInfoS(string Name, int charID)
        {
            string retrieveCharData;
            string giveData;
            con = new SqlConnection();
            con.ConnectionString = constr;
            con.Open();
                retrieveCharData = "select " + Name + " from Characters where charid = " + charID;
                cmd = new SqlCommand(retrieveCharData, con);
                giveData = cmd.ExecuteScalar().ToString();
            con.Close();

            return giveData;
        }

        //gets numbers from the db (characters table only)
        public int GetCharacterInfoI(string Name, int charID)
        {
            string retrieveCharData;
            int giveData;
            con = new SqlConnection();
            con.ConnectionString = constr;
            con.Open();
            retrieveCharData = "select  " + Name + " from Characters where charid = " + charID;
            cmd = new SqlCommand(retrieveCharData, con);
            giveData = (int)cmd.ExecuteScalar();
            con.Close();

            return giveData;
        }
        //loads a character charID
        public object FindCharacterName(string Name)
        {
            object charID;
            string findCharacterName;
            con = new SqlConnection();
            con.ConnectionString = constr;
            con.Open();
            findCharacterName = "select charid from Characters where CharName = '" + Name + "'";
            cmd = new SqlCommand(findCharacterName, con);
            charID = cmd.ExecuteScalar();
            return charID;
        }

        //stub, will eventually change race and class
        public void SetCharacterInfoS(int charID, string newName)
        {
        }

        //changes integers in the db on the characters table. 
        public void SetCharacterInfoI(int charID, string Name, int newValue)
        {
            string updateCharacterInfo;
            con = new SqlConnection();
            con.ConnectionString = constr;
            con.Open();
            updateCharacterInfo = "update Characters set " + Name + " = " + newValue + " where charID = " + charID;
            cmd = new SqlCommand(updateCharacterInfo, con);
            cmd.ExecuteNonQuery();
        }
    }

}
