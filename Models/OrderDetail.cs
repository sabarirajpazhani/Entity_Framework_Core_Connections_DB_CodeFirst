using System;
using System.Collections.Generic;

namespace DB_First.Models;

public partial class OrderDetail
{
    public int OrderDetails { get; set; }

    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? TotalPrice { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Product? Product { get; set; }
}
