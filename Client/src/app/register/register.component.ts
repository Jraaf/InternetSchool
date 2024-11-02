import {Component, inject, input, output} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {School} from "../models/school";
import {AccountService} from "../services/account.service";
import {Router, RouterLink} from "@angular/router";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  router = inject(Router);
  schools = input.required<School[]>();
  protected readonly model: any = {};
  RegisterStatus = output<boolean>();
  RegisterMode = output<boolean>();

  register() {
    console.log(this.model);
    this.accountService.register(this.model)
      .subscribe({
        next:response =>{
          console.log(response);
          this.RegisterStatus.emit(true);
          this.router.navigateByUrl("/teachers");
          },
        error: error => {console.log(error);},
        }
      );
  }

  cancel() {
    this.RegisterMode.emit(false);
  }
}
