using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BookInfo.Repositories;

namespace BookInfo.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookInfo.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<int?>("BookID");

                    b.Property<string>("Name");

                    b.HasKey("AuthorID");

                    b.HasIndex("BookID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookInfo.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Title");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookInfo.Models.Author", b =>
                {
                    b.HasOne("BookInfo.Models.Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookID");
                });
        }
    }
}
