import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment'; 

@Component({
    selector: 'expense-add',
    templateUrl: './addexpense.component.html'
})
export class AddExpenseComponent implements OnInit {
    public newExpense: FormGroup;
    public categories: Category[];
    public showMessage: boolean = false;
    public message: string = "";

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.newExpense = new FormGroup({
            selectedDate: new FormControl(moment().format("YYYY-MM-DD"), Validators.required),
            amount: new FormControl(0, Validators.required),
            selectedCategory: new FormControl(null, Validators.required)
        });

        this.newExpense.valueChanges.subscribe(() => {
            this.showMessage = false;
            this.message = "";
        });
    }

    ngOnInit(): void {
        this.http.get(this.baseUrl + 'api/categories').subscribe(result => {
            this.onCategoriesDownload(result);
        }, error => console.error(error));
    }

    public onAddButtonClick() {
        var newExpenseValues = this.newExpense.value;
        var newExpense = new Expense({
            categoryId: newExpenseValues.selectedCategory,
            amount: newExpenseValues.amount,
            date: newExpenseValues.selectedDate
        });

        this.http.post(this.baseUrl + 'api/expenses', newExpense)
            .subscribe(result => {
                this.showMessage = true;
                this.message = "Dodano nowy wydatek!";
            });
    }

    private onCategoriesDownload(result: any) {
        this.categories = result.json() as Category[];
    }
}

class Category {
    id: string;
    name: string;
}

class Expense {
    categoryId: number;
    amount: number;
    date: Date;

    public constructor(init?: Partial<Expense>) {
        Object.assign(this, init);
    }
}