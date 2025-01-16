using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _77CarRental.Migrations
{
    /// <inheritdoc />
    public partial class seedidentitydata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02292724-32df-47b7-918f-c99021bc05cb", null, "Administrator", "ADMINISTRATOR" },
                    { "13a8004b-efd5-4093-b933-a004038b3b15", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "715e0dad-262e-4b50-a177-c606d6e042c5", 0, "d6306a6a-4399-4392-b1ac-6b9a8ea2bde3", "Users", "admin@77Rental.com", false, "Zayed", "Maatouq", false, null, null, "ADMIN@77RENTAL.COM", "AQAAAAIAAYagAAAAEGEeY2GHeqEen9xJ4IMcl1bFayI1JqiAF70Nm/RXxIEx313Y1yLqQ66zlXg4eF8t2g==", null, false, "77a513fb-9591-435e-9483-bf613ef9ed69", false, "admin@77Rental.com" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 4, 10, 2, 15, 2, 890, DateTimeKind.Local).AddTicks(5512), new DateTime(2024, 4, 7, 2, 15, 2, 890, DateTimeKind.Local).AddTicks(5501) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 4, 11, 2, 15, 2, 890, DateTimeKind.Local).AddTicks(5514), new DateTime(2024, 4, 7, 2, 15, 2, 890, DateTimeKind.Local).AddTicks(5513) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 4, 12, 2, 15, 2, 890, DateTimeKind.Local).AddTicks(5533), new DateTime(2024, 4, 7, 2, 15, 2, 890, DateTimeKind.Local).AddTicks(5533) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2024, 4, 10, 2, 15, 2, 890, DateTimeKind.Local).AddTicks(5549));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2024, 4, 11, 2, 15, 2, 890, DateTimeKind.Local).AddTicks(5552));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "02292724-32df-47b7-918f-c99021bc05cb", "715e0dad-262e-4b50-a177-c606d6e042c5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13a8004b-efd5-4093-b933-a004038b3b15");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "02292724-32df-47b7-918f-c99021bc05cb", "715e0dad-262e-4b50-a177-c606d6e042c5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02292724-32df-47b7-918f-c99021bc05cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "715e0dad-262e-4b50-a177-c606d6e042c5");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 4, 10, 2, 3, 50, 467, DateTimeKind.Local).AddTicks(3143), new DateTime(2024, 4, 7, 2, 3, 50, 467, DateTimeKind.Local).AddTicks(3130) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 4, 11, 2, 3, 50, 467, DateTimeKind.Local).AddTicks(3145), new DateTime(2024, 4, 7, 2, 3, 50, 467, DateTimeKind.Local).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 4, 12, 2, 3, 50, 467, DateTimeKind.Local).AddTicks(3147), new DateTime(2024, 4, 7, 2, 3, 50, 467, DateTimeKind.Local).AddTicks(3147) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2024, 4, 10, 2, 3, 50, 467, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2024, 4, 11, 2, 3, 50, 467, DateTimeKind.Local).AddTicks(3163));
        }
    }
}
