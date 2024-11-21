using System.Text.Json.Serialization;

namespace Lab6.Models;

public class Account
{
    public int AccountId { get; set; }
    public string AccountName { get; set; } = null!;
    public DateTime DateOpened { get; set; }
    public DateTime? DateClosed { get; set; }
    public decimal CurrentBalance { get; set; }
    public string OtherAccountDetails { get; set; } = null!;
    public int CustomerId { get; set; }
    public int AccountTypeCode { get; set; }

    [JsonIgnore]
    public Customer Customer { get; set; } = null!;
    public RefAccountType RefAccountType { get; set; } = null!;
    public ICollection<TransactionMessage> TransactionMessages { get; set; } = null!;
}
