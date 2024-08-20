using System.ComponentModel;
namespace Ressources.Annotation.RestrictionLentgh;
public enum FieldRestrictionLentgh
{
    [Description("Title can't be longer than 50 characters")]
    FieldTooLongBy50 = 50,
    [Description("Title can't be longer than 100 characters")]
    FieldTooLongBy100 = 100,
    [Description("Title can't be longer than 150 characters")]
    FieldTooLongBy150 = 150,
    [Description("Title can't be longer than 200 characters")]
    FieldTooLongBy200 = 200,
    [Description("Title can't be longer than 300 characters")]
    FieldTooLongBy300 = 300,
    [Description("Title can't be longer than 500 characters")]
    FieldTooLongBy500 = 500,
}
public enum IdRestrictionLentgh
{
    [Description("Title can't be longer than 5 characters")]
    NicTooLongBy5 = 5,
    [Description("Title can't be longer than 15 characters")]
    SiretTooLongBy15 = 15,
    [Description("Identifier can't be longuer than 16 characters")]
    IdentifierTooLongBy16 = 16
}