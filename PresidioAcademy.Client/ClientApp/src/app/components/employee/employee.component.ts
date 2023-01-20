import {Component, OnInit} from '@angular/core';
import {Employee} from "../../interfaces/Employee"
import {EmployeeService} from "../../services/employee.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit{
  EmployeeFG!: FormGroup;

  editMode: boolean = false;
  public employees: Employee[] = [];
  constructor(private employeeService: EmployeeService) {

  }



  updateEmployee(employee: Employee) {
    this.editMode = true;
    this.EmployeeFG.controls["email"].setValue(employee.email.split("@")[0]);
    this.EmployeeFG.controls["id"].setValue(employee.id);
    this.EmployeeFG.controls["name"].setValue( employee.name);
    this.EmployeeFG.controls["password"].setValue( "password");
    this.EmployeeFG.controls["role"].setValue( employee.role);

  }

  deleteEmployee(id: number) {
      this.employeeService.deleteEmployee(id);
      this.resetForm();
  }

  addEmployee() {

    if(this.EmployeeFG.invalid){
      console.log("Invalid Form")
      this.EmployeeFG.markAllAsTouched();
    }
    else{
      let employee: Employee= {
        email: this.EmployeeFG.controls["email"].value +"@presidio.com",
        id: this.EmployeeFG.controls["id"].value,
        name: this.EmployeeFG.controls["name"].value,
        password: this.EmployeeFG.controls["password"].value,
        role: this.EmployeeFG.controls["role"].value

      }
      this.editMode? this.employeeService.updateEmployee(employee): this.employeeService.createEmployee(employee);

      this.resetForm();
    }

  }

  ngOnInit(): void {
    this.employeeService.getEmployees.subscribe(res=>{
      this.employees =res;
    })
    this.EmployeeFG = new FormGroup(
      {
        id: new FormControl('', [
          Validators.required,
          Validators.minLength(4),
        ]),
        name: new FormControl('', [
          Validators.required,
          Validators.minLength(3),
        ]),
        email: new FormControl('', [Validators.required]),
        role: new FormControl('', [Validators.required]),
        password: new FormControl('', [Validators.required,Validators.minLength(8),Validators.maxLength(16)]),
      }
    );
  }

  resetForm() {
    this.EmployeeFG.reset();
    this.editMode= false;

  }
}
