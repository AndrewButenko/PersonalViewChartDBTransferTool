﻿using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace AButenko.PersonalViewsDashboardsTransferTool
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Personal Views/Charts/Dashboards Transfer Tool"),
        ExportMetadata("Description", "Using this tool user can transfer personal views, charts and dashboards between environments (including shares with other users/teams)"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", null),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#E4ECEF"),
        ExportMetadata("PrimaryFontColor", "Blue"),
        ExportMetadata("SecondaryFontColor", "Blue")]
    public class PvdbTransferToolPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new PvdbTransferToolPluginControl();
        }
    }
}