import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { AuthenticationService } from "../../services/authentication.service"

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit {
    public showMenu: Observable<boolean>;
    
    constructor(private authenticationService: AuthenticationService) {
        this.showMenu = this.authenticationService.isUserLoggedIn;
    }

    ngOnInit() {
        this.showMenu = this.authenticationService.isUserLoggedIn;
    }
}
