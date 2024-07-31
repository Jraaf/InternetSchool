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
  accountService = inject(AccountService);
  model:any={};
  login() {
    this.accountService.login(this.model).subscribe({
      next:response =>{
      console.log(response);
    },
      error: error => {console.log(error);},
    });
  }
  logout(){
    this.accountService.logout();
  }
}
