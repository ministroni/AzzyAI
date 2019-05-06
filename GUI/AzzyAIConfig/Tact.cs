// Tact.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the Tact class, which is used to hold data for a
// tactics object, and enumerations for TACT_BASIC, TACT_KITE, TACT_CAST,
// TACT_PUSHBACK, TACT_SKILLCLASS, TACT_RESCUE, and TACT_KS to restrict values
// for each data type.

using System;
using System.ComponentModel;

namespace AzzyAIConfig
{
    enum TACT_BASIC : sbyte
    {
        [Description("Tank Mob|Tank until enough monsters to use AoE on them")]
        TACT_TANKMOB = -2,
        [Description("Tank|Hit monster once, and then hold it until something kills it")]
        TACT_TANK = -1,
        [Description("Ignore|Do not attack the monster, at all")]
        TACT_IGNORE = 0,
        [Description("Attack (low)|Seek out and attack this monster, low priority, do not give higher priority if attacking")]
        TACT_ATTACK_L = 2,
        [Description("Attack (medium)|Seek out and attack this monster, medium priority")]
        TACT_ATTACK_M = 3,
        [Description("Attack (high)|Seek out and attack this monster, high priority")]
        TACT_ATTACK_H = 4,
        [Description("React (low)|React to this monster when self/owner/friend attacked, low priority")]
        TACT_REACT_L = 5,
        [Description("React (medium)|React to this monster when self/owner/friend attacked, medium priority")]
        TACT_REACT_M = 7,
        [Description("React (high)|React to this monster when self/owner/friend attacked, high priority")]
        TACT_REACT_H = 8,
        [Description("React (self)|React to this monster when self attacked only")]
        TACT_REACT_SELF = 9,
        [Description("Snipe (low)|Attempt to 1-shot this monster with bolts, even while attacking other monsters, low priority")]
        TACT_SNIPE_L = 10,
        [Description("Snipe (medium)|Attempt to 1-shot this monster with bolts, even while attacking other monsters, medium priority")]
        TACT_SNIPE_M = 11,
        [Description("Snipe (high)|Attempt to 1-shot this monster with bolts, even while attacking other monsters, high priority")]
        TACT_SNIPE_H = 12,
        [Description("Attack (low) React (medium)")]
        TACT_ATK_L_REACT_M = 13,
        [Description("Attack (top)")]
        TACT_ATTACK_LAST = 14,
        [Description("Attack (last)")]
        TACT_ATTACK_TOP = 15,
    }

    enum TACT_KITE : sbyte
    {
        [Description("Always|always kite from this monster - recommended for aggressive monsters")]
        KITE_ALWAYS = 2,
        [Description("React|kite from this kind of monster only if attacked")]
        KITE_REACT = 1,
        [Description("Never|ever kite from this kind of monster")]
        KITE_NEVER = 0
    }

    enum TACT_CAST : sbyte
    {
        [Description("React")]
        CAST_REACT = 1,
        [Description("Passive")]
        CAST_PASSIVE = 0,
        [Description("Main")]
        CAST_REACT_MAIN = 10,
        [Description("Homunculus S Skills")]
        CAST_REACT_S = 11,
        [Description("AoE attacks")]
        CAST_REACT_MOB = 12,
        [Description("Debuff")]
        CAST_REACT_DEBUFF = 13,
        [Description("Summon Minions")]
        CAST_REACT_MINION = 15,
        [Description("Any Skill")]
        CAST_REACT_ANY = 9,
        [Description("Crash")]
        CAST_REACT_CRASH = 100,
        [Description("Provoke")]
        CAST_REACT_PROVOKE = 101,
        [Description("Sandman")]
        CAST_REACT_SANDMAN = 102,
        [Description("Freeze Trap")]
        CAST_REACT_FREEZE = 103,
        [Description("Decrease Agi")]
        CAST_REACT_DECAGI = 104,
        [Description("Lex Divinia")]
        CAST_REACT_LEXDIV = 105,
        [Description("Breeze")]
        CAST_REACT_BREEZE =106
    }

