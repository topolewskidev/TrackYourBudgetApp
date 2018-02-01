using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TrackYourBudget.DataAccess.Migrations
{
    public partial class AddCategoryBudgetPlanIdColumnToExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryBudgetPlanId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryBudgetPlanId",
                table: "Expenses",
                column: "CategoryBudgetPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_CategoryBudgetPlans_CategoryBudgetPlanId",
                table: "Expenses",
                column: "CategoryBudgetPlanId",
                principalTable: "CategoryBudgetPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_CategoryBudgetPlans_CategoryBudgetPlanId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CategoryBudgetPlanId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CategoryBudgetPlanId",
                table: "Expenses");
        }
    }
}
