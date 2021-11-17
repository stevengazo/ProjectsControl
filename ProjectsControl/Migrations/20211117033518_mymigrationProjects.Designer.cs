﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectsControl.Models;

#nullable disable

namespace ProjectsControl.Migrations
{
    [DbContext(typeof(DBProjectContext))]
    [Migration("20211117033518_mymigrationProjects")]
    partial class mymigrationProjects
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectsControl.Models.Action", b =>
                {
                    b.Property<string>("ActionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(340)
                        .HasColumnType("nvarchar(340)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfAction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActionId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Actions");

                    b.HasData(
                        new
                        {
                            ActionId = "e949a020-3f81-411e-842a-834082beb88b",
                            Author = "Sample of author",
                            DateOfCreation = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "sample of description",
                            EmployeeId = "35d8d628-487a-482f-afa1-28490996ae3c",
                            IsActive = true,
                            Title = "Sample of title",
                            TypeOfAction = "sample of type"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Asistance", b =>
                {
                    b.Property<string>("AsistanceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WeekId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AsistanceId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("WeekId");

                    b.ToTable("Asistances");

                    b.HasData(
                        new
                        {
                            AsistanceId = "d7123167-5e30-40c8-a57e-70060dcb9c62",
                            DateOfBegin = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            DateOfEnd = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeId = "35d8d628-487a-482f-afa1-28490996ae3c",
                            ProjectId = "1a50e611-f33b-4955-890b-006cd6ef1e21",
                            WeekId = "01-2010"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Bill", b =>
                {
                    b.Property<string>("BillId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfBill")
                        .HasColumnType("int");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BillId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Bill");

                    b.HasData(
                        new
                        {
                            BillId = "97a63f79-ece8-40fd-807d-40db5f28c3d6",
                            Amount = 1f,
                            Author = "Sample",
                            Currency = "Dolar",
                            DateOfCreation = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Notes = "Sample of notes",
                            NumberOfBill = 1,
                            ProjectId = "1a50e611-f33b-4955-890b-006cd6ef1e21"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DNIOfCustomer")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = "9dd8345f-2f74-4d4a-86e2-27b40f2f65f4",
                            DNIOfCustomer = 110,
                            Name = "Sample",
                            Sector = "Private"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfFired")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateofHiring")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeDNI")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MobileNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = "35d8d628-487a-482f-afa1-28490996ae3c",
                            DateOfBirth = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            DateOfFired = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            DateofHiring = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "sample@grupomecsa.net",
                            EmployeeDNI = 1171292,
                            IsActive = true,
                            MobileNumber = 888,
                            Name = "Sample of name",
                            Position = "d",
                            Salary = 100f
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Expensive", b =>
                {
                    b.Property<string>("ExpensiveId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpensiveId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Expensives");

                    b.HasData(
                        new
                        {
                            ExpensiveId = "8d6973ef-943d-489e-9d86-03ad02158bd8",
                            Amount = 1.12f,
                            Author = "Sample Of authot",
                            Currency = "Dolar",
                            LastModification = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Note = "Sample",
                            ProjectId = "1a50e611-f33b-4955-890b-006cd6ef1e21",
                            Type = "Km Cost"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.ExtraHour", b =>
                {
                    b.Property<string>("ExtraHourId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AceptedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AsistanceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BeginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeekId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ExtraHourId");

                    b.HasIndex("AsistanceId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("WeekId");

                    b.ToTable("ExtraHours");

                    b.HasData(
                        new
                        {
                            ExtraHourId = "e637a5aa-c39c-42cf-9558-1a62df435f1e",
                            AceptedBy = "Nyree",
                            AsistanceId = "d7123167-5e30-40c8-a57e-70060dcb9c62",
                            BeginTime = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            EmployeeId = "35d8d628-487a-482f-afa1-28490996ae3c",
                            EndTime = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            IsPaid = false,
                            Notes = "as",
                            Reason = "ad",
                            TypeOfHour = "double",
                            WeekId = "01-2010"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Notes", b =>
                {
                    b.Property<string>("NotesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteDescription")
                        .IsRequired()
                        .HasMaxLength(340)
                        .HasColumnType("nvarchar(340)");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("NotesId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            NotesId = "65baff66-f459-40af-87b1-9fad57cf7519",
                            Author = "Sample",
                            DateOfCreation = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            NoteDescription = "Description of the action",
                            ProjectId = "1a50e611-f33b-4955-890b-006cd6ef1e21",
                            Title = "Sample"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Of_Quo", b =>
                {
                    b.Property<string>("Of_QuoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsModicable")
                        .HasColumnType("bit");

                    b.Property<string>("OfferId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("QuotationId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Of_QuoId");

                    b.HasIndex("OfferId");

                    b.HasIndex("QuotationId");

                    b.ToTable("Of_Quos");

                    b.HasData(
                        new
                        {
                            Of_QuoId = "5314aacc-a89d-48b0-a25f-188d92f5ee3d",
                            IsModicable = false,
                            OfferId = "2b6a170d-b92d-416d-a8a8-37783848f175",
                            QuotationId = "001-2010"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Offer", b =>
                {
                    b.Property<string>("OfferId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastEdition")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfOffer")
                        .HasColumnType("int");

                    b.Property<string>("SaleManName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OfferId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            OfferId = "2b6a170d-b92d-416d-a8a8-37783848f175",
                            Author = "Sample of Author",
                            CustomerId = "9dd8345f-2f74-4d4a-86e2-27b40f2f65f4",
                            DateOfCreation = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "sample of description",
                            LastEdition = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            NumberOfOffer = 1,
                            SaleManName = "Sample of name",
                            Title = "Title Sample",
                            Type = "installation"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Project", b =>
                {
                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOver")
                        .HasColumnType("bit");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfOffer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfProject")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfTask")
                        .HasColumnType("int");

                    b.Property<string>("OC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OCDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("PendingAmount")
                        .HasColumnType("float");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Technician")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = "1a50e611-f33b-4955-890b-006cd6ef1e21",
                            Amount = 100f,
                            BeginDate = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Currency = "Dolar",
                            CustomerId = "9dd8345f-2f74-4d4a-86e2-27b40f2f65f4",
                            Details = "Sample of details",
                            EmployeeId = "35d8d628-487a-482f-afa1-28490996ae3c",
                            EndDate = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Estatus = "In progress",
                            IsOver = false,
                            Manager = "Sample of Name",
                            NumberOfOffer = "PS1",
                            NumberOfProject = 1,
                            NumberOfTask = 1,
                            OC = "Oc Id Sample",
                            OCDate = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            PendingAmount = 0.0,
                            ProjectName = "Sample Of Project",
                            Technician = "Sample",
                            TypeOfJob = "Sample of Job",
                            Ubication = "San JoseCosta Rica"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Quotation", b =>
                {
                    b.Property<string>("QuotationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("KMAmount")
                        .HasColumnType("real");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime2");

                    b.Property<float>("MaterialAmount")
                        .HasColumnType("real");

                    b.Property<float>("MecsaAmountMaterial")
                        .HasColumnType("real");

                    b.Property<int>("QuantityOfDays")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOfEmployees")
                        .HasColumnType("int");

                    b.Property<float>("TotalAmount")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("UnexpectedAmount")
                        .HasColumnType("real");

                    b.Property<string>("UserModification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ViaticsAmount")
                        .HasColumnType("real");

                    b.HasKey("QuotationId");

                    b.ToTable("Quotations");

                    b.HasData(
                        new
                        {
                            QuotationId = "001-2010",
                            DateCreation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Of Description",
                            KMAmount = 0f,
                            LastModification = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialAmount = 0f,
                            MecsaAmountMaterial = 0f,
                            QuantityOfDays = 0,
                            QuantityOfEmployees = 0,
                            TotalAmount = 0f,
                            Type = "Sample",
                            UnexpectedAmount = 0f,
                            ViaticsAmount = 0f
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Report", b =>
                {
                    b.Property<string>("ReportId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfReport")
                        .HasColumnType("int");

                    b.Property<string>("ProjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReportId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Report");

                    b.HasData(
                        new
                        {
                            ReportId = "ecb17b75-e8b7-47ef-a589-42761599b9b1",
                            Author = "Sample of author",
                            BeginDate = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            EndDate = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Notes = "sample of notes",
                            NumberOfReport = 1,
                            ProjectId = "1a50e611-f33b-4955-890b-006cd6ef1e21",
                            Status = "sample of estatus"
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Week", b =>
                {
                    b.Property<string>("WeekId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BeginOfWeek")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndOfWeek")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumberOfWeek")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeekId");

                    b.ToTable("Week");

                    b.HasData(
                        new
                        {
                            WeekId = "01-2010",
                            BeginOfWeek = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            EndOfWeek = new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("ProjectsControl.Models.Action", b =>
                {
                    b.HasOne("ProjectsControl.Models.Employee", "Employee")
                        .WithMany("Actions")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ProjectsControl.Models.Asistance", b =>
                {
                    b.HasOne("ProjectsControl.Models.Employee", "Employee")
                        .WithMany("Asistances")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("ProjectsControl.Models.Project", "Project")
                        .WithMany("Asistances")
                        .HasForeignKey("ProjectId");

                    b.HasOne("ProjectsControl.Models.Week", "Week")
                        .WithMany("Asistances")
                        .HasForeignKey("WeekId");

                    b.Navigation("Employee");

                    b.Navigation("Project");

                    b.Navigation("Week");
                });

            modelBuilder.Entity("ProjectsControl.Models.Bill", b =>
                {
                    b.HasOne("ProjectsControl.Models.Project", "Project")
                        .WithMany("Bills")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectsControl.Models.Expensive", b =>
                {
                    b.HasOne("ProjectsControl.Models.Project", "Project")
                        .WithMany("Expensives")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectsControl.Models.ExtraHour", b =>
                {
                    b.HasOne("ProjectsControl.Models.Asistance", "Asistance")
                        .WithMany("ExtraHours")
                        .HasForeignKey("AsistanceId");

                    b.HasOne("ProjectsControl.Models.Employee", "Employee")
                        .WithMany("ExtraHours")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("ProjectsControl.Models.Week", "Week")
                        .WithMany("ExtraHours")
                        .HasForeignKey("WeekId");

                    b.Navigation("Asistance");

                    b.Navigation("Employee");

                    b.Navigation("Week");
                });

            modelBuilder.Entity("ProjectsControl.Models.Notes", b =>
                {
                    b.HasOne("ProjectsControl.Models.Project", "Project")
                        .WithMany("Notes")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectsControl.Models.Of_Quo", b =>
                {
                    b.HasOne("ProjectsControl.Models.Offer", "Offer")
                        .WithMany("Of_Quos")
                        .HasForeignKey("OfferId");

                    b.HasOne("ProjectsControl.Models.Quotation", "Quotation")
                        .WithMany("Of_Quos")
                        .HasForeignKey("QuotationId");

                    b.Navigation("Offer");

                    b.Navigation("Quotation");
                });

            modelBuilder.Entity("ProjectsControl.Models.Offer", b =>
                {
                    b.HasOne("ProjectsControl.Models.Customer", "Customer")
                        .WithMany("Offers")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ProjectsControl.Models.Project", b =>
                {
                    b.HasOne("ProjectsControl.Models.Customer", "Customer")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerId");

                    b.HasOne("ProjectsControl.Models.Employee", "Employee")
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ProjectsControl.Models.Report", b =>
                {
                    b.HasOne("ProjectsControl.Models.Project", "Project")
                        .WithMany("Reports")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectsControl.Models.Asistance", b =>
                {
                    b.Navigation("ExtraHours");
                });

            modelBuilder.Entity("ProjectsControl.Models.Customer", b =>
                {
                    b.Navigation("Offers");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ProjectsControl.Models.Employee", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Asistances");

                    b.Navigation("ExtraHours");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ProjectsControl.Models.Offer", b =>
                {
                    b.Navigation("Of_Quos");
                });

            modelBuilder.Entity("ProjectsControl.Models.Project", b =>
                {
                    b.Navigation("Asistances");

                    b.Navigation("Bills");

                    b.Navigation("Expensives");

                    b.Navigation("Notes");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("ProjectsControl.Models.Quotation", b =>
                {
                    b.Navigation("Of_Quos");
                });

            modelBuilder.Entity("ProjectsControl.Models.Week", b =>
                {
                    b.Navigation("Asistances");

                    b.Navigation("ExtraHours");
                });
#pragma warning restore 612, 618
        }
    }
}