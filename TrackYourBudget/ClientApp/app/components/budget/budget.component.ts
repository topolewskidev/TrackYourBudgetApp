import { Component, OnInit } from '@angular/core';
import { BudgetPlanWithCategories } from "./budget.plan.with.categories"
import { DataService } from "../../services/data.service"

@Component({
    selector: 'budget',
    templateUrl: './budget.component.html',
    styleUrls: ['./budget.component.css']
})
export class BudgetComponent implements OnInit {
    public budgetPlan: BudgetPlanWithCategories = new BudgetPlanWithCategories();

    constructor(private dataService: DataService) { }

    ngOnInit(): void {
        this.dataService.getCurrentBudget().subscribe(result => {
            this.onBudgetPlanDownload(result);
        }, error => console.error(error));
    }

    private onBudgetPlanDownload(result: any) {
        this.budgetPlan = result.json() as BudgetPlanWithCategories;
        console.log(this.budgetPlan.daysProgressPercentage);
    }
}