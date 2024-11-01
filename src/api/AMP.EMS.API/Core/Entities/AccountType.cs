using AMP.Infrastructure.Entity;

namespace AMP.EMS.API.Core.Entities;

public class AccountType : Lookup
{
    public ICollection<Account> Accounts { get; set; }
}