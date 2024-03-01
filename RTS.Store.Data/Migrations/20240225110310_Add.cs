using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RTS.Store.Web.Data.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24e5fc5a-5990-4175-b28c-fef31fc5e59a", "AQAAAAEAACcQAAAAEO87NoQmOKkWknb2aU9AQWtQmc50SFafAz7uzdsYmkpZonqNyCFJbhfBGYD/wOrs+A==", "34a88617-ca0a-4501-9fc8-0d6226b5a6c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75f22bc6-1a23-49e7-82ac-48e0261eba71", "AQAAAAEAACcQAAAAEFNGvX1MQ/9uICaTZtNfSjosn34Lmq7b209QAkoD1cZ8MEgInvTrZvCEcL3w/nMYig==", "ce7b5628-21a8-4cd7-8b15-dfce9b37cdb2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c11c7aa-d85a-462a-931e-adcc203d21f4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55dcdaaa-3c86-4651-94ca-c14e2feba023", "AQAAAAEAACcQAAAAEIhqwMn92m6lpmGV2S6DPb5YAqx3JnSncFuJVeGTn7E6BtUB8jArissAmTLIIhdL3Q==", "13843f39-67a2-451f-868e-d83c911067a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddcb42c8-a394-45cd-82ae-b1e71d5c693e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7205df59-2fc7-4f85-98b3-0df56e213bb2", "AQAAAAEAACcQAAAAEPQLf1lR/4odvbZm1Q4Z8/VZv4rjCsy9HvRlcX3rdaG7glxaYa2bPbL4g4n8gO/70Q==", "8925c8b8-2d38-4c3f-b7c4-4a2f5f716047" });
        }
    }
}
