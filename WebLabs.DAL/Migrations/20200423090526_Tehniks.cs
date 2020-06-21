using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLabs.DAL.Migrations
{
    public partial class Tehniks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TehnikaGroups",
                columns: table => new
                {
                    TehnikaGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TehnikaGroups", x => x.TehnikaGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Tehniks",
                columns: table => new
                {
                    TehnikaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    ArendaDays = table.Column<int>(nullable: false),
                    Images = table.Column<string>(nullable: true),
                    TehnikaGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tehniks", x => x.TehnikaId);
                    table.ForeignKey(
                        name: "FK_Tehniks_TehnikaGroups_TehnikaGroupId",
                        column: x => x.TehnikaGroupId,
                        principalTable: "TehnikaGroups",
                        principalColumn: "TehnikaGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tehniks_TehnikaGroupId",
                table: "Tehniks",
                column: "TehnikaGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tehniks");

            migrationBuilder.DropTable(
                name: "TehnikaGroups");
        }
    }
}
