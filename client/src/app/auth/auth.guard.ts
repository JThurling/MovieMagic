import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from "@angular/router";
import {Observable} from "rxjs";
import {AccountService} from "../shared/account.service";
import {Injectable, OnInit} from "@angular/core";

@Injectable()
export class AuthGuard implements CanActivate{
  constructor(private accountService: AccountService, private router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot,
              state: RouterStateSnapshot):
              boolean {
            this.router.navigate(['/']);
            return false;
  }

}
