﻿using AutoRetainer.GcHandin;
using Dalamud.Interface.Components;
using ECommons.Configuration;
using ECommons.MathHelpers;
using PInvoke;
using PunishLib.ImGuiMethods;
using System.Windows.Forms;

namespace AutoRetainer.UI;

internal static class Settings
{
    internal static void Draw()
    {
        ImGuiHelpers.ScaledDummy(5f);
        InfoBox.DrawBox(Language.Language.Instance.Setting_Settings, delegate
        {
            ImGui.Checkbox(Language.Language.Instance.Setting_AutoEnableDisable, ref P.config.AutoEnableDisable);
            ImGuiComponents.HelpMarker(Language.Language.Instance.Setting_AutoEnableDisable_HelpMarker);
            ImGui.Checkbox(Language.Language.Instance.Setting_TurboMode, ref P.config.TurboMode);
            ImGuiComponents.HelpMarker(Language.Language.Instance.Setting_TurboMode_HelpMarker);
            ImGui.SetNextItemWidth(100f);
            ImGui.SliderInt(Language.Language.Instance.Setting_UnsyncCompensation, ref P.config.UnsyncCompensation.ValidateRange(-60, 0), -10, 0);
            ImGuiComponents.HelpMarker(Language.Language.Instance.Setting_UnsyncCompensation_HelpMarker);
            ImGui.SetNextItemWidth(100f);
            ImGui.SliderInt(Language.Language.Instance.Setting_TurboMode, ref P.config.Speed.ValidateRange(10, 1000), 10, 300);
            ImGuiComponents.HelpMarker(Language.Language.Instance.Setting_TurboMode_HelpMarker);
            ImGui.Checkbox(Language.Language.Instance.Setting_AnonymiseRetainers, ref P.config.NoNames);
            ImGuiComponents.HelpMarker(Language.Language.Instance.Setting_AnonymiseRetainers_HelpMarker);
        });
        InfoBox.DrawBox("Operation", delegate
        {
            if (ImGui.RadioButton("Assign + Reassign", P.config.EnableAssigningQuickExploration && !P.config.DontReassign))
            {
                P.config.EnableAssigningQuickExploration = true;
                P.config.DontReassign = false;
            }
            ImGuiComponents.HelpMarker("Automatically assigns enabled retainers to a Quick Venture if they have none already in progress and reassigns current venture.");
            if (ImGui.RadioButton("Collect", !P.config.EnableAssigningQuickExploration && P.config.DontReassign))
            {
                P.config.EnableAssigningQuickExploration = false;
                P.config.DontReassign = true;
            }
            ImGuiComponents.HelpMarker("Only collect venture rewards from the retainer, and will not reassign them.\nHold CTRL when interacting with the Summoning Bell to apply this mode temporarily.");
            if (ImGui.RadioButton("Reassign", !P.config.EnableAssigningQuickExploration && !P.config.DontReassign))
            {
                P.config.EnableAssigningQuickExploration = false;
                P.config.DontReassign = false;
            }
            ImGuiComponents.HelpMarker("Only reassign ventures that retainers are undertaking.");
            ImGui.Checkbox("RetainerSense", ref P.config.AutoUseRetainerBell);
            ImGuiComponents.HelpMarker("Detect and use the closest Summoning Bell within 5 yalms of the player, requires the plugin menu to be open.");
            if (P.config.AutoUseRetainerBell)
            {
                ImGui.Checkbox("Focus Mode", ref P.config.AutoUseRetainerBellFocusOnly);
                ImGuiComponents.HelpMarker("RetainerSense will only function if there is a Summoning Bell set as the focus target.");
            }
            ImGui.Checkbox("Close Retainer Menu on Completion", ref P.config._autoCloseRetainerWindow);
            ImGuiComponents.HelpMarker("Hold CTRL to temporarily suppress closing.");
        });
        InfoBox.DrawBox("Quick Retainer Action", delegate
        {
            QRA("Sell Item", ref P.config.SellKey);
            QRA("Entrust Item", ref P.config.EntrustKey);
            QRA("Retrieve Item", ref P.config.RetrieveKey);
            QRA("Put up For Sale", ref P.config.SellMarketKey);
        });
        InfoBox.DrawBox("Statistics", delegate
        {
            ImGui.Checkbox($"Record venture statistics", ref P.config.RecordStats);
        });
    }

    static void QRA(string text, ref Keys key)
    {
        ImGui.PushID(text);
        ImGuiEx.TextV($"{text}:");
        ImGui.SameLine();
        ImGui.SetNextItemWidth(200f);
        if(ImGui.BeginCombo("##inputKey", $"{key}"))
        {
            var block = false;
            if (ImGui.Selectable("Cancel"))
            {
            }
            if (ImGui.IsItemHovered()) block = true;
            if (ImGui.Selectable("Clear"))
            {
                key = Keys.None;
            }
            if (ImGui.IsItemHovered()) block = true;
            if (!block)
            {
                ImGuiEx.Text(GradientColor.Get(ImGuiColors.ParsedGreen, ImGuiColors.DalamudRed), "Now press new key...");
                foreach (var x in Enum.GetValues<Keys>())
                {
                    if (Bitmask.IsBitSet(User32.GetKeyState((int)x), 15))
                    {
                        ImGui.CloseCurrentPopup();
                        key = x;
                        P.quickSellItems.Toggle();
                        break;
                    }
                }
            }
            ImGui.EndCombo();
        }
        //if (ImGuiEx.EnumCombo($"##{text}", ref key, EnumConsts)) 
        if (key != Keys.None)
        { 
            ImGui.SameLine();
            if (ImGuiEx.IconButton(FontAwesomeIcon.Trash))
            {
                key = Keys.None;
            }
            ImGui.SameLine();
            ImGuiEx.Text("+ right click");
        }
        ImGui.PopID();
    }
}
