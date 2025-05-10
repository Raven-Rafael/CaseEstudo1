import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {
  private baseUrl = 'http://localhost:5093/api';

  constructor(private http: HttpClient) {}

  getSabores(): Observable<any> {
    return this.http.get(`${this.baseUrl}/sabores`);
  }

  getTamanhos(): Observable<any> {
    return this.http.get(`${this.baseUrl}/tamanhos`);
  }

  getBordas(): Observable<any> {
    return this.http.get(`${this.baseUrl}/bordas`);
  }
}
