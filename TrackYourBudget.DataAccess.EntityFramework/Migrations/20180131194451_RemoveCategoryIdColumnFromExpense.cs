using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TrackYourBudget.DataAccess.Migrations
{
    public partial class RemoveCategoryIdColumnFromExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CategoryBudgetPlans_CategoryBudgetPlanId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryBudgetPlanId",
                table: "Expenses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CategoryBudgetPlans_CategoryBudgetPlanId",
                table: "Expenses",
                column: "CategoryBudgetPlanId",
                principalTable: "CategoryBudgetPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CategoryBudgetPlans_CategoryBudgetPlanId",
                table: "Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryBudgetPlanId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CategoryBudgetPlans_CategoryBudgetPlanId",
                table: "Expenses",
                column: "CategoryBudgetPlanId",
                principalTable: "CategoryBudgetPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Categories_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
