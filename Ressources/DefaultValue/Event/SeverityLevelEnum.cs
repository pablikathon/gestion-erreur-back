using System.ComponentModel;

namespace Ressources.DefaultValue.Event;

public enum SeverityLevelEnum
{
    [Description(SeverityLevelTitle.LowSeverety)]
    LowSeverety,

    [Description(SeverityLevelTitle.MediumSeverity)]
    MediumSeverity,

    [Description(SeverityLevelTitle.HighSeverity)]
    HighSeverity,

    [Description(SeverityLevelTitle.CriticalSeverity)]
    CriticalSeverity,
}