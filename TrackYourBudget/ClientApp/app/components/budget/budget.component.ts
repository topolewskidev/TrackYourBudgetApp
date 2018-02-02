import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { BudgetPlanWithCategories } from "./budget.plan.with.categories"

@Component({
    selector: 'budget',
    templateUrl: './budget.component.html',
})
export class BudgetComponent implements OnInit {
    public budgetPlan: BudgetPlanWithCategories = new BudgetPlanWithCategories();

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit(): void {
        this.http.get(this.baseUrl + 'api/budgetplans/current').subscribe(result => {
            this.onBudgetPlanDownload(result);
        }, error => console.error(error));
    }

    private onBudgetPlanDownload(result: any) {
        this.budgetPlan = result.json() as BudgetPlanWithCategories;
    }
}