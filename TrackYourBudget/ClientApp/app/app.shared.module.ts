import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { LoginComponent } from './components/login/login.component';
import { BudgetComponent } from './components/budget/budget.component';
import { AddExpenseComponent } from "./components/addexpense/add.expense.component";
import { AuthGuard } from "./helpers/auth.guard";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        AddExpenseComponent,
        LoginComponent,
        BudgetComponent
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
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'budget', canActivate: [AuthGuard] }
        ])
    ],
    providers: [
        AuthGuard
    ]
})
export class AppModuleShared {
}
