using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        public string CollapsingHeader_Configuration = "Configuration";
        public string Checkbox_MultiWaitForAll = "Wait for all retainers to be done before logging into character";
        public string DragInt_AdvanceTimer = "Relog in advance, seconds";
        public string Checkbox_Synchronize = "Synchronize retainers (one time)";
        public string HelpMarker_Synchronize = "If this setting is on, plugin will wait until all enabled retainers have done their ventures. After that this setting will be disabled automatically and all characters will be processed.";
        public string Notify_Error_Setcharacterindexfirst = "Set character index first";
        public string Button_Relog = "Relog";
        public string Notify_Warning_Preferredcharacterhasbeenreset = "Preferred character has been reset";
        public string Notify_Success_Relogging = "Relogging...";
        public string CollapsingHeader_Characterindex = "Character {0}";
        public string TextV_Characterindex = "Character index:";
        #endregion
        #region Setting
        public string Setting_Settings = "Settings";
        public string Setting_AutoEnableDisable = "Semi-automatic Mode";
        public string Setting_AutoEnableDisable_HelpMarker = "Automatically enables the plugin on Summoning Bell interaction. You can hold down the SHIFT key to disable this behavior.";
        public string Setting_TurboMode = "Turbo Mode";
        public string Setting_TurboMode_HelpMarker = "Rapidly collect rewards and despatch retainers on new ventures. Only works in semi-automatic mode/with manual player interaction.";
        public string Setting_UnsyncCompensation = "Time Desynchronization Compensation";
        public string Setting_UnsyncCompensation_HelpMarker = "Additional amount of seconds that will be subtracted from venture ending time to help mitigate possible issues of time desynchronization between the game and your PC. ";
        public string Setting_Speed = "Interaction Speed (%)";
        public string Setting_Speed_HelpMarker = "The higher this value is the faster plugin will operate retainers. When dealing with low FPS or high latency you may want to decrease this value. If you want the plugin to operate faster you may increase it.";
        public string Setting_AnonymiseRetainers = "Anonymise Retainers";
        public string Setting_AnonymiseRetainers_HelpMarker = "Retainer names will be redacted from general UI elements. They will not be hidden in debug menus and plugin logs however. While this option is on, character and retainer numbers are not guaranteed to be equal in different sections of a plugin (for example, retainer 1 in retainers view is not guaranteed to be the same retainer as in statistics view).";
        public string Setting_Operation = "Operation";
        #endregion
    }
}
