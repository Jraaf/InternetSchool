import {Component, inject, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {HttpClient} from "@angular/common/http";
import {NavComponent} from "./nav/nav.component";
import {LoginComponent} from "./login/login.component";
import {School} from "./models/school";
import {AccountService} from "./services/account.service";
import {User} from "./models/user";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent, LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  private accountService = inject(AccountService);
  title = 'SchoolsLMS';
  schools:School[] = [];

  ngOnInit(): void {
    this.getShools();
    this.setCurrentUser();
  }

  setCurrentUser(){
     const userString = localStorage.getItem('user');
     if(!userString) return;
     const user = JSON.parse(userString);
     this.accountService.currentUser.set(user);
  }

  getShools(){
    this.http.get<School[]>('https://localhost:7232/api/School/GetAll').subscribe({
      next: response => {this.schools = response},
      error: error => {console.log(error);},
      complete: ()=>{console.log('fetching schools completed')}
    })
  }
}
