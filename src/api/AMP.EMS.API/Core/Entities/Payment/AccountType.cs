using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class AccountType : LookupEntity<Guid>
{
    public virtual ICollection<Account> Accounts { get; set; }
}