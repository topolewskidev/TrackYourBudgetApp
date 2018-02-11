import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { LoginComponent } from './components/login/login.component';
import { AlertComponent } from './components/alert/alert.component';
import { BudgetComponent } from './components/budget/budget.component';
import { AddExpenseComponent } from "./components/addexpense/add.expense.component";
import { LastExpensesComponent } from "./components/lastexpenses/last.expenses.component";

import { AuthGuard } from "./helpers/auth.guard";
import { AuthenticationService } from "./services/authentication.service";
import { AlertService } from "./services/alert.service";
import { DataService } from "./services/data.service";

@NgModule({
    declarations: [
        AppComponent,
        AlertComponent,
        NavMenuComponent,
        AddExpenseComponent,
        LoginComponent,
        BudgetComponent,
        LastExpensesComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'budget', pathMatch: 'full', canActivate: [AuthGuard]  },
            { path: 'budget', component: BudgetComponent, canActivate: [AuthGuard] },
            { path: 'expenses/add', component: AddExpenseComponent, canActivate: [AuthGuard] },
            { path: 'expenses/last', component: LastExpensesComponent, canActivate: [AuthGuard] },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'budget', canActivate: [AuthGuard] }
        ])
    ],
    providers: [
        AuthGuard,
        AuthenticationService,
        AlertService,
        DataService
    ]
})
export class AppModuleShared {
}
