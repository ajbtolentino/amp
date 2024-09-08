using System;

namespace AMP.Shared.Data;

public interface IAMPDbContext
{
    bool SaveChanges();
}