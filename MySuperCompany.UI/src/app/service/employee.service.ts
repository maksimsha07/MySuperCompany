import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../model/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  addEmpURL : string;
  getEmpURL : string;
  updateEmpUrl : string;
  deleteEmpUrl : string;

  constructor(private http : HttpClient) {

    this.addEmpURL = 'https://localhost:7153/Employee/Create';
    this.getEmpURL = 'https://localhost:7153/Employee/List';
    this.updateEmpUrl = 'https://localhost:7153/Employee/Update';
    this.deleteEmpUrl = 'https://localhost:7153/Employee/Delete';

   }

   addEmployee(emp : Employee): Observable<Employee> {
     return this.http.post<Employee>(this.addEmpURL,emp);
   }

   getAllEmployee(): Observable<Employee[]>{
     return this.http.get<Employee[]>(this.getEmpURL);
   }

   updateEmployee(emp :Employee) : Observable<Employee>{
     return this.http.put<Employee>(this.updateEmpUrl, emp);
   }

   deleteEmployee(emp : Employee) : Observable<Employee> {
     return this.http.post<Employee>(this.deleteEmpUrl, {Id: emp.id});
   }
  

}