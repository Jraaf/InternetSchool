import {Component, inject, OnInit} from '@angular/core';
import {RegisterComponent} from "../register/register.component";
import {School} from "../models/school";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    RegisterComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{
  registerMode = false;
  http = inject(HttpClient);
  schools!: School[];

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  getShools(){
    this.http.get<School[]>('https://localhost:7232/api/School/GetAll').subscribe({
      next: response => {this.schools = response},
      error: error => {console.log(error);},
      complete: ()=>{console.log('fetching schools completed')}
    })
  }
  ngOnInit(): void {
    this.getShools();
  }
  cancelRegisterMode(value:boolean){
    this.registerMode = value;
  }
}
