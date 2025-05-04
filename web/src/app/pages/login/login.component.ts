import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService
  ) {}

  login(): void {
    this.authService.loginSimulado();

    const redirectTo = this.route.snapshot.queryParamMap.get('redirectTo') || '/';
    this.router.navigateByUrl(redirectTo);
  }
}
