﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectsControl.Migrations
{
    public partial class mymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DNIOfCustomer = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeDNI = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofHiring = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfFired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MobileNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    QuotationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialAmount = table.Column<float>(type: "real", nullable: false),
                    MecsaAmountMaterial = table.Column<float>(type: "real", nullable: false),
                    ViaticsAmount = table.Column<float>(type: "real", nullable: false),
                    UnexpectedAmount = table.Column<float>(type: "real", nullable: false),
                    KMAmount = table.Column<float>(type: "real", nullable: false),
                    TotalAmount = table.Column<float>(type: "real", nullable: false),
                    QuantityOfDays = table.Column<int>(type: "int", nullable: false),
                    QuantityOfEmployees = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserModification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.QuotationId);
                });

            migrationBuilder.CreateTable(
                name: "Week",
                columns: table => new
                {
                    WeekId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginOfWeek = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfWeek = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Week", x => x.WeekId);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfOffer = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleManName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    ActionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfAction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(340)", maxLength: 340, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_Actions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Of_Quos",
                columns: table => new
                {
                    Of_QuoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsModicable = table.Column<bool>(type: "bit", nullable: false),
                    OfferId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    QuotationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Of_Quos", x => x.Of_QuoId);
                    table.ForeignKey(
                        name: "FK_Of_Quos_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Of_Quos_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "QuotationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfProject = table.Column<int>(type: "int", nullable: false),
                    NumberOfTask = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OCDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Technician = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOver = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PendingAmount = table.Column<double>(type: "float", nullable: false),
                    TypeOfJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OfferId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asistances",
                columns: table => new
                {
                    AsistanceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WeekId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistances", x => x.AsistanceId);
                    table.ForeignKey(
                        name: "FK_Asistances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asistances_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asistances_Week_WeekId",
                        column: x => x.WeekId,
                        principalTable: "Week",
                        principalColumn: "WeekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfBill = table.Column<int>(type: "int", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bill_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expensives",
                columns: table => new
                {
                    ExpensiveId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModification = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expensives", x => x.ExpensiveId);
                    table.ForeignKey(
                        name: "FK_Expensives_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NotesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NoteDescription = table.Column<string>(type: "nvarchar(340)", maxLength: 340, nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NotesId);
                    table.ForeignKey(
                        name: "FK_Notes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfReport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Report_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtraHours",
                columns: table => new
                {
                    ExtraHourId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    AceptedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AsistanceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WeekId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraHours", x => x.ExtraHourId);
                    table.ForeignKey(
                        name: "FK_ExtraHours_Asistances_AsistanceId",
                        column: x => x.AsistanceId,
                        principalTable: "Asistances",
                        principalColumn: "AsistanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraHours_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraHours_Week_WeekId",
                        column: x => x.WeekId,
                        principalTable: "Week",
                        principalColumn: "WeekId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "DNIOfCustomer", "Name", "Sector" },
                values: new object[] { "8ad5a493-d428-4c36-b923-e70e433dc62d", 110, "Sample", "Private" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DateOfFired", "DateofHiring", "Email", "EmployeeDNI", "IsActive", "MobileNumber", "Name", "Position", "Salary" },
                values: new object[] { "73b8c82f-ace1-4d71-9989-70f5b3f86226", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "sample@grupomecsa.net", 1171292, true, 888, "Sample of name", "d", 100f });

            migrationBuilder.InsertData(
                table: "Quotations",
                columns: new[] { "QuotationId", "Author", "DateCreation", "Description", "KMAmount", "LastModification", "MaterialAmount", "MecsaAmountMaterial", "QuantityOfDays", "QuantityOfEmployees", "TotalAmount", "Type", "UnexpectedAmount", "UserModification", "ViaticsAmount" },
                values: new object[] { "001-2010", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sample Of Description", 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 0f, 0, 0, 0f, "Sample", 0f, null, 0f });

            migrationBuilder.InsertData(
                table: "Week",
                columns: new[] { "WeekId", "BeginOfWeek", "EndOfWeek", "NumberOfWeek" },
                values: new object[] { "01-2010", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "ActionId", "Author", "DateOfCreation", "Description", "EmployeeId", "IsActive", "Title", "TypeOfAction" },
                values: new object[] { "38a4bab7-1735-4a89-854a-477070e4aad5", "Sample of author", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "sample of description", "73b8c82f-ace1-4d71-9989-70f5b3f86226", true, "Sample of title", "sample of type" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "Author", "CustomerId", "DateOfCreation", "Description", "LastEdition", "NumberOfOffer", "SaleManName", "Title", "Type" },
                values: new object[] { "f8c7dc11-37ed-44e2-a2ad-239f86dff400", "Sample of Author", "8ad5a493-d428-4c36-b923-e70e433dc62d", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "sample of description", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), 1, "Sample of name", "Title Sample", "installation" });

            migrationBuilder.InsertData(
                table: "Of_Quos",
                columns: new[] { "Of_QuoId", "IsModicable", "OfferId", "QuotationId" },
                values: new object[] { "8696bf4e-d0e5-410d-8ad4-12abe53109a3", false, "f8c7dc11-37ed-44e2-a2ad-239f86dff400", "001-2010" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Amount", "BeginDate", "Currency", "CustomerId", "Details", "EmployeeId", "EndDate", "Estatus", "IsOver", "Manager", "NumberOfProject", "NumberOfTask", "OC", "OCDate", "OfferId", "PendingAmount", "ProjectName", "Technician", "TypeOfJob", "Ubication" },
                values: new object[] { "f3d19add-ede9-403c-9293-1458a277e734", 100f, new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "Dolar", "8ad5a493-d428-4c36-b923-e70e433dc62d", "Sample of details", "73b8c82f-ace1-4d71-9989-70f5b3f86226", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "In progress", false, "Sample of Name", 1, 1, "Oc Id Sample", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "f8c7dc11-37ed-44e2-a2ad-239f86dff400", 0.0, "Sample Of Project", "Sample", "Sample of Job", "San JoseCosta Rica" });

            migrationBuilder.InsertData(
                table: "Asistances",
                columns: new[] { "AsistanceId", "DateOfBegin", "DateOfEnd", "EmployeeId", "ProjectId", "WeekId" },
                values: new object[] { "c9c7b700-4591-4d0f-b0e2-a53d90bb2fcd", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "73b8c82f-ace1-4d71-9989-70f5b3f86226", "f3d19add-ede9-403c-9293-1458a277e734", "01-2010" });

            migrationBuilder.InsertData(
                table: "Bill",
                columns: new[] { "BillId", "Amount", "Author", "Currency", "DateOfCreation", "Notes", "NumberOfBill", "ProjectId" },
                values: new object[] { "9adbab1a-07c1-42b9-abb7-b4b98b132179", 1f, "Sample", "Dolar", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "Sample of notes", 1, "f3d19add-ede9-403c-9293-1458a277e734" });

            migrationBuilder.InsertData(
                table: "Expensives",
                columns: new[] { "ExpensiveId", "Amount", "Author", "Currency", "LastModification", "Note", "ProjectId", "Type" },
                values: new object[] { "4ec414e9-230b-42d0-abe2-3d4e6b1071d2", 1.12f, "Sample Of authot", "Dolar", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "Sample", "f3d19add-ede9-403c-9293-1458a277e734", "Km Cost" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NotesId", "Author", "DateOfCreation", "NoteDescription", "ProjectId", "Title" },
                values: new object[] { "4aecd389-df37-42f9-9352-3745fb9059f8", "Sample", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "Description of the action", "f3d19add-ede9-403c-9293-1458a277e734", "Sample" });

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "ReportId", "Author", "BeginDate", "EndDate", "Notes", "NumberOfReport", "ProjectId", "Status" },
                values: new object[] { "398acab3-4323-48f6-b149-a3d20cd56c44", "Sample of author", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), "sample of notes", "01-2010", "f3d19add-ede9-403c-9293-1458a277e734", "sample of estatus" });

            migrationBuilder.InsertData(
                table: "ExtraHours",
                columns: new[] { "ExtraHourId", "AceptedBy", "AsistanceId", "BeginTime", "EmployeeId", "EndTime", "IsPaid", "Notes", "Reason", "TypeOfHour", "WeekId" },
                values: new object[] { "788bc2c8-3d53-4086-b46e-f1c3ba8eb539", "Nyree", "c9c7b700-4591-4d0f-b0e2-a53d90bb2fcd", new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), null, new DateTime(2021, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), false, "as", "ad", "double", "01-2010" });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_EmployeeId",
                table: "Actions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistances_EmployeeId",
                table: "Asistances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistances_ProjectId",
                table: "Asistances",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistances_WeekId",
                table: "Asistances",
                column: "WeekId");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_ProjectId",
                table: "Bill",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensives_ProjectId",
                table: "Expensives",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraHours_AsistanceId",
                table: "ExtraHours",
                column: "AsistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraHours_EmployeeId",
                table: "ExtraHours",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraHours_WeekId",
                table: "ExtraHours",
                column: "WeekId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ProjectId",
                table: "Notes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Of_Quos_OfferId",
                table: "Of_Quos",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Of_Quos_QuotationId",
                table: "Of_Quos",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CustomerId",
                table: "Offers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeeId",
                table: "Projects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OfferId",
                table: "Projects",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ProjectId",
                table: "Report",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Expensives");

            migrationBuilder.DropTable(
                name: "ExtraHours");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Of_Quos");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Asistances");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Week");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
