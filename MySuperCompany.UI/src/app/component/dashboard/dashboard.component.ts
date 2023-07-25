import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms'
import { Employee } from 'src/app/model/employee';
import { EmployeeService } from 'src/app/service/employee.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  empDetail !: FormGroup;
  empObj : Employee = new Employee();
  empList : Employee[] = [];

  constructor(private formBuilder : FormBuilder, private empService : EmployeeService) { }

  ngOnInit(): void {

    this.getAllEmployee();

    this.empDetail = this.formBuilder.group({
        Id: [''],
        Department: [''],
        Surname: [''],
        FirstName: [''],
        Patronymic: [''],
        BirthDate: [''],
        DateOfEmployment: [''],
        Salary: [''],
    });    

  }

  addEmployee() {
    console.log(this.empDetail);
    this.empObj.id = this.empDetail.value.Id;
    this.empObj.firstName = this.empDetail.value.FirstName;
    this.empObj.surname = this.empDetail.value.Surname;
    this.empObj.patronymic = this.empDetail.value.Patronymic;
    this.empObj.department = this.empDetail.value.Department;
    this.empObj.birthDate = this.empDetail.value.BirthDate;
    this.empObj.dateOfEmployment = this.empDetail.value.DateOfEmployment;
    this.empObj.salary = this.empDetail.value.Salary;

    this.empService.addEmployee(this.empObj).subscribe({next: (result) => {
        console.log(result);
        this.getAllEmployee();
    },
    error: (error) => {
        console.log(error);
      }});

  }

  getAllEmployee() {
    this.empService.getAllEmployee().subscribe({next: (result) => {
        this.empList = result;
    },
    error: (error) => {
        console.log("error while fetching data.")
      }});
  }

  editEmployee(emp : Employee) {
    this.empDetail.controls['Id'].setValue(emp.id);
    this.empDetail.controls['FirstName'].setValue(emp.firstName);
    this.empDetail.controls['Surname'].setValue(emp.surname);
    this.empDetail.controls['Patronymic'].setValue(emp.patronymic);
    this.empDetail.controls['Department'].setValue(emp.department);
    this.empDetail.controls['BirthDate'].setValue(emp.birthDate);
    this.empDetail.controls['DateOfEmployment'].setValue(emp.dateOfEmployment);
    this.empDetail.controls['Salary'].setValue(emp.salary);


  }

  updateEmployee() {
    this.empObj.id = this.empDetail.value.Id;
    this.empObj.firstName = this.empDetail.value.FirstName;
    this.empObj.surname = this.empDetail.value.Surname;
    this.empObj.patronymic = this.empDetail.value.Patronymic;
    this.empObj.department = this.empDetail.value.Department;
    this.empObj.birthDate = this.empDetail.value.BirthDate;
    this.empObj.dateOfEmployment = this.empDetail.value.DateOfEmployment;
    this.empObj.salary = this.empDetail.value.Salary;

    this.empService.updateEmployee(this.empObj).subscribe({next: (result) => {
        console.log(result);
        this.getAllEmployee();
    },
    error: (error) => {
        console.log(error);
      }});
  }

  deleteEmployee(emp : Employee) {

    this.empService.deleteEmployee(emp).subscribe({next: (result) => {
        this.getAllEmployee();
    },
    error: (error) => {
        console.log(error);
      }});
  }

}