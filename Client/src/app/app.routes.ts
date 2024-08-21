import { Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {RegisterComponent} from "./register/register.component";
import {TeacherListComponent} from "./members/teacher-list/teacher-list.component";
import {TeacherInfoComponent} from "./members/teacher-info/teacher-info.component";
import {LoginComponent} from "./login/login.component";

export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'teachers', component: TeacherListComponent},
  {path: 'teachers/:id', component: TeacherInfoComponent},
  {path: 'login', component: LoginComponent},
  {path: '**', component: HomeComponent, pathMatch:"full"},
];
