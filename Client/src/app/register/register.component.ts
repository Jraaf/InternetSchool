import {Component, inject, input, Input, output} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {School} from "../models/school";
import {AccountService} from "../services/account.service";
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  isRegistered = false;
  schools = input.required<School[]>();
  protected readonly model: any = {};
  cancelRegister = output<boolean>();

  register() {
    console.log(this.model);
    this.accountService.register(this.model)
      .subscribe({
        next:response =>{
          console.log(response);
          this.isRegistered = true;
          },
        error: error => {console.log(error);},
        }
      );
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
