using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KT.Common.Enums;

/// <summary>
/// The type of library.
/// </summary>
public enum LibraryType
{
    [Description("The System Library will not be editable by the User. It will be used to store system-wide course templates.")]
    [Display(Name = "System")]
    System,

    [Description("The library is a tenant library, managed by and editable for the User.")]
    [Display(Name = "Tenant")]
    Tenant
}
