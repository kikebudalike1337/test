using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePraksa.Api.Migrations
{
    public partial class internship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    internshipID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    internshipName = table.Column<string>(nullable: true),
                    internshipDescription = table.Column<string>(nullable: true),
                    mentorName = table.Column<string>(nullable: true),
                    internshipStartDate = table.Column<DateTime>(nullable: false),
                    internshipEndDate = table.Column<DateTime>(nullable: false),
                    mentorContactEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.internshipID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Internships");
        }
    }
}
