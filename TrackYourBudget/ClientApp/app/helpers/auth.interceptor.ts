import { Injectable } from "@angular/core";
import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest
    } from "@angular/common/http";
import { Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/catch";
import "rxjs/add/observable/throw";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(
        private router: Router) {
    }

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let loggedUserToken = this.getLoggedUserToken();

        if (loggedUserToken != null && loggedUserToken != undefined) {
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${loggedUserToken}`
                }
            });
        }

        return next
            .handle(req)
            .map((event: HttpEvent<any>) => {
                return event;
            })
            .catch((err: any) => {
                if (err instanceof HttpErrorResponse) {
                    if (err.status === 403) {
                    }
                }

                return Observable.throw(err);
            });
    }

    private getLoggedUserToken() {
        let currentUser = JSON.parse(String(localStorage.getItem("currentUser")));
        if (currentUser && currentUser.token) {
            return currentUser.token;
        }
    }
}