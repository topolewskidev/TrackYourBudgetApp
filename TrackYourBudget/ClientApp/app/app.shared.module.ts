import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { BudgetComponent } from './components/budget/budget.component';
import { AddExpenseComponent } from "./components/addexpense/add.expense.component";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        AddExpenseComponent,
        BudgetComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'budget', pathMatch: 'full' },
            { path: 'budget', component: BudgetComponent },
            { path: 'expenses/add', component: AddExpenseComponent },
            { path: '**', redirectTo: 'budget' }
        ])
    ]
})
export class AppModuleShared {
}
