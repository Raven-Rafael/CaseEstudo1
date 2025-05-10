import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sabor } from '../models/sabor.model';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {
  private baseUrl = 'http://localhost:5093/api';

  constructor(private http: HttpClient) {}

  getSabores(): Observable<Sabor[]> {
    return this.http.get<Sabor[]>(`${this.baseUrl}/sabores`);
  }

  getSaboresDestaque(): Observable<Sabor[]> {
    return this.http.get<Sabor[]>(`${this.baseUrl}/sabores/destaque`);
  }
}
