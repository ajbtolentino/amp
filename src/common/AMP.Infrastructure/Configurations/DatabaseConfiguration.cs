using System;
using AMP.Infrastructure.Enums;

namespace AMP.Infrastructure.Configurations;

public class DatabaseConfiguration
{
    public string Name { get; set; }
    public DatabaseType Type { get; set; }
}
