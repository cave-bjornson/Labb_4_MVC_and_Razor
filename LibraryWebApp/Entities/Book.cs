﻿using LibraryWebApp.Shared;
using Volo.Abp.Domain.Entities;

namespace LibraryWebApp.Entities;

public class Book : Entity<Guid>
{
    public required string Name { get; set; }

    public required BookType Type { get; set; }

    public required DateTime PublishDate { get; set; }
}
