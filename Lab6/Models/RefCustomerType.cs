namespace Lab6.Models;

public class RefCustomerType
{
    public int CustomerTypeCode { get; set; }
    public string CustomerTypeDescription { get; set; } = null!;

    public ICollection<Customer> Customers { get; set; } = null!;
}
