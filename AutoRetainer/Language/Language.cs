using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRetainer.Language
{
    public enum LanguageType
    {
        EN,
        CN
    }
    internal class Language
    {
        public static Language Instance { get; set; }
        public LanguageType LanType = LanguageType.EN;
        #region Gui
        public string Checkbox_Enable = "Enable {0}";
        public string Checkbox_AutoEnable = "Auto Enable";
        public string Checkbox_Multi = "Multi";
        public string DrawEnum_Language = "Language:";
        public string EzTabBar_Retainers = "Retainers";
        public string EzTabBar_MultiMode = "Multi Mode";
        public string EzTabBar_Statistics = "Statistics";
        public string EzTabBar_Settings = "Settings";
        public string EzTabBar_Beta = "Beta";
        public string EzTabBar_About = "About";
        public string EzTabBar_Log = "Log";
        public string EzTabBar_Debug = "Debug";
        #endregion
        #region Retainers
        public string Retainers = "Retainers";
        public string Text_DataNotReady = "Data Not Ready";
        public string Text_InventorySlots = "Inventory slots";
        public string Text_Ventures = "Ventures:";
        public string HelpMarker_Ventures = "The plugin will automatically disable itself at < 2 Ventures or inventory slots available.";
        public string TableSetupColumn_Name = "Name";
        public string TableSetupColumn_Venture = "Venture";
        public string TableSetupColumn_Interaction = "Interaction";
        public string Checkbox_RetainerName = "Retainer {0}";
        public string ImGuiLineCentered_Timeouts = "AYSButtonClear Interaction Timeouts";
        public string SmallButton_Timeouts = "Clear Interaction Timeouts";
        #endregion
        #region MultiModeUI
        public string TextWrapped_MultiMode = "Multi Mode requires Auto-afk option to be turned off";
        public string TextWrapped_Please = "Please use this feature within the sane limits. Keeping it on for abnormally large amount of time may attract unwanted attention.";
        public string CollapsingHeader_SetupGuide = "Setup Guide";
        public string TextWrapped_1 = "1. Log into each of your characters, assign necessary ventures to your retainers and enable retainers that you want to resend on each character.";
        public string TextWrapped_2 = "2. For each character, configure character index. Character index is position of your character on a screen where you select characters. If you only have one character per world, it's usually just 1.";
        public string TextWrapped_3 = "3. Ensure that your characters are in their home worlds and close to retainer bells, preferably in not crowded areas. No housing retainer bells. The suggested place is the inn.";
        public string TextWrapped_4 = "4. Characters that ran out of ventures or inventory space will be automatically excluded from rotation. You will need to reenable them once you clean up inventory and restock ventures.";
        public string TextWrapped_5 = "5. You may set up one character to be preferred. When no retainers have upcoming ventures in next 15 minutes, you will be relogged back on that character.";
        #endregion
    }
}
