using System.ComponentModel.DataAnnotations;

namespace KT.Common.Enums;

public enum LibraryType
{
    [Display(Name = "System")]
    System,
    [Display(Name = "User")]
    User
}