    enum TACT_DEBUFF : sbyte
    {
        [Description("Never")]
        DEBUFF_NEVER = 0,
        [Description("Any")]
        DEBUFF_ANY_C = -1,
        [Description("Crash")]
        DEBUFF_CRASH_C = 1,
        [Description("Provoke")]
        DEBUFF_PROVOKE_C = 2,
        [Description("Sandman")]
        DEBUFF_SANDMAN_C = 3,
        [Description("Freeze Trap")]
        DEBUFF_FREEZE_C = 4,
        [Description("Decrease Agi")]
        DEBUFF_DECAGI_C = 5,
        [Description("Lex Divinia")]
        DEBUFF_LEXDIV_C = 6,
        [Description("REPLACE|REPLACE")]
        DEBUFF_ANY_A = 7,
        [Description("REPLACE|REPLACE")]
        DEBUFF_CRASH_A = 8,
        [Description("REPLACE|REPLACE")]
        DEBUFF_PROVOKE_A = 9,
        [Description("REPLACE|REPLACE")]
        DEBUFF_SANDMAN_A = 10,
        [Description("REPLACE|REPLACE")]
        DEBUFF_FREEZE_A = 11,
        [Description("REPLACE|REPLACE")]
        DEBUFF_DECAGI_A = 12,
        [Description("REPLACE|REPLACE")]
        DEBUFF_LEXDIV_A = 13,
        [Description("REPLACE|REPLACE")]
        DEBUFF_BREEZE_C = 14,
        [Description("Breeze")]
        DEBUFF_BREEZE_A = 15,
        [Description("REPLACE|REPLACE")]
        DEBUFF_ASH_C = 16,
        [Description("Ash")]
        DEBUFF_ASH_A=17
    }
    enum TACT_PUSHBACK : sbyte
    {
        [Description("Never")]
        PUSH_NEVER = 0,
        [Description("Self")]
        PUSH_SELF = 1,
        [Description("Friend")]
        PUSH_FRIEND = 2
    }

    enum TACT_SKILLCLASS : sbyte
    {
        [Description("Any Skill")]
        CLASS_BOTH = -1,
        [Description("Pre-Homunculus S Skills")]
        CLASS_OLD = 0,
        [Description("Homunculus S Skills")]
        CLASS_S = 1,
        [Description("AoE attacks")]
        CLASS_MOB = 2,
        [Description("Combo (first skill)")]
        CLASS_COMBO_1 = 3,
        [Description("Combo (full combos)")]
        CLASS_COMBO_2 = 4,
        [Description("Summon Minions")]
        CLASS_MINION = 5,
        [Description("Grapple (Tinder Breaker)")]
        CLASS_GRAPPLE = 6,
        [Description("Grapple (CBC)")]
        CLASS_GRAPPLE_1 = 7,
        [Description("Grapple (EQC)")]
        CLASS_GRAPPLE_2 = 8,
        [Description("Minions + Pre-S skills")]
        CLASS_MIN_OLD = 9,
        [Description("Minions + Homunculus S skills")]
        CLASS_MIN_S = 10
    }

    enum TACT_RESCUE : sbyte
    {
        [Description("Never")]
        RESCUE_NEVER = 0,
        [Description("Friend")]
        RESCUE_FRIEND = 1,
        [Description("Owner's homunculus")]
        RESCUE_RETAINER = 2,
        [Description("Self (mercenary)")]
        RESCUE_SELF = 3,
        [Description("Owner")]
        RESCUE_OWNER = 4,
        [Description("All of the above")]
        RESCUE_ALL = 5
    }

    enum TACT_KS : sbyte
    {
        [Description("Polite")]
        KS_POLITE = -1,
        [Description("Never")]
        KS_NEVER = 0,
        [Description("Always")]
        KS_ALWAYS = 1
    }

    enum TACT_SKILL : sbyte
    {
        [Description("Always")]
        SKILL_ALWAYS = 0,
        [Description("Never")]
        SKILL_NEVER = 1
        // todo: number of times
    }

    enum TACT_SNIPE : sbyte
    {
        [Description("Ok")]
        SNIPE_OK = 1,
        [Description("Disable")]
        SNIPE_DISABLE = 0
    }
    enum TACT_CHASE : sbyte
    {
        [Description("Normal")]
        CHASE_NORMAL = -1,
        [Description("Always")]
        CHASE_ALWAYS = 0,
        [Description("Never")]
        CHASE_NEVER = 1,
        [Description("Clever|Pause for SP")]
        CHASE_CLEVER = 2
    }

