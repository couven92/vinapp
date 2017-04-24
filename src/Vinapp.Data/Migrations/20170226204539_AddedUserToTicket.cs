using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vinapp.Data.Migrations
{
    public partial class AddedUserToTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LotteryTickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LotteryTickets_UserId",
                table: "LotteryTickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_LotteryTickets_AspNetUsers_UserId",
            //     table: "LotteryTickets",
            //     column: "UserId",
            //     principalTable: "AspNetUsers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotteryTickets_AspNetUsers_UserId",
                table: "LotteryTickets");

            migrationBuilder.DropIndex(
                name: "IX_LotteryTickets_UserId",
                table: "LotteryTickets");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LotteryTickets");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
