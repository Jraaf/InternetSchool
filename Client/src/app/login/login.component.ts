import {Component, inject} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {AccountService} from "../services/account.service";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  private accountService = inject(AccountService);
  loggedIn:boolean = false;
  model:any={};
  login() {
    this.accountService.login(this.model).subscribe({
      next:response =>{
      console.log(response);
      this.loggedIn = true;
    },
      error: error => {console.log(error);},
    });
  }
}
