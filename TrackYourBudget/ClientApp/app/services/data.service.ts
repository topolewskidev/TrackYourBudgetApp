import { Injectable, Inject } from "@angular/core"
import { Http, RequestOptions, Headers } from "@angular/http"
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Expense } from "../components/addexpense/expense"; 
import 'rxjs/add/operator/map'

@Injectable()
export class DataService {
    private loggedIn = new BehaviorSubject<boolean>(false);

    constructor(
        private http: Http,
        @Inject('BASE_URL') private baseUrl: string) { }

    public getCurrentBudget() {
        return this.http.get(this.baseUrl + 'api/budgetplans/current', this.getLoggedUserToken());
    }

    public getAllCategories() {
        return this.http.get(this.baseUrl + 'api/categories', this.getLoggedUserToken());
    }

    public addNewExpense(newExpense: Expense) {
        return this.http.post(this.baseUrl + 'api/expenses', newExpense, this.getLoggedUserToken());
    }

    public getLastExpenses() {
        return this.http.get(this.baseUrl + 'api/expenses/last', this.getLoggedUserToken());
    }

    private getLoggedUserToken() {
        let currentUser = JSON.parse(String(localStorage.getItem('currentUser')));
        if (currentUser && currentUser.token) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
            return new RequestOptions({ headers: headers });
        }
    }
}