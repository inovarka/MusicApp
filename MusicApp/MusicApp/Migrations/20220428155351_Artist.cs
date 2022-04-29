using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicApp.Migrations
{
    public partial class Artist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Artists",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Artists", x => x.Id);
               });

            migrationBuilder.AddColumn<int>(
               name: "ArtistId",
               table: "Songs",
               type: "int",
               nullable: false,
               defaultValue: 0);


            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[,]
                {
                    { 1, "Doja Cat", "is an American rapper, singer, songwriter, and record producer" },
                    { 2, "Jews", "Jews or Jewish people are an ethnoreligious group and nation" },
                    { 3, "Migos", "an American hip hop trio from Lawrenceville, Georgia, founded in 2008" }
                });

            migrationBuilder.Sql("UPDATE \"Songs\" SET \"ArtistId\" = 1 WHERE \"Artist\" = 'Doja Cat'");
            migrationBuilder.Sql("UPDATE \"Songs\" SET \"ArtistId\" = 2 WHERE \"Artist\" = 'Jews'");
            migrationBuilder.Sql("UPDATE \"Songs\" SET \"ArtistId\" = 3 WHERE \"Artist\" = 'Migos'");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Songs");         

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Songs");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
