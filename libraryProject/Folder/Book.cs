using System;
using System.Collections.Generic;

namespace libraryProject.Folder;

public partial class Book
{
    public int Id { get; set; }

    public string Isbn { get; set; } = null!;

    public string NameBook { get; set; } = null!;

    public int IdCreator { get; set; }

    public int IdGenre { get; set; }

    public int IdPublishing { get; set; }

    public string YearOfPublication { get; set; } = null!;

    public string Paper { get; set; } = null!;

    public string All { get; set; } = null!;

    public string Available { get; set; } = null!;

    public string Annotation { get; set; } = null!;

    public string? Photo { get; set; }

    public virtual ICollection<BooksLoan> BooksLoans { get; set; } = new List<BooksLoan>();

    public virtual Creator Creator { get; set; } = null!;

    public virtual Ganre Ganre { get; set; } = null!;

    public virtual PublishingHouse PublishingHouse { get; set; } = null!;
}
