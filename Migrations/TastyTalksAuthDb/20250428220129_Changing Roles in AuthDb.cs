using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasty_Talks_BackEnd.Migrations.TastyTalksAuthDb
{
    /// <inheritdoc />
    public partial class ChangingRolesinAuthDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b12cc102-d6aa-4663-bd59-a21e2b1e48cf",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Customer", "CUSTOMER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b12cc102-d6aa-4663-bd59-a21e2b1e48cf",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "User", "USER" });
        }
    }
}
