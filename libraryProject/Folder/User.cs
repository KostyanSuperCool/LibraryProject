using System;
using System.Collections.Generic;

namespace libraryProject.Folder;

public partial class User
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public string UserName { get; set; } = null!;

    public int IdLibraryCard { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual LibraryCard IdLibraryCardNavigation { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
