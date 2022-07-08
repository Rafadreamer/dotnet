using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trabalhoaula.Migrations
{
    public partial class updatetree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Billings_BillingId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_BillingId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "BillingId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Billings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Billings_PersonId",
                table: "Billings",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_People_PersonId",
                table: "Billings",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_People_PersonId",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_Billings_PersonId",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Billings");

            migrationBuilder.AddColumn<int>(
                name: "BillingId",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_BillingId",
                table: "People",
                column: "BillingId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Billings_BillingId",
                table: "People",
                column: "BillingId",
                principalTable: "Billings",
                principalColumn: "Id");
        }
    }
}
