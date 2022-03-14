using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "MaximumHourLimit",
                columns: table => new
                {
                    MaximumHourLimitId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LimitPerDay = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaximumHourLimit", x => x.MaximumHourLimitId);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    EmployeeSalaryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinimumHour = table.Column<decimal>(type: "TEXT", nullable: false),
                    MaximumHour = table.Column<decimal>(type: "TEXT", nullable: true),
                    RatePerHour = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.EmployeeSalaryId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendance",
                columns: table => new
                {
                    EmployeeAttendanceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalHours = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendance", x => x.EmployeeAttendanceId);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendance_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCheckIn",
                columns: table => new
                {
                    EmployeeCheckInID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Day = table.Column<string>(type: "TEXT", nullable: true),
                    CheckIn = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCheckIn", x => x.EmployeeCheckInID);
                    table.ForeignKey(
                        name: "FK_EmployeeCheckIn_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCheckOut",
                columns: table => new
                {
                    EmployeeCheckOutId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Day = table.Column<string>(type: "TEXT", nullable: true),
                    CheckOut = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCheckOut", x => x.EmployeeCheckOutId);
                    table.ForeignKey(
                        name: "FK_EmployeeCheckOut_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary",
                columns: table => new
                {
                    EmployeeSalaryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalWorkingHour = table.Column<decimal>(type: "TEXT", nullable: false),
                    Rate = table.Column<decimal>(type: "TEXT", nullable: false),
                    NetAmount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary", x => x.EmployeeSalaryId);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Address", "FullName" },
                values: new object[] { 1, "Janakpur", "Bijay Mandal" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Address", "FullName" },
                values: new object[] { 2, "Janakpur", "Sunil Mandal" });

            migrationBuilder.InsertData(
                table: "MaximumHourLimit",
                columns: new[] { "MaximumHourLimitId", "LimitPerDay" },
                values: new object[] { 1, 24m });

            migrationBuilder.InsertData(
                table: "Salary",
                columns: new[] { "EmployeeSalaryId", "MaximumHour", "MinimumHour", "RatePerHour" },
                values: new object[] { 1, 20m, 0m, 50m });

            migrationBuilder.InsertData(
                table: "Salary",
                columns: new[] { "EmployeeSalaryId", "MaximumHour", "MinimumHour", "RatePerHour" },
                values: new object[] { 2, 40m, 20m, 70m });

            migrationBuilder.InsertData(
                table: "Salary",
                columns: new[] { "EmployeeSalaryId", "MaximumHour", "MinimumHour", "RatePerHour" },
                values: new object[] { 3, null, 40m, 150m });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendance_EmployeeId_Date",
                table: "EmployeeAttendance",
                columns: new[] { "EmployeeId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCheckIn_EmployeeId",
                table: "EmployeeCheckIn",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCheckOut_EmployeeId",
                table: "EmployeeCheckOut",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_EmployeeId_StartDate_EndDate",
                table: "EmployeeSalary",
                columns: new[] { "EmployeeId", "StartDate", "EndDate" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendance");

            migrationBuilder.DropTable(
                name: "EmployeeCheckIn");

            migrationBuilder.DropTable(
                name: "EmployeeCheckOut");

            migrationBuilder.DropTable(
                name: "EmployeeSalary");

            migrationBuilder.DropTable(
                name: "MaximumHourLimit");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
