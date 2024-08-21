import {Component, inject, output} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {AccountService} from "../services/account.service";
import {Router} from "@angular/router";

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
  cancel = output<boolean>();
  router = inject(Router);
  login() {
    this.accountService.login(this.model).subscribe({
      next:response =>{
      console.log(response);
    },
      error: error => {console.log(error);},
    });
    this.router.navigateByUrl("/teachers");
  }
  logout(){
    this.accountService.logout();
  }
  cancelClick(){
    this.cancel.emit(false);
  }
}
