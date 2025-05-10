import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Borda } from '../models/borda.model';

@Injectable({
  providedIn: 'root'
})
export class BordaService {

  private readonly apiUrl = 'http://localhost:5093/api/bordas';

  constructor(private http: HttpClient) {}

  getTodas(): Observable<Borda[]> {
    return this.http.get<Borda[]>(this.apiUrl);
  }

  getPorId(id: number): Observable<Borda> {
    return this.http.get<Borda>(`${this.apiUrl}/${id}`);
  }

  criar(borda: Borda): Observable<Borda> {
    return this.http.post<Borda>(this.apiUrl, borda);
  }

  atualizar(id: number, borda: Borda): Observable<Borda> {
    return this.http.put<Borda>(`${this.apiUrl}/${id}`, borda);
  }

  deletar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
