namespace Lab6.Models;
public class TransactionMessage
{
    public int MessageNumber { get; set; }
    public int AccountId { get; set; }
    public int? CounterpartyId { get; set; }
    public int? PartyId { get; set; }
    public int TransactionTypeCode { get; set; }
    public string CounterpartyRole { get; set; } = null!;
    public string CurrencyCode { get; set; } = null!;
    public string IBANNumber { get; set; } = null!;
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public string Location { get; set; } = null!;
    public string PartyRole { get; set; } = null!;

    public Account Account { get; set; } = null!;
    public Party Party { get; set; } = null!;
    public RefTransactionType RefTransactionType { get; set; } = null!;
}
