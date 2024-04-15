using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektiPersonal.Migrations
{
    public partial class firstmigrationss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