    class Tact : IComparable<Tact>
    {
        public Tact(int id, string name = "", TACT_BASIC basic = TACT_BASIC.TACT_IGNORE, TACT_SKILL skill = TACT_SKILL.SKILL_ALWAYS, TACT_KITE kite = TACT_KITE.KITE_NEVER, TACT_CAST cast = TACT_CAST.CAST_REACT, TACT_PUSHBACK push = TACT_PUSHBACK.PUSH_NEVER, TACT_DEBUFF debuff = TACT_DEBUFF.DEBUFF_NEVER, TACT_SKILLCLASS sclass = TACT_SKILLCLASS.CLASS_BOTH, TACT_RESCUE rescue = TACT_RESCUE.RESCUE_NEVER, int sp = -1, TACT_SNIPE snipe = TACT_SNIPE.SNIPE_OK, TACT_KS ffa = TACT_KS.KS_NEVER, decimal weight = 1, TACT_CHASE chase = TACT_CHASE.CHASE_NORMAL)
        {
            // Set the tactic variables
            _id = id;
            _basic = basic;
            _skill = skill;
            _kite = kite;
            _cast = cast;
            _push = push;
            _debuff = debuff;
            _sclass = sclass;
            _rescue = rescue; 
            _sp = sp;
            _snipe = snipe;
            _ffa = ffa;
            _weight = weight;
            _chase = chase;
            _name = name;
        }

        public override string ToString()
        {
            // Override the ToString method to return the name of this tactic
            return Name;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Tact other)
        {
            // Compare the ID of this tactic to the ID of the other tactic
            return ID.CompareTo(other.ID);
        }

        public static bool operator ==(Tact obj1, Tact obj2)
        {
            // Check if the first tactic ID is equal to the second tactic ID
            if (obj1.ID == obj2.ID)
            {
                // Return true
                return true;
            }

            // Return false
            return false;
        }

        public static bool operator !=(Tact obj1, Tact obj2)
        {
            // Check if the first tactic is equal to the second tactic
            if (obj1 == obj2)
            {
                // Return false
                return false;
            }

            // Return true
            return true;
        }

        int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        TACT_BASIC _basic = TACT_BASIC.TACT_IGNORE;
        public TACT_BASIC TACT_BASIC
        {
            get { return _basic; }
            set { _basic = value; }
        }

        private TACT_SKILL _skill = TACT_SKILL.SKILL_ALWAYS;
        public TACT_SKILL TACT_SKILL
        {
            get { return _skill; }
            set { _skill = value; }
        }

        TACT_KITE _kite = TACT_KITE.KITE_NEVER;
        public TACT_KITE TACT_KITE
        {
            get { return _kite; }
            set { _kite = value; }
        }

        TACT_CAST _cast = TACT_CAST.CAST_PASSIVE;
        public TACT_CAST TACT_CAST
        {
            get { return _cast; }
            set { _cast = value; }
        }

        TACT_PUSHBACK _push = TACT_PUSHBACK.PUSH_NEVER;
        public TACT_PUSHBACK TACT_PUSHBACK
        {
            get { return _push; }
            set { _push = value; }
        }

        TACT_DEBUFF _debuff = TACT_DEBUFF.DEBUFF_NEVER;
        public TACT_DEBUFF TACT_DEBUFF
        {
            get { return _debuff; }
            set { _debuff = value; }
        }

        TACT_SKILLCLASS _sclass = TACT_SKILLCLASS.CLASS_BOTH;
        public TACT_SKILLCLASS TACT_SKILLCLASS
        {
            get { return _sclass; }
            set { _sclass = value; }
        }

        TACT_RESCUE _rescue = TACT_RESCUE.RESCUE_RETAINER;
        public TACT_RESCUE TACT_RESCUE
        {
            get { return _rescue; }
            set { _rescue = value; }
        }

        int _sp = -1;
        public int TACT_SP
        {
            get { return _sp; }
            set { _sp = value; }
        }

        TACT_SNIPE _snipe = TACT_SNIPE.SNIPE_OK;
        public TACT_SNIPE TACT_SNIPE
        {
            get { return _snipe; }
            set { _snipe = value; }
        }

        TACT_KS _ffa = TACT_KS.KS_NEVER;
        public TACT_KS TACT_KS
        {
            get { return _ffa; }
            set { _ffa = value; }
        }

        decimal _weight = 1;
        public decimal TACT_WEIGHT
        {
            get { return _weight; }
            set { _weight = value; }
        }

        TACT_CHASE _chase = TACT_CHASE.CHASE_NORMAL;
        public TACT_CHASE TACT_CHASE
        {
            get { return _chase; }
            set { _chase = value; }
        }

        string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}