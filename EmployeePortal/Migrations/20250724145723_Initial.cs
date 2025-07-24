using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeePortal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designations_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, false, "IT" },
                    { 2, false, "HR" },
                    { 3, false, "Sales" },
                    { 4, false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTypes",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, false, "Permanent" },
                    { 2, false, "Temporary" },
                    { 3, false, "Contract" },
                    { 4, false, "Intern" }
                });

            migrationBuilder.InsertData(
                table: "Designations",
                columns: new[] { "Id", "DepartmentId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 1, false, "Software Developer" },
                    { 2, 1, false, "System Administrator" },
                    { 3, 1, false, "Network Engineer" },
                    { 4, 2, false, "HR Specialist" },
                    { 5, 2, false, "HR Manager" },
                    { 6, 2, false, "Talent Acquisition Coordinator" },
                    { 7, 3, false, "Sales Executive" },
                    { 8, 3, false, "Sales Manager" },
                    { 9, 3, false, "Account Executive" },
                    { 10, 4, false, "Office Manager" },
                    { 11, 4, false, "Executive Assistant" },
                    { 12, 4, false, "Receptionist" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DepartmentId", "DesignationId", "Email", "EmployeeTypeId", "FullName", "Gender", "HireDate", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "johnd@gmail.com", 1, "John Doe", "Male", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 60000m },
                    { 2, new DateTime(1985, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, "janed@gmail.com", 1, "Jane Smith", "Female", new DateTime(2018, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 80000m },
                    { 3, new DateTime(1992, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7, "samw@gmail.com", 3, "Sam Wilson", "Male", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m },
                    { 4, new DateTime(1995, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 11, "wandam@gmail.com", 2, "Wanda Maximoff", "Female", new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 40000m },
                    { 5, new DateTime(1989, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "tonys@gmail.com", 1, "Tony Stark", "Male", new DateTime(2019, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 95000m },
                    { 6, new DateTime(1987, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, "natashar@gmail.com", 1, "Natasha Romanoff", "Female", new DateTime(2017, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 75000m },
                    { 7, new DateTime(1990, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, "alexeis@gmail.com", 3, "Alexei Shostakov", "Male", new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 85000m },
                    { 8, new DateTime(1993, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 10, "yelenab@gmail.com", 1, "Yelena Belova", "Female", new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 65000m },
                    { 9, new DateTime(1997, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, "sues@gmail.com", 3, "Sue Storm", "Female", new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 52000m },
                    { 10, new DateTime(1986, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, "stever@gmail.com", 2, "Steve Rogers", "Other", new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 55000m },
                    { 11, new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7, "morgans@gmail.com", 4, "Morgan Stark", "Female", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m },
                    { 12, new DateTime(1996, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 12, "buckyb@gmail.com", 2, "Bucky Barnes", "Male", new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 38000m },
                    { 13, new DateTime(1991, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "peterp@gmail.com", 1, "Peter Parker", "Male", new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65000m },
                    { 14, new DateTime(1988, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, "pepperp@gmail.com", 1, "Pepper Potts", "Female", new DateTime(2017, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 76000m },
                    { 15, new DateTime(1998, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "mokgositeboho77@gmail.com", 1, "Teboho Mokgosi", "Male", new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 72000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Designations_DepartmentId",
                table: "Designations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
