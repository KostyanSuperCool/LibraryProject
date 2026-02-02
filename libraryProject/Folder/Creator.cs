using System;
using System.Collections.Generic;

namespace libraryProject;

public partial class Creator
{
    public int Id { get; set; }

    public string Creator1 { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
