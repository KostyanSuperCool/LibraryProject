using System;
using System.Collections.Generic;

namespace libraryProject;

public partial class Status
{
    public int Id { get; set; }

    public string Status1 { get; set; } = null!;

    public virtual ICollection<BooksLoan> BooksLoans { get; set; } = new List<BooksLoan>();
}
