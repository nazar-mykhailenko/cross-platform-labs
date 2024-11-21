namespace Lab6.Models;

public class RefTransactionType
{
    public int TransactionTypeCode { get; set; }
    public string TransactionTypeDescription { get; set; } = null!;

    public ICollection<TransactionMessage> TransactionMessages { get; set; } = null!;
}
