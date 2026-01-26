using System;
using System.Collections.Generic;

namespace libraryProject.Folder;

public partial class LibraryCard
{
    public int Id { get; set; }

    public string Card { get; set; } = null!;

    public virtual ICollection<BooksLoan> BooksLoans { get; set; } = new List<BooksLoan>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
