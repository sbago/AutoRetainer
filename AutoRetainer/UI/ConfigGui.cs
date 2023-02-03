using AutoRetainer.Multi;
using AutoRetainer.Statistics;
using PunishLib.ImGuiMethods;

namespace AutoRetainer.UI;

unsafe internal class ConfigGui : Window
{
    public ConfigGui() : base($"{P.Name} configuration",
        ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoFocusOnAppearing)
    {
        this.SizeConstraints = new()
        {
            MinimumSize = new(250, 100),
            MaximumSize = new(9999,9999)
        };
        P.ws.AddWindow(this);
    }

    public override void Draw()
    {
        if (P.retainerManager.Ready && Svc.ClientState.LocalPlayer != null)
        {
            Scheduler.Tick();
            if (!P.config.SelectedRetainers.ContainsKey(Svc.ClientState.LocalContentId))
            {
                P.config.SelectedRetainers[Svc.ClientState.LocalContentId] = new();
            }
        }
        var en = P.IsEnabled();
        if (ImGui.Checkbox(string.Format(Language.Language.Instance.Checkbox_Enable,P.Name), ref en))
        {
            if (en)
            {
                P.EnablePlugin();
            }
            else
            {
                P.DisablePlugin();
            }
        }
        ImGui.SameLine();
        ImGui.Checkbox(Language.Language.Instance.Checkbox_AutoEnable, ref P.config.AutoEnableDisable);

        ImGui.SameLine();
        ImGui.Checkbox(Language.Language.Instance.Checkbox_Multi, ref MultiMode.Enabled);

        ImGui.SameLine(0,20);
        var last = P.config.LanguageType;
        UiHelper.DrawEnum(Language.Language.Instance.DrawEnum_Language, ref last,100,5);
        if (last != P.config.LanguageType)
        {
            P.config.LanguageType = last;
            Language.Language.Instance = Language.LanguageManager.GetLan(last);
            Svc.PluginInterface.SavePluginConfig(P.config);
        }

        if (Scheduler.turbo)
        {
            ImGui.SameLine();
            ImGuiEx.Text(Environment.TickCount % 1000 > 500 ? ImGuiColors.DalamudRed : ImGuiColors.DalamudYellow, "Turbo active");
        }
        ImGuiEx.EzTabBar("tabbar",
                (Language.Language.Instance.EzTabBar_Retainers, Retainers.Draw, null, true),

                (Language.Language.Instance.EzTabBar_MultiMode, MultiModeUI.Draw, null, true),

                (P.config.RecordStats? Language.Language.Instance.EzTabBar_Statistics: null, StatisticsUI.Draw, null, true),
                (Language.Language.Instance.EzTabBar_Settings, Settings.Draw, null, true),
                (Language.Language.Instance.EzTabBar_Beta, TabBeta.Draw, null, true),
                (Language.Language.Instance.EzTabBar_About, delegate { AboutTab.Draw(P); }, null, true),
                (P.config.Verbose ? Language.Language.Instance.EzTabBar_Log : null, InternalLog.PrintImgui, null, false),
                (P.config.Verbose? Language.Language.Instance.EzTabBar_Debug: null, Debug.Draw, null, true)
                );
    }

    public override void OnClose()
    {
        Svc.PluginInterface.SavePluginConfig(P.config);
        P.DisablePlugin();
        StatisticsUI.Data.Clear();
        Notify.Success("Auto Retainer disabled");
    }

}
