﻿using LenovoLegionToolkit.Lib;
using LenovoLegionToolkit.Lib.Automation.Steps;
using LenovoLegionToolkit.WPF.Extensions;
using LenovoLegionToolkit.WPF.Resources;
using Wpf.Ui.Controls;

namespace LenovoLegionToolkit.WPF.Controls.Automation.Steps;

public class FnLockAutomationStepControl : AbstractComboBoxAutomationStepCardControl<FnLockState>
{
    public FnLockAutomationStepControl(IAutomationStep<FnLockState> step) : base(step)
    {
        Icon = SymbolRegular.Keyboard24.GetIcon();
        Title = Resource.FnLockAutomationStepControl_Title;
        Subtitle = Resource.FnLockAutomationStepControl_Message;
    }
}
