import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly tokenKey = 'token';

  constructor() {}

  loginSimulado(): void {
    localStorage.setItem(this.tokenKey, 'usuario_logado');
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }

  isLogado(): boolean {
    return !!localStorage.getItem(this.tokenKey);
  }
}
