import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from "../../services/authentication.service"
import { AlertService } from "../../services/alert.service"
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
    public loginModel: FormGroup;
    private returnUrl: string;

    constructor(
        private authenticationService: AuthenticationService,
        private alertService: AlertService,
        private http: Http,
        private router: Router,
        private route: ActivatedRoute,
        @Inject('BASE_URL') private baseUrl: string) {
        this.loginModel = new FormGroup({
            username: new FormControl("", Validators.required),
            password: new FormControl("", Validators.required),
        });
    }

    ngOnInit(): void {
        this.authenticationService.logOut();
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    public onLogInButtonClick() {
        this.authenticationService.logIn(this.loginModel.value.username, this.loginModel.value.password)
            .subscribe(
            data => {
                this.router.navigate([this.returnUrl]);
            },
            error => {
                this.alertService.error("Logowanie nie powiodło się!");
            });;
    }
}