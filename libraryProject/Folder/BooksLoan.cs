using System;
using System.Collections.Generic;

namespace libraryProject.Folder;

public partial class BooksLoan
{
    public int Id { get; set; }

    public int IdGive { get; set; }

    public int IdLibraryCard { get; set; }

    public int IdIsbn { get; set; }

    public DateOnly DateOfIssue { get; set; }

    public DateOnly PlannedReturnDate { get; set; }

    public DateOnly? ActualReturnDate { get; set; }

    public int IdStatus { get; set; }

    public virtual Book IdIsbnNavigation { get; set; } = null!;

    public virtual LibraryCard IdLibraryCardNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;
}
