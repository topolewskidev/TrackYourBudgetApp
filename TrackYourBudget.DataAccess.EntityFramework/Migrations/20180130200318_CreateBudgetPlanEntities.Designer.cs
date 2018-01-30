﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TrackYourBudget.DataAccess;

namespace TrackYourBudget.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180130200318_CreateBudgetPlanEntities")]
    partial class CreateBudgetPlanEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrackYourBudget.Model.BudgetPlans.BudgetPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("BudgetPlans");
                });

            modelBuilder.Entity("TrackYourBudget.Model.BudgetPlans.CategoryBudgetPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BudgetPlanId");

                    b.Property<int>("CategoryId");

                    b.Property<decimal>("StartAmount");

                    b.HasKey("Id");

                    b.HasIndex("BudgetPlanId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryBudgetPlans");
                });

            modelBuilder.Entity("TrackYourBudget.Model.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TrackYourBudget.Model.Expenses.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("TrackYourBudget.Model.BudgetPlans.CategoryBudgetPlan", b =>
                {
                    b.HasOne("TrackYourBudget.Model.BudgetPlans.BudgetPlan", "BudgetPlan")
                        .WithMany()
                        .HasForeignKey("BudgetPlanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TrackYourBudget.Model.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TrackYourBudget.Model.Expenses.Expense", b =>
                {
                    b.HasOne("TrackYourBudget.Model.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
