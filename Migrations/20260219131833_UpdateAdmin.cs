using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeknoForce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Username" },
                values: new object[] { "AQAAAAIAAYagAAAAEFkodoXNFnTfE+8ceA/4KY7CG8LJDYnQQvx6e/NPesfppjIJThNqevosZn8It0eooQ==", "teknoforce" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Username" },
                values: new object[] { "AQAAAAIAAYagAAAAECuhpl/ZDSLgpJBTPg1rRIQqowB2y4ebjCIapPClrauJOFaCk0395AvxLaKbRpLsDA==", "admin" });
        }
    }
}
