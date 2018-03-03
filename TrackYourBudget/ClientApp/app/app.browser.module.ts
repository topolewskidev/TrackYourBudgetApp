import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppModuleShared } from './app.module';
import { AppComponent } from './components/app/app.component';

import { ToastrModule } from 'ngx-toastr';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        AppModuleShared,
        ToastrModule.forRoot()
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl },
        { provide: LOCALE_ID, useValue: 'pl' }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
