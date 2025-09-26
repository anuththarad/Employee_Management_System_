import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { EmployeeFormComponent } from './components/employee-form/employee-form.component';

const routes: Routes = [
  { path: '', component: EmployeeListComponent },           // Employee List
  { path: 'add', component: EmployeeFormComponent },        // Add Employee
  { path: 'edit/:id', component: EmployeeFormComponent },   // Edit Employee
  { path: '**', redirectTo: '' }                            // Redirect unknown routes
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

