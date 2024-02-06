﻿using System;
using System.Threading.Tasks;
using System.Windows;
using LenovoLegionToolkit.Lib;
using LenovoLegionToolkit.Lib.Listeners;
using LenovoLegionToolkit.WPF.Extensions;
using LenovoLegionToolkit.WPF.Resources;
using LenovoLegionToolkit.WPF.Utils;
using Wpf.Ui.Controls;

namespace LenovoLegionToolkit.WPF.Controls.Dashboard;

public class ResolutionControl : AbstractComboBoxFeatureCardControl<Resolution>
{
    private readonly DisplayConfigurationListener _listener = IoCContainer.Resolve<DisplayConfigurationListener>();

    public ResolutionControl()
    {
        Icon = SymbolRegular.ScaleFill24.GetIcon();
        Title = Resource.ResolutionControl_Title;
        Subtitle = Resource.ResolutionControl_Message;

        _listener.Changed += Listener_Changed;
    }

    protected override async Task OnRefreshAsync()
    {
        await base.OnRefreshAsync();

        Visibility = ItemsCount < 2 ? Visibility.Collapsed : Visibility.Visible;
    }

    protected override string ComboBoxItemDisplayName(Resolution value)
    {
        var str = base.ComboBoxItemDisplayName(value);
        return LocalizationHelper.ForceLeftToRight(str);
    }

    private void Listener_Changed(object? sender, EventArgs e) => Dispatcher.Invoke(async () =>
    {
        if (IsLoaded)
            await RefreshAsync();
    });
}
