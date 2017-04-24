using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinapp.Data.Migrations
{
    public partial class AddedUniqueIndexToLotteryTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "TicketNumber",
            //    table: "LotteryTickets",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LotteryTickets_TicketNumber_Week",
                table: "LotteryTickets",
                columns: new[] { "TicketNumber", "Week" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LotteryTickets_TicketNumber_Week",
                table: "LotteryTickets");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TicketNumber",
            //    table: "LotteryTickets",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldNullable: true);
        }
    }
}
