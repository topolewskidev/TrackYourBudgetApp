import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment'; 
import { Category } from "./category"; 
import { Expense } from "./expense"; 
import { AlertService } from "../../services/alert.service"; 
import { DataService } from "../../services/data.service"; 

@Component({
    selector: 'expense-add',
    templateUrl: './add.expense.component.html'
})
export class AddExpenseComponent implements OnInit {
    public newExpense: FormGroup;
    public categories: Category[];

    constructor(
        private alertService: AlertService,
        private dataService: DataService) {
        this.newExpense = new FormGroup({
            selectedDate: new FormControl(moment().format("YYYY-MM-DD"), Validators.required),
            amount: new FormControl('', [Validators.required, Validators.pattern('^[0-9\\,\\.\\+\\-*\\/\\(\\)]*$')]),
            selectedCategory: new FormControl(null, Validators.required)
        });
    }

    ngOnInit(): void {
        this.dataService.getAllCategories().subscribe(result => {
            this.onCategoriesDownload(result);
        }, error => console.error(error));
    }

    public onAddButtonClick() {
        var newExpenseValues = this.newExpense.value;
        var newExpense = new Expense({
            categoryId: newExpenseValues.selectedCategory,
            amount: eval(newExpenseValues.amount.replace(/,/g, '.')),
            date: newExpenseValues.selectedDate
        });

        this.dataService.addNewExpense(newExpense)
            .subscribe(
                result => {
                    this.alertService.success("Dodano nowy wydatek");},
                error => {
                    this.alertService.error("Nie udało się dodać wydatku!");
                });
    }

    private onCategoriesDownload(result: any) {
        this.categories = result.json() as Category[];
    }
}