using System;

namespace AzzyAIConfig
{
    public enum HomunculusDisplayType
    {
        Lif = 1,
        Amistr = 2,
        Filir = 3,
        Vanilmirth = 4,
        All = -1
    }

    public enum SHomunculusDisplayType : sbyte
    {
        None = 0,
        Eira = 1,
        Bayeri = 2,
        Sera = 3,
        Dieter = 4,
        Eleanor = 5,
        All = -1
    }

    static class RelevantHomOptions
    {
        public static bool IsOptionRelevant(string optionName, HomunculusDisplayType oldHomunculusType, SHomunculusDisplayType sHomunculusType)
        {
            return IsOptionRelevant(optionName, oldHomunculusType) && IsOptionRelevant(optionName, sHomunculusType);
        }

        public static bool IsOptionRelevant(string optionName, HomunculusDisplayType oldHomunculusType)
        {
            switch (optionName)
            {
                case "LifEscapeLevel":
                    return oldHomunculusType == HomunculusDisplayType.Lif;

                case "UseCastleRoute":
                case "UseCastleDefend":
                case "CastleDefendThreshold":
                case "UseSmartBulwark":
                case "AmiBulwarkLevel":
                    return oldHomunculusType == HomunculusDisplayType.Amistr;
                case "FilirFlitLevel":
                case "FilirAccelLevel":
                    return oldHomunculusType == HomunculusDisplayType.Filir;

                case "HealOwnerHP":
                case "UseAutoHeal":
                    return oldHomunculusType == HomunculusDisplayType.Lif || oldHomunculusType == HomunculusDisplayType.Vanilmirth;
                    
                case "HealSelfHP":
                    return oldHomunculusType == HomunculusDisplayType.Vanilmirth;
            }

            return true;
        }
        public static bool IsOptionRelevant(string optionName, SHomunculusDisplayType sHomunculusType)
        {
            if(sHomunculusType == SHomunculusDisplayType.All)
            {
                return true;
            }

            switch (optionName)
            {
                case "UseEiraXenoSlasher":
                case "UseEiraSilentBreeze":
                case "EiraXenoSlasherLevel":
                case "EiraSilentBreezeLevel":
                case "UseEiraEraseCutter":
                case "EiraEraseCutterLevel":
                case "UseEiraOveredBoost":
                case "HealOwnerHP":
                case "UseAutoHeal":
                case "HealOwnerBreeze":
                    return sHomunculusType == SHomunculusDisplayType.Eira;

                case "UseBayeriStahlHorn":
                case "BayeriStahlHornLevel":
                case "UseBayeriHailegeStar":
                case "BayeriHailegeStarLevel":
                case "UseBayeriAngriffModus":
                case "UseBayeriGoldenPherze":
                case "UseBayeriSteinWand":
                case "BayeriSteinWandLevel":
                case "UseSteinWandSelfMob":
                case "UseSteinWandOwnerMob":
                case "UseSteinWandTele":
                case "SteinWandTelePause":
                    return sHomunculusType == SHomunculusDisplayType.Bayeri;

                case "PainkillerFriends":
                case "PainkillerFriendsSave":
                case "UseSeraParalyze":
                case "SeraParalyzeLevel":
                case "UseSeraPoisonMist":
                case "SeraPoisonMistLevel":
                case "UseSeraCallLegion":
                case "SeraCallLegionLevel":
                case "UseSeraPainkiller":
                case "PoisonMistMode":
                    return sHomunculusType == SHomunculusDisplayType.Sera;

                case "UseDieterLavaSlide":
                case "UseDieterVolcanicAsh":
                case "DieterLavaSlideLevel":
                case "UseDieterMagmaFlow":
                case "UseDieterGraniticArmor":
                case "UseDieterPyroclastic":
                case "LavaSlideMode":
                    return sHomunculusType == SHomunculusDisplayType.Dieter;

                case "AutoComboMode":
                case "AutoComboSpheres":
                case "UseEleanorSonicClaw":
                case "EleanorDoNotSwitchMode":
                case "EleanorSonicClawLevel":
                case "EleanorSilverveinLevel":
                case "EleanorMidnightLevel":
                    return sHomunculusType == SHomunculusDisplayType.Eleanor;
            }

            return true;
        }
    }
}
