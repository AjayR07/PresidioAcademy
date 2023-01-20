import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Employee} from "../interfaces/Employee";
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private http: HttpClient;
  @Inject('BASE_URL') private baseUrl: string;

  private getEmp = new BehaviorSubject<Employee[]>([]);
  getEmployees = this.getEmp.asObservable();
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
    this.getAllEmployees();
  }

  getAllEmployees(){
    return this.http.get<Employee[]>(this.baseUrl + 'Employee/all').subscribe(employees =>this.getEmp.next(employees))
  }

  deleteEmployee(id: number) {
    this.http.delete(this.baseUrl + 'Employee?id='+id).subscribe(() => this.getAllEmployees());
  }

  createEmployee(employee: Employee) {
    return this.http.post(this.baseUrl + 'Employee',employee).subscribe( ()=> this.getAllEmployees());
  }

  updateEmployee(employee: Employee) {
    return this.http.put(this.baseUrl + 'Employee',employee).subscribe((result) =>     {
      this.getAllEmployees()
    });
  }
}
