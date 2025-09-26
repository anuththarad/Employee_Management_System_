import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing-module';

import { AppComponent } from './app.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { RouterModule } from '@angular/router';
import { EmployeeFormComponent } from './components/employee-form/employee-form.component';

import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,            
    EmployeeListComponent,
    EmployeeFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,  
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatSnackBarModule,
   
  ],
  providers: [],
  bootstrap: [AppComponent]  
})
export class AppModule { }


