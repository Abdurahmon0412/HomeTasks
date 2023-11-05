﻿#pragma warning disable CS8618

namespace EduCource.Domain.Entities;

public class Role
{
    public string Name { get; set; } = default!;

    public Guid UserId { get; set; }

    public virtual User User { get; set; }
}