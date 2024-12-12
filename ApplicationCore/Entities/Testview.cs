using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class Testview
{
    public string? CustomerId { get; set; }

    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? ShipVia { get; set; }
}
