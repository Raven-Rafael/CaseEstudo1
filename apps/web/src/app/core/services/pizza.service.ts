import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sabor } from '../models/sabor.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  private apiUrl = `${environment.apiUrl}/sabores`;

  constructor(private http: HttpClient) {}

  getSabores(): Observable<Sabor[]> {
    return this.http.get<Sabor[]>(this.apiUrl);
  }
}
