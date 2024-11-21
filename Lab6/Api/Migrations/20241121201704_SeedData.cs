using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                });

            migrationBuilder.CreateTable(
                name: "RefAccountTypes",
                columns: table => new
                {
                    AccountTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAccountTypes", x => x.AccountTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefCustomerTypes",
                columns: table => new
                {
                    CustomerTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefCustomerTypes", x => x.CustomerTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefTransactionTypes",
                columns: table => new
                {
                    TransactionTypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefTransactionTypes", x => x.TransactionTypeCode);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBecameCustomer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerTypeCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_RefCustomerTypes_CustomerTypeCode",
                        column: x => x.CustomerTypeCode,
                        principalTable: "RefCustomerTypes",
                        principalColumn: "CustomerTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherAccountDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AccountTypeCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_RefAccountTypes_AccountTypeCode",
                        column: x => x.AccountTypeCode,
                        principalTable: "RefAccountTypes",
                        principalColumn: "AccountTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionMessages",
                columns: table => new
                {
                    MessageNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: true),
                    PartyId = table.Column<int>(type: "int", nullable: true),
                    TransactionTypeCode = table.Column<int>(type: "int", nullable: false),
                    CounterpartyRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBANNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PartyRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionMessages", x => x.MessageNumber);
                    table.ForeignKey(
                        name: "FK_TransactionMessages_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionMessages_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId");
                    table.ForeignKey(
                        name: "FK_TransactionMessages_RefTransactionTypes_TransactionTypeCode",
                        column: x => x.TransactionTypeCode,
                        principalTable: "RefTransactionTypes",
                        principalColumn: "TransactionTypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "PartyId", "Email", "Name", "OtherDetails", "Phone" },
                values: new object[,]
                {
                    { 1, "jane.smith@example.com", "Jane Smith", "Regular partner", "1122334455" },
                    { 2, "info@globalsupplies.com", "Global Supplies", "Corporate partner", "2233445566" }
                });

            migrationBuilder.InsertData(
                table: "RefAccountTypes",
                columns: new[] { "AccountTypeCode", "AccountTypeDescription" },
                values: new object[,]
                {
                    { 1, "Current" },
                    { 2, "Deposit" }
                });

            migrationBuilder.InsertData(
                table: "RefCustomerTypes",
                columns: new[] { "CustomerTypeCode", "CustomerTypeDescription" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Organization" }
                });

            migrationBuilder.InsertData(
                table: "RefTransactionTypes",
                columns: new[] { "TransactionTypeCode", "TransactionTypeDescription" },
                values: new object[,]
                {
                    { 1, "Deposit" },
                    { 2, "Withdrawal" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerEmail", "CustomerName", "CustomerPhone", "CustomerTypeCode", "DateBecameCustomer", "OtherDetails" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John Doe", "123456789", 1, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "VIP Customer" },
                    { 2, "contact@acme.com", "Acme Corporation", "987654321", 2, new DateTime(2018, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enterprise Account" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "AccountTypeCode", "CurrentBalance", "CustomerId", "DateClosed", "DateOpened", "OtherAccountDetails" },
                values: new object[,]
                {
                    { 1, "John's Current Account", 1, 5000.00m, 1, null, new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Main personal account" },
                    { 2, "Acme Corp Deposit", 2, 100000.00m, 2, null, new DateTime(2018, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business savings account" }
                });

            migrationBuilder.InsertData(
                table: "TransactionMessages",
                columns: new[] { "MessageNumber", "AccountId", "Amount", "Balance", "CounterpartyId", "CounterpartyRole", "CurrencyCode", "IBANNumber", "Location", "PartyId", "PartyRole", "TransactionDate", "TransactionTypeCode" },
                values: new object[,]
                {
                    { 1, 1, 500.00m, 4500.00m, null, "Sender", "USD", "US123456789", "New York", 1, "Payee", new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, 2000.00m, 98000.00m, null, "Receiver", "USD", "US987654321", "Los Angeles", 2, "Payer", new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeCode",
                table: "Accounts",
                column: "AccountTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeCode",
                table: "Customers",
                column: "CustomerTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionMessages_AccountId",
                table: "TransactionMessages",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionMessages_PartyId",
                table: "TransactionMessages",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionMessages_TransactionTypeCode",
                table: "TransactionMessages",
                column: "TransactionTypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionMessages");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "RefTransactionTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RefAccountTypes");

            migrationBuilder.DropTable(
                name: "RefCustomerTypes");
        }
    }
}
