import { Injectable, PLATFORM_ID, Inject } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { isPlatformServer } from '@angular/common';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router, @Inject(PLATFORM_ID) private platformId: Object) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (isPlatformServer(this.platformId)) {
            return false;
        }

        if (localStorage.getItem('currentUser')) {
            return true;
        }

        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}