using System;
using System.Collections.Generic;

namespace APW.Data.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public int? UserId { get; set; }

    public string? AccountType { get; set; }

    public decimal? Balance { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
