import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Employee {
  id: number;
  name: string;
  position: string;
  department: string;
  salary: number;
}

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private apiUrl = 'https://localhost:7107/api/employees';

  constructor(private http: HttpClient) { }

     // Get all
  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }

     // Get employee by ID
  getEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${id}`);
  }

     // Add 
  addEmployee(employee: any): Observable<string> {
    
    return this.http.post(this.apiUrl, employee, { responseType: 'text' });
  }

     // Update
  updateEmployee(id: number, employee: any): Observable<any> {
  return this.http.put(`${this.apiUrl}/${id}`, employee, { responseType: 'text' });
  }

     // Delete 
  deleteEmployee(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

 
}

