// PVP_Tact.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the static class PVP_Tact, which is used to store
// the values of the PVP_Tact.lua configuration variables.

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AzzyAIConfig
{
    static class PVP_Tact
    {
        public static void Load(string fileName)
        {
            // Read the file contents from fileName and split them into an array of lines
            string file = File.ReadAllText(fileName);
            string[] lines = file.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // Check if the file does not contain "MyPVPTact[0]"
            if (!Regex.IsMatch(file, "MyPVPTact\\[0\\]"))
            {
                // Add the default tactic to the tactics collection
                _tacts.Add(new PvpTact("0"));
            }

            // Run through each string object in the lines array
            foreach (string line in lines)
            {
                // Check if the current line contains "MyPVPTact[*]={*}"
                if (Regex.IsMatch(line, "MyPVPTact\\[(.*?)\\]=\\{(.*?)\\}"))
                {
                    // Get the set of values from the line
                    string[] values = Regex.Replace(line, "MyPVPTact\\[(.*?)\\]=\\{(.*?)\\}", "$1,$2").Split(',');

                    // Create a new tactic object
                    PvpTact t = new PvpTact(values[0]);

                    // Set the tactic properties
                    t.TACT_BASIC = (TACT_BASIC)Enum.Parse(typeof(TACT_BASIC), values[1]);
                    t.TACT_SKILL = (TACT_SKILL)Enum.Parse(typeof(TACT_SKILL), values[2]);
                    t.TACT_KITE = (TACT_KITE)Enum.Parse(typeof(TACT_KITE), values[3]);
                    t.TACT_CAST = (TACT_CAST)Enum.Parse(typeof(TACT_CAST), values[4]);
                    t.TACT_PUSHBACK = (TACT_PUSHBACK)Enum.Parse(typeof(TACT_PUSHBACK), values[5]);
                    t.TACT_DEBUFF = (TACT_DEBUFF)Enum.Parse(typeof(TACT_DEBUFF), values[6]);
                    t.TACT_SKILLCLASS = (TACT_SKILLCLASS)Enum.Parse(typeof(TACT_SKILLCLASS), values[7]);
                    t.TACT_RESCUE = (TACT_RESCUE)Enum.Parse(typeof(TACT_RESCUE), values[8]);

                    // Add the tactic to the tactics collection
                    _tacts.Add(t);
                }
            }

            // Output to the console "Loading complete."
            Program.WriteLine("Loading complete.");
        }


        public static void Save(string fileName)
        {
            // Read the file contents
            string file = File.ReadAllText(fileName);

            // Run through each tactic in the tactics collection
            foreach (PvpTact t in _tacts)
            {
                // Check if the file contents contains "MyPVPTact[t.ID]"
                if (Regex.IsMatch(file, string.Format("MyPVPTact\\[{0}\\]", t.ID)))
                {
                    // Update the tactic
                    file = Regex.Replace(file, string.Format("(MyPVPTact\\[{0}\\]=\\{{).*?(\\}})", t.ID), string.Format("$1{0},{1},{2},{3},{4},{5},{6},{7}$2", t.TACT_BASIC, t.TACT_SKILL, t.TACT_KITE, t.TACT_CAST, t.TACT_PUSHBACK, t.TACT_DEBUFF, t.TACT_SKILLCLASS, t.TACT_RESCUE));
                }
                // If the file does not contain the tactic
                else
                {
                    // Add it to the file
                    file = string.Format("{1}{0}MyPVPTact[{2}]={{{3},{4},{5},{6},{7},{8},{9},{10}}}", Environment.NewLine, file, t.ID, t.TACT_BASIC, t.TACT_SKILL, t.TACT_KITE, t.TACT_CAST, t.TACT_PUSHBACK, t.TACT_DEBUFF, t.TACT_SKILLCLASS, t.TACT_RESCUE);
                }
            }

            // Output to the console "Saving to file: fileName"
            Program.WriteLine("Saving to file: {0}", fileName);

            // Save the file
            File.WriteAllText(fileName, file);

            // Output to the console "Saving complete."
            Program.WriteLine("Saving complete.");
        }


        static PvpTactCollection _tacts = new PvpTactCollection();
        public static PvpTactCollection Tactics
        {
            get { return _tacts; }
        }
    }
}