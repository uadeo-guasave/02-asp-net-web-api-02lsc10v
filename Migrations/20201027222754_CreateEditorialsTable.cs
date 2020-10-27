using Microsoft.EntityFrameworkCore.Migrations;

namespace _02_asp_net_web_api_02lsc10v.Migrations
{
    public partial class CreateEditorialsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "editorials",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    address = table.Column<string>(maxLength: 200, nullable: false),
                    email = table.Column<string>(nullable: false),
                    website = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    postalcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editorials", x => x.id);
                });

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "editorials");
        }
    }
}
