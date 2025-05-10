import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface LoginDTO {
  email: string;
  senha: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly apiUrl = 'http://localhost:5093/api/usuario';

  constructor(private http: HttpClient) {}

  login(dto: LoginDTO): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, dto);
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  salvarLoginSimulado(): void {
    localStorage.setItem('token', 'usuario_logado');
  }

  isLogado(): boolean {
    return !!localStorage.getItem('token');
  }
}
