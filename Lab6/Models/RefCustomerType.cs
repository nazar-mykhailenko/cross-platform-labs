using System.Text.Json.Serialization;

namespace Lab6.Models;

public class RefCustomerType
{
    public int CustomerTypeCode { get; set; }
    public string CustomerTypeDescription { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Customer> Customers { get; set; } = null!;
}
