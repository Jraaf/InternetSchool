import {Component, inject, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {HttpClient} from "@angular/common/http";
import {NavComponent} from "./nav/nav.component";
import {LoginComponent} from "./login/login.component";
import {School} from "./models/school";
import {AccountService} from "./services/account.service";
import {HomeComponent} from "./home/home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent, LoginComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  private accountService = inject(AccountService);

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser(){
     const userString = localStorage.getItem('user');
     if(!userString) return;
     const user = JSON.parse(userString);
     this.accountService.currentUser.set(user);
  }
}
