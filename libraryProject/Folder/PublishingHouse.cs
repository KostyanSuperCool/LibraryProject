using System;
using System.Collections.Generic;

namespace libraryProject.Folder;

public partial class PublishingHouse
{
    public int Id { get; set; }

    public string HousePublishing { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
