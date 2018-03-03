import { Injectable, Inject } from "@angular/core"
import { HttpClient} from "@angular/common/http"
import { Expense } from "../components/addexpense/expense"; 
import 'rxjs/add/operator/map'

@Injectable()
export class DataService {
    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) { }

    public getCurrentBudget() {
        return this.http.get(this.baseUrl + 'api/budgetplans/current');
    }

    public getAllCategories() {
        return this.http.get(this.baseUrl + 'api/categories');
    }

    public addNewExpense(newExpense: Expense) {
        return this.http.post(this.baseUrl + 'api/expenses', newExpense);
    }

    public getLastExpenses() {
        return this.http.get(this.baseUrl + 'api/expenses/last');
    }
}