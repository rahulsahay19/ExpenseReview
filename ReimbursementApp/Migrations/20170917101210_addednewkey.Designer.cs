﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ReimbursementApp.DbContext;
using System;

namespace ReimbursementApp.Migrations
{
    [DbContext(typeof(ExpenseReviewDbContext))]
    [Migration("20170917101210_addednewkey")]
    partial class addednewkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReimbursementApp.Model.Approver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApprovedDate");

                    b.Property<int>("ApproverId");

                    b.Property<int>("ExpenseId");

                    b.Property<string>("Name");

                    b.Property<string>("Remarks")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Approvers");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int?>("ExpenseId");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("ExpenseDate")
                        .IsRequired();

                    b.Property<string>("ExpenseDetails")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("SubmitDate")
                        .IsRequired();

                    b.Property<double>("TotalAmount");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ReimbursementApp.Model.Employee", b =>
                {
                    b.HasOne("ReimbursementApp.Model.Expense")
                        .WithMany("Employees")
                        .HasForeignKey("ExpenseId");
                });
#pragma warning restore 612, 618
        }
    }
}
