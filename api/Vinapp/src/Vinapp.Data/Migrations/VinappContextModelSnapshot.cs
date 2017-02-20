using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vinapp.Data.Migrations
{
    [DbContext(typeof(VinappContext))]
    public class VinappContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            modelBuilder.Entity("Vinapp.Data.Models.LotteryTicket",
                b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TicketNumber");

                    b.Property<int>("Week");

                    b.Property<bool>("IsPaid");

                    b.Property<bool>("IsWinnerTicket");

                    b.Property<DateTime>("IsPurchased");

                    b.Property<DateTime>("RowUpdated");

                    b.Property<byte[]>("RowVersion")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("TicketId");

                    b.HasIndex("TicketNumber");

                    b.ToTable("LotteryTickets");
                });
        }
    }
}
