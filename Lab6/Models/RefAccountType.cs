using System.Text.Json.Serialization;

namespace Lab6.Models;

public class RefAccountType
{
    public int AccountTypeCode { get; set; }
    public string AccountTypeDescription { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Account> Accounts { get; set; } = null!;
}
