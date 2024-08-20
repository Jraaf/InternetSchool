import {inject, Injectable, signal} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "../models/user";
import {map} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = 'https://localhost:7232/api/'
  currentUser = signal<User | null>(null);

  register(model:any){
    return this.http.post<User>(this.baseUrl+'Account/register', model).pipe(
      map(user=>{
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
        return user;
      })
    );
  }

  login(model:any){
    return this.http.post<User>(this.baseUrl+'Account/login', model).pipe(
      map(user=>{
           if(user){
             localStorage.setItem('user', JSON.stringify(user));
             this.currentUser.set(user);
           }
      })
    );
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
