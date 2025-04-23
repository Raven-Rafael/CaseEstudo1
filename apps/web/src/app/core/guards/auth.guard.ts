import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    const isLoggedIn = !!localStorage.getItem('token');

    if (isLoggedIn) {
      return true;
    }


    this.router.navigate(['/login'], {
      queryParams: { redirectTo: state.url }
    });
    return false;
  }
}
