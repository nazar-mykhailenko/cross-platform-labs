namespace Lab6.Models;

public class Party
{
    public int PartyId { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string OtherDetails { get; set; } = null!;

    public ICollection<TransactionMessage> TransactionMessages { get; set; } = null!;
}
