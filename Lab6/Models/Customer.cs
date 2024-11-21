using System.Text.Json.Serialization;

namespace Lab6.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;
    public DateTime DateBecameCustomer { get; set; }
    public string OtherDetails { get; set; } = null!;
    public int CustomerTypeCode { get; set; }

    public RefCustomerType RefCustomerType { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Account> Accounts { get; set; } = null!;
}
