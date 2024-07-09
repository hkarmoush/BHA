﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BHA.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AcquisitionCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CustomerLifetimeValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CustomerSatisfactionScore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NetPromoterScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CustomerRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AcquisitionCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CustomerEffortScore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CustomerLifetimeValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CustomerProfit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CustomerRevenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CustomerSatisfactionScore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsLost")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNewCustomer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRetained")
                        .HasColumnType("bit");

                    b.Property<int>("NetPromoterScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CustomerRecords");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FinancialRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AccountsPayable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AccountsReceivable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Amortization")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CapitalEmployed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Cash")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CostOfGoodsSold")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Depreciation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EnergyConsumption")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InterestExpense")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Inventory")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OperatingExpenses")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OperatingIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TaxExpense")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAssets")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalEquity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalLiabilities")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("FinancialRecords");
                });

            modelBuilder.Entity("HRRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AbsenteeismDays")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDiverse")
                        .HasColumnType("bit");

                    b.Property<int>("ProductivityScore")
                        .HasColumnType("int");

                    b.Property<int>("SatisfactionScore")
                        .HasColumnType("int");

                    b.Property<int>("TrainingHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HRRecords");
                });

            modelBuilder.Entity("Kpi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kpis");
                });

            modelBuilder.Entity("SalesRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SalesRecords");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
