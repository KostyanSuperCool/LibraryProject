using System;
using System.Collections.Generic;

namespace libraryProject;

public partial class Ganre
{
    public int Id { get; set; }

    public string GenreBook { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
