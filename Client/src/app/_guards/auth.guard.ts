import { CanActivateFn } from '@angular/router';
import {AccountService} from "../services/account.service";
import {inject} from "@angular/core";

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);

  return !!accountService.currentUser();

};
