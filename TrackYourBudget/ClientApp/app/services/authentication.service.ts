import { Injectable, Inject, PLATFORM_ID } from "@angular/core"
import { HttpClient } from "@angular/common/http"
import { isPlatformBrowser } from '@angular/common';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
    private loggedIn = new BehaviorSubject<boolean>(false);

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        @Inject(PLATFORM_ID) private platformId: Object) {
        if (isPlatformBrowser(this.platformId)) {
            var currentUser = localStorage.getItem('currentUser');
            this.loggedIn.next(currentUser != null);
        }
    }

    public logIn(username: string, password: string) {
        return this.http.post<UserTokenDto>(this.baseUrl + 'api/users/login', {
            username: username,
            password: password
        })
        .map((response: any) => {
            let user = response;

            if (user && user.token) {
                this.loggedIn.next(true);
                localStorage.setItem('currentUser', JSON.stringify(user));
            }
        });
    }

    public logOut() {
        this.loggedIn.next(false);
        localStorage.removeItem('currentUser');
    }

    get isUserLoggedIn(): Observable<boolean> {
        return this.loggedIn.asObservable(); 
    }
}

class UserTokenDto {
    token: string;
    userId: string;
}