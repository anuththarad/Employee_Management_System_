import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService, Employee } from '../../services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  standalone: false,

  styleUrls: ['employee-form.component.css']
})

export class EmployeeFormComponent implements OnInit {

  employeeForm!: FormGroup;
  employeeId?: number;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router,
    private snackBar: MatSnackBar  
  ) { }

  ngOnInit(): void {
   
    this.employeeForm = this.fb.group({
      name: ['', Validators.required],
      position: ['', Validators.required],
      department: ['', Validators.required],
      salary: ['', [Validators.required, Validators.min(0)]]
    });

    this.employeeId = this.route.snapshot.params['id'];
    if (this.employeeId) {
      this.employeeService.getEmployee(this.employeeId).subscribe(emp => {
        this.employeeForm.patchValue(emp);
      });
    }
  }

onSubmit(): void {
  if (!this.employeeForm.valid) {
    this.snackBar.open('❌ Form is invalid. Please check the fields.', 'Close', { duration: 3000 });
    return;
  }

  if (this.employeeId) {

    // Update existing employee
    this.employeeService.updateEmployee(this.employeeId, this.employeeForm.value).subscribe({ 
      next: () => { this.snackBar.open('✅ Employee updated successfully!', 'Close', { duration: 3000 }); 
      this.router.navigate(['/']); }, 
      error: () => { this.snackBar.open('❌ Failed to update employee. Try again!', 'Close', { duration: 3000 }); } }); 

    } else {

    // Add new employee
   this.employeeService.addEmployee(this.employeeForm.value).subscribe({
    next: (res) => {
      console.log('Add response:', res);
      this.snackBar.open('✅ Employee added successfully!', 'Close', { duration: 3000 });
      this.router.navigate(['/']);
    },
    error: (err) => {
      console.error('Add error:', err);
      this.snackBar.open('❌ Failed to add employee. Try again!', 'Close', { duration: 3000 });
    }
  });
}

}
} 
  

    

