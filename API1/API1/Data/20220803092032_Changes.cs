using Microsoft.EntityFrameworkCore.Migrations;

namespace API1.Data
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
