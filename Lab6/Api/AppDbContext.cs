using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Api;

public class AppDbContext : DbContext
{
    public DbSet<RefCustomerType> RefCustomerTypes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<RefAccountType> RefAccountTypes { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Party> Parties { get; set; }
    public DbSet<RefTransactionType> RefTransactionTypes { get; set; }
    public DbSet<TransactionMessage> TransactionMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RefCustomerType>().HasKey(r => r.CustomerTypeCode);

        modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);

        modelBuilder
            .Entity<Customer>()
            .HasOne(c => c.RefCustomerType)
            .WithMany(r => r.Customers)
            .HasForeignKey(c => c.CustomerTypeCode);

        modelBuilder.Entity<Account>().HasKey(a => a.AccountId);

        modelBuilder
            .Entity<Account>()
            .HasOne(a => a.Customer)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.CustomerId);

        modelBuilder
            .Entity<Account>()
            .HasOne(a => a.RefAccountType)
            .WithMany(r => r.Accounts)
            .HasForeignKey(a => a.AccountTypeCode);

        modelBuilder.Entity<RefAccountType>().HasKey(r => r.AccountTypeCode);

        modelBuilder.Entity<Party>().HasKey(p => p.PartyId);

        modelBuilder.Entity<RefTransactionType>().HasKey(r => r.TransactionTypeCode);

        modelBuilder.Entity<TransactionMessage>().HasKey(t => t.MessageNumber);

        modelBuilder
            .Entity<TransactionMessage>()
            .HasOne(t => t.Account)
            .WithMany(a => a.TransactionMessages)
            .HasForeignKey(t => t.AccountId);

        modelBuilder
            .Entity<TransactionMessage>()
            .HasOne(t => t.Party)
            .WithMany(p => p.TransactionMessages)
            .HasForeignKey(t => t.PartyId);

        modelBuilder
            .Entity<TransactionMessage>()
            .HasOne(t => t.RefTransactionType)
            .WithMany(r => r.TransactionMessages)
            .HasForeignKey(t => t.TransactionTypeCode);

        // Seed RefCustomerType
        modelBuilder
            .Entity<RefCustomerType>()
            .HasData(
                new RefCustomerType
                {
                    CustomerTypeCode = 1,
                    CustomerTypeDescription = "Administrator",
                },
                new RefCustomerType
                {
                    CustomerTypeCode = 2,
                    CustomerTypeDescription = "Organization",
                }
            );

        // Seed RefAccountType
        modelBuilder
            .Entity<RefAccountType>()
            .HasData(
                new RefAccountType { AccountTypeCode = 1, AccountTypeDescription = "Current" },
                new RefAccountType { AccountTypeCode = 2, AccountTypeDescription = "Deposit" }
            );

        // Seed RefTransactionType
        modelBuilder
            .Entity<RefTransactionType>()
            .HasData(
                new RefTransactionType
                {
                    TransactionTypeCode = 1,
                    TransactionTypeDescription = "Deposit",
                },
                new RefTransactionType
                {
                    TransactionTypeCode = 2,
                    TransactionTypeDescription = "Withdrawal",
                }
            );

        // Seed Customers
        modelBuilder
            .Entity<Customer>()
            .HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "John Doe",
                    CustomerPhone = "123456789",
                    CustomerEmail = "johndoe@example.com",
                    DateBecameCustomer = new DateTime(2020, 1, 15),
                    OtherDetails = "VIP Customer",
                    CustomerTypeCode = 1,
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Acme Corporation",
                    CustomerPhone = "987654321",
                    CustomerEmail = "contact@acme.com",
                    DateBecameCustomer = new DateTime(2018, 6, 5),
                    OtherDetails = "Enterprise Account",
                    CustomerTypeCode = 2,
                }
            );

        // Seed Accounts
        modelBuilder
            .Entity<Account>()
            .HasData(
                new Account
                {
                    AccountId = 1,
                    AccountName = "John's Current Account",
                    DateOpened = new DateTime(2020, 1, 20),
                    CurrentBalance = 5000.00M,
                    OtherAccountDetails = "Main personal account",
                    CustomerId = 1,
                    AccountTypeCode = 1,
                },
                new Account
                {
                    AccountId = 2,
                    AccountName = "Acme Corp Deposit",
                    DateOpened = new DateTime(2018, 6, 10),
                    CurrentBalance = 100000.00M,
                    OtherAccountDetails = "Business savings account",
                    CustomerId = 2,
                    AccountTypeCode = 2,
                }
            );

        // Seed Parties
        modelBuilder
            .Entity<Party>()
            .HasData(
                new Party
                {
                    PartyId = 1,
                    Name = "Jane Smith",
                    Phone = "1122334455",
                    Email = "jane.smith@example.com",
                    OtherDetails = "Regular partner",
                },
                new Party
                {
                    PartyId = 2,
                    Name = "Global Supplies",
                    Phone = "2233445566",
                    Email = "info@globalsupplies.com",
                    OtherDetails = "Corporate partner",
                }
            );

        // Seed TransactionMessages
        modelBuilder
            .Entity<TransactionMessage>()
            .HasData(
                new TransactionMessage
                {
                    MessageNumber = 1,
                    AccountId = 1,
                    CounterpartyId = null,
                    PartyId = 1,
                    TransactionTypeCode = 1,
                    CounterpartyRole = "Sender",
                    CurrencyCode = "USD",
                    IBANNumber = "US123456789",
                    TransactionDate = new DateTime(2021, 7, 15),
                    Amount = 500.00M,
                    Balance = 4500.00M,
                    Location = "New York",
                    PartyRole = "Payee",
                },
                new TransactionMessage
                {
                    MessageNumber = 2,
                    AccountId = 2,
                    CounterpartyId = null,
                    PartyId = 2,
                    TransactionTypeCode = 2,
                    CounterpartyRole = "Receiver",
                    CurrencyCode = "USD",
                    IBANNumber = "US987654321",
                    TransactionDate = new DateTime(2022, 3, 5),
                    Amount = 2000.00M,
                    Balance = 98000.00M,
                    Location = "Los Angeles",
                    PartyRole = "Payer",
                }
            );
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
