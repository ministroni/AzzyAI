﻿// PVP_Tact.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the static class PVP_Tact, which is used to store
// the values of the PVP_Tact.lua configuration variables.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace AzzyAIConfig
{
    static class M_PVP_Tact
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
                _tacts.Add(new M_PvpTact("new"));
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
                    M_PvpTact t = new M_PvpTact(values[0]);

                    // Set the tactic properties
                    if (values[1] == "TACT_TANK")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_TANK;
                    }
                    else if (values[1] == "TACT_IGNORE")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_IGNORE;
                    }
                    else if (values[1] == "TACT_ATTACK_L")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_L;
                    }
                    else if (values[1] == "TACT_ATTACK_M")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_M;
                    }
                    else if (values[1] == "TACT_ATTACK_H")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_H;
                    }
                    else if (values[1] == "TACT_REACT_L")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_REACT_L;
                    }
                    else if (values[1] == "TACT_REACT_M")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_REACT_M;
                    }
                    else if (values[1] == "TACT_REACT_H")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_REACT_H;
                    }
                    else if (values[1] == "TACT_REACT_SELF")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_REACT_SELF;
                    }
                    else if (values[1] == "TACT_SNIPE_L")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_SNIPE_L;
                    }
                    else if (values[1] == "TACT_SNIPE_M")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_SNIPE_M;
                    }
                    else if (values[1] == "TACT_SNIPE_H")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_SNIPE_H;
                    }
                    else if (values[1] == "TACT_ATK_L_REACT_M")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATK_L_REACT_M;
                    }
                    else if (values[1] == "TACT_ATTACK_LAST")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_LAST;
                    }
                    else if (values[1] == "TACT_ATTACK_TOP")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_TOP;
                    }

                    if (values[2] == "SKILL_ALWAYS")
                    {
                        t.TACT_SKILL = TACT_SKILL.SKILL_ALWAYS;
                    }
                    else if (values[2] == "SKILL_NEVER")
                    {
                        t.TACT_SKILL = TACT_SKILL.SKILL_NEVER;
                    }

                    if (values[3] == "KITE_ALWAYS")
                    {
                        t.TACT_KITE = TACT_KITE.KITE_ALWAYS;
                    }
                    else if (values[3] == "KITE_REACT")
                    {
                        t.TACT_KITE = TACT_KITE.KITE_REACT;
                    }
                    else if (values[3] == "KITE_NEVER")
                    {
                        t.TACT_KITE = TACT_KITE.KITE_NEVER;
                    }

                    if (values[4] == "CAST_REACT")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT;
                    }
                    else if (values[4] == "CAST_PASSIVE")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_PASSIVE;
                    }
                    else if (values[4] == "CAST_REACT_MAIN")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_MAIN;
                    }
                    else if (values[4] == "CAST_REACT_MOB")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_MOB;
                    }
                    else if (values[4] == "CAST_REACT_DEBUFF")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_DEBUFF;
                    }
                    else if (values[4] == "CAST_REACT_MINION")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_MINION;
                    }
                    else if (values[4] == "CAST_REACT_ANY")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_ANY;
                    }
                    else if (values[4] == "CAST_REACT_CRASH")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_CRASH;
                    }
                    else if (values[4] == "CAST_REACT_PROVOKE")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_PROVOKE;
                    }
                    else if (values[4] == "CAST_REACT_SANDMAN")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_SANDMAN;
                    }
                    else if (values[4] == "CAST_REACT_FREEZE")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_FREEZE;
                    }
                    else if (values[4] == "CAST_REACT_DECAGI")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_DECAGI;
                    }
                    else if (values[4] == "CAST_REACT_LEXDIV")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_LEXDIV;
                    }


                    if (values[5] == "PUSH_NEVER")
                    {
                        t.TACT_PUSHBACK = TACT_PUSHBACK.PUSH_NEVER;
                    }
                    else if (values[5] == "PUSH_FRIEND")
                    {
                        t.TACT_PUSHBACK = TACT_PUSHBACK.PUSH_FRIEND;
                    }
                    else if (values[5] == "PUSH_SELF")
                    {
                        t.TACT_PUSHBACK = TACT_PUSHBACK.PUSH_SELF;
                    }

                    if (values[6] == "DEBUFF_NEVER")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_NEVER;
                    }
                    else if (values[6] == "DEBUFF_ANY_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_ANY_C;
                    }
                    else if (values[6] == "DEBUFF_CRASH_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_CRASH_C;
                    }
                    else if (values[6] == "DEBUFF_PROVOKE_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_PROVOKE_C;
                    }
                    else if (values[6] == "DEBUFF_SANDMAN_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_SANDMAN_C;
                    }
                    else if (values[6] == "DEBUFF_FREEZE_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_FREEZE_C;
                    }
                    else if (values[6] == "DEBUFF_DECAGI_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_DECAGI_C;
                    }
                    else if (values[6] == "DEBUFF_LEXDIV_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_LEXDIV_C;
                    }
                    else if (values[6] == "DEBUFF_ANY_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_ANY_A;
                    }
                    else if (values[6] == "DEBUFF_CRASH_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_CRASH_A;
                    }
                    else if (values[6] == "DEBUFF_PROVOKE_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_PROVOKE_A;
                    }
                    else if (values[6] == "DEBUFF_SANDMAN_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_SANDMAN_A;
                    }
                    else if (values[6] == "DEBUFF_FREEZE_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_FREEZE_A;
                    }
                    else if (values[6] == "DEBUFF_DECAGI_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_DECAGI_A;
                    }
                    else if (values[6] == "DEBUFF_LEXDIV_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_LEXDIV_A;
                    }

                    if (values[7] == "CLASS_BOTH")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_BOTH;
                    }
                    else if (values[7] == "CLASS_MOB")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_MOB;
                    }


                    if (values[8] == "RESCUE_NEVER")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_NEVER;
                    }
                    else if (values[8] == "RESCUE_FRIEND")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_FRIEND;
                    }
                    else if (values[8] == "RESCUE_RETAINER")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_RETAINER;
                    }
                    else if (values[8] == "RESCUE_SELF")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_SELF;
                    }
                    else if (values[8] == "RESCUE_OWNER")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_OWNER;
                    }
                    else if (values[8] == "RESCUE_ALL")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_ALL;
                    }

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
            foreach (M_PvpTact t in _tacts)
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


        static M_PvpTactCollection _tacts = new M_PvpTactCollection();
        public static M_PvpTactCollection Tactics
        {
            get { return _tacts; }
        }
    }
}