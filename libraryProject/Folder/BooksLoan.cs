using System;
using System.Collections.Generic;

namespace libraryProject;

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

    public virtual Book Book { get; set; } = null!;

    public virtual LibraryCard LibraryCard { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
