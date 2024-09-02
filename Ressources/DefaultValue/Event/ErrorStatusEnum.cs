using System.ComponentModel;

namespace Ressources.DefaultValue.Event;

public enum ErrorStatusEnum
{
    [Description(ErrorStatusConstantTitle.UnresolvedStatus)]
    UnresolvedStatusId,

    [Description(ErrorStatusConstantTitle.InProgressStatus)]
    InProgressStatusId,

    [Description(ErrorStatusConstantTitle.ResolvedStatus)]
    ResolvedStatusId,
}