using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _77CarRental.Migrations
{
    /// <inheritdoc />
    public partial class newmigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                column: "Price",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "Price",
                value: 350.0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 3,
                column: "Price",
                value: 120.0);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 3, 29, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7472), new DateTime(2024, 3, 26, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7474), new DateTime(2024, 3, 26, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 3, 31, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7475), new DateTime(2024, 3, 26, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2024, 3, 29, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2024, 3, 30, 21, 55, 49, 409, DateTimeKind.Local).AddTicks(7489));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 3, 29, 21, 18, 23, 758, DateTimeKind.Local).AddTicks(9114), new DateTime(2024, 3, 26, 21, 18, 23, 758, DateTimeKind.Local).AddTicks(9104) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 3, 30, 21, 18, 23, 758, DateTimeKind.Local).AddTicks(9116), new DateTime(2024, 3, 26, 21, 18, 23, 758, DateTimeKind.Local).AddTicks(9116) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "End_Date", "Start_Date" },
                values: new object[] { new DateTime(2024, 3, 31, 21, 18, 23, 758, DateTimeKind.Local).AddTicks(9118), new DateTime(2024, 3, 26, 21, 18, 23, 758, DateTimeKind.Local).AddTicks(9118) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "ReviewDate",
                value: new DateTime(2024, 3, 29, 21, 18, 23, 758, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "ReviewDate",
                value: new DateTime(2024, 3, 30, 21, 18, 23, 758, DateTimeKind.Local).AddTicks(9132));
        }
    }
}
