import {Component, model} from '@angular/core';
import {FormBuilder, FormGroup, FormsModule, Validators} from "@angular/forms";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  register() {

  }

  protected readonly model:any;

  cancel() {

  }
}
