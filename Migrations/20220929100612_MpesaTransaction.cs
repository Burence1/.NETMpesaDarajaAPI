using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MpesaDarajaAPI.Migrations
{
    public partial class MpesaTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MpesaTransactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    transactionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    transTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    transAmount = table.Column<decimal>(type: "Decimal (38,2)", nullable: false),
                    businessShortCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    billRefNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    orgAccountBalance = table.Column<decimal>(type: "Decimal (38,2)", nullable: false),
                    thirdPartyTransID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MSISDN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    responseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpesaTransactions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MpesaTransactions");
        }
    }
}
