﻿// <auto-generated />
using System;
using Lab6.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab6.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccountTypeCode")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrentBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherAccountDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("AccountTypeCode");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            AccountName = "John's Current Account",
                            AccountTypeCode = 1,
                            CurrentBalance = 5000.00m,
                            CustomerId = 1,
                            DateOpened = new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OtherAccountDetails = "Main personal account"
                        },
                        new
                        {
                            AccountId = 2,
                            AccountName = "Acme Corp Deposit",
                            AccountTypeCode = 2,
                            CurrentBalance = 100000.00m,
                            CustomerId = 2,
                            DateOpened = new DateTime(2018, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OtherAccountDetails = "Business savings account"
                        });
                });

            modelBuilder.Entity("Lab6.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerTypeCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateBecameCustomer")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CustomerTypeCode");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerEmail = "johndoe@example.com",
                            CustomerName = "John Doe",
                            CustomerPhone = "123456789",
                            CustomerTypeCode = 1,
                            DateBecameCustomer = new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OtherDetails = "VIP Customer"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerEmail = "contact@acme.com",
                            CustomerName = "Acme Corporation",
                            CustomerPhone = "987654321",
                            CustomerTypeCode = 2,
                            DateBecameCustomer = new DateTime(2018, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OtherDetails = "Enterprise Account"
                        });
                });

            modelBuilder.Entity("Lab6.Models.Party", b =>
                {
                    b.Property<int>("PartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartyId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartyId");

                    b.ToTable("Parties");

                    b.HasData(
                        new
                        {
                            PartyId = 1,
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith",
                            OtherDetails = "Regular partner",
                            Phone = "1122334455"
                        },
                        new
                        {
                            PartyId = 2,
                            Email = "info@globalsupplies.com",
                            Name = "Global Supplies",
                            OtherDetails = "Corporate partner",
                            Phone = "2233445566"
                        });
                });

            modelBuilder.Entity("Lab6.Models.RefAccountType", b =>
                {
                    b.Property<int>("AccountTypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountTypeCode"));

                    b.Property<string>("AccountTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountTypeCode");

                    b.ToTable("RefAccountTypes");

                    b.HasData(
                        new
                        {
                            AccountTypeCode = 1,
                            AccountTypeDescription = "Current"
                        },
                        new
                        {
                            AccountTypeCode = 2,
                            AccountTypeDescription = "Deposit"
                        });
                });

            modelBuilder.Entity("Lab6.Models.RefCustomerType", b =>
                {
                    b.Property<int>("CustomerTypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerTypeCode"));

                    b.Property<string>("CustomerTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerTypeCode");

                    b.ToTable("RefCustomerTypes");

                    b.HasData(
                        new
                        {
                            CustomerTypeCode = 1,
                            CustomerTypeDescription = "Administrator"
                        },
                        new
                        {
                            CustomerTypeCode = 2,
                            CustomerTypeDescription = "Organization"
                        });
                });

            modelBuilder.Entity("Lab6.Models.RefTransactionType", b =>
                {
                    b.Property<int>("TransactionTypeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionTypeCode"));

                    b.Property<string>("TransactionTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionTypeCode");

                    b.ToTable("RefTransactionTypes");

                    b.HasData(
                        new
                        {
                            TransactionTypeCode = 1,
                            TransactionTypeDescription = "Deposit"
                        },
                        new
                        {
                            TransactionTypeCode = 2,
                            TransactionTypeDescription = "Withdrawal"
                        });
                });

            modelBuilder.Entity("Lab6.Models.TransactionMessage", b =>
                {
                    b.Property<int>("MessageNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageNumber"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CounterpartyId")
                        .HasColumnType("int");

                    b.Property<string>("CounterpartyRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBANNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PartyId")
                        .HasColumnType("int");

                    b.Property<string>("PartyRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionTypeCode")
                        .HasColumnType("int");

                    b.HasKey("MessageNumber");

                    b.HasIndex("AccountId");

                    b.HasIndex("PartyId");

                    b.HasIndex("TransactionTypeCode");

                    b.ToTable("TransactionMessages");

                    b.HasData(
                        new
                        {
                            MessageNumber = 1,
                            AccountId = 1,
                            Amount = 500.00m,
                            Balance = 4500.00m,
                            CounterpartyRole = "Sender",
                            CurrencyCode = "USD",
                            IBANNumber = "US123456789",
                            Location = "New York",
                            PartyId = 1,
                            PartyRole = "Payee",
                            TransactionDate = new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionTypeCode = 1
                        },
                        new
                        {
                            MessageNumber = 2,
                            AccountId = 2,
                            Amount = 2000.00m,
                            Balance = 98000.00m,
                            CounterpartyRole = "Receiver",
                            CurrencyCode = "USD",
                            IBANNumber = "US987654321",
                            Location = "Los Angeles",
                            PartyId = 2,
                            PartyRole = "Payer",
                            TransactionDate = new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionTypeCode = 2
                        });
                });

            modelBuilder.Entity("Lab6.Models.Account", b =>
                {
                    b.HasOne("Lab6.Models.RefAccountType", "RefAccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("RefAccountType");
                });

            modelBuilder.Entity("Lab6.Models.Customer", b =>
                {
                    b.HasOne("Lab6.Models.RefCustomerType", "RefCustomerType")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefCustomerType");
                });

            modelBuilder.Entity("Lab6.Models.TransactionMessage", b =>
                {
                    b.HasOne("Lab6.Models.Account", "Account")
                        .WithMany("TransactionMessages")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab6.Models.Party", "Party")
                        .WithMany("TransactionMessages")
                        .HasForeignKey("PartyId");

                    b.HasOne("Lab6.Models.RefTransactionType", "RefTransactionType")
                        .WithMany("TransactionMessages")
                        .HasForeignKey("TransactionTypeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Party");

                    b.Navigation("RefTransactionType");
                });

            modelBuilder.Entity("Lab6.Models.Account", b =>
                {
                    b.Navigation("TransactionMessages");
                });

            modelBuilder.Entity("Lab6.Models.Customer", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Lab6.Models.Party", b =>
                {
                    b.Navigation("TransactionMessages");
                });

            modelBuilder.Entity("Lab6.Models.RefAccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Lab6.Models.RefCustomerType", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Lab6.Models.RefTransactionType", b =>
                {
                    b.Navigation("TransactionMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
