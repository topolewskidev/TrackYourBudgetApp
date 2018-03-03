import { Component, OnInit } from '@angular/core';
import { DataService } from "../../services/data.service"
import { ExpenseListItem } from "./expense.list.item"

@Component({
    templateUrl: './last.expenses.component.html',
})
export class LastExpensesComponent implements OnInit {
    expenses: ExpenseListItem[];

    constructor(private dataService: DataService) { }

    ngOnInit(): void {
        this.dataService.getLastExpenses().subscribe(result => {
            this.onLastExpensesDownload(result);
        }, error => console.error(error));
    }

    private onLastExpensesDownload(result: any) {
        this.expenses = result as ExpenseListItem[];
    }
}