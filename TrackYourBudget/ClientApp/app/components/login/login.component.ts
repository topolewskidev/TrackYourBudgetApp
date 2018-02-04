import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    public loginModel: FormGroup;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    ngOnInit(): void {
        this.loginModel = new FormGroup({
            username: new FormControl("", Validators.required),
            password: new FormControl("", Validators.required),
        });
    }

    public onLogInButtonClick() {
        this.http.post(this.baseUrl + 'api/users/login', this.loginModel.value)
            .subscribe(result => { });
    }
}