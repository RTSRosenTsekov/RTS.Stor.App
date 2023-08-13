using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTS.Store.Web.Data.Migrations
{
    public partial class SamtingsWrong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7aca1be1-5bfa-4aa5-9d3c-8ba279f55a57", "AQAAAAEAACcQAAAAEAFLjiQh1tck6+SU+mTcjZbL4CLNKDiN5m0Vu5xstZrNA1SvUbq/Ks9ObpLs7Qw0Cg==", "35f3952c-44a7-4930-8fbf-502f0a7361e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77b4e520-1b22-40fc-82a1-3ce28b7f4395", "AQAAAAEAACcQAAAAEO9JjpWqGvy1WheTLUaenE560sx4yw+by6u7+1SCm1FaL4bC+GvUakf+bsa/n2XEdg==", "706b91ff-605f-45aa-b23d-eedc7922e099" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7205025f-2646-40a9-a11a-851ee9ff00c2", "AQAAAAEAACcQAAAAEC/OBYyaBnBNvWziIuKDnE/HhZAB/DOGC6j8ZQmAv/PkcypjMYYIFv/03Gt+M81wPg==", "1fbae9e0-944e-4e1f-90b7-1301ef60d5e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df0df705-a18d-49b5-8138-dc455f5efebb", "AQAAAAEAACcQAAAAEBguR4wikd39lPPgjmKzfjEMBl1jbyBM3CQJMip3Uywv/5WY8MSucTgr26LOMag0Rg==", "540c07e2-8148-46da-a844-45089488663e" });
        }
    }
}
