import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Curso } from '../models/curso';

@Injectable({
  providedIn: 'root'
})
export class CursosService {
  apiUrl = "https://localhost:44329/api/Curso";

  constructor(private http: HttpClient) { }

  obtenerCursos(){
    return this.http.get<Curso[]>(this.apiUrl);
  }
}
