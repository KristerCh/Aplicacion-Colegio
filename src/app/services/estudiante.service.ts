import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Estudiante } from "../models/estudiante";

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {
  apiUrl = "https://localhost:44329/api/Estudiante";

  constructor(private http: HttpClient) { }

  obtenerEstudiante(id: number){
    return this.http.get<Estudiante>(this.apiUrl + "/" + id);
  }

  obtenerEstudiantes(){
    return this.http.get<Estudiante[]>(this.apiUrl);
  }

  eliminarEstudiante(id: number){
    return this.http.delete<Estudiante>(this.apiUrl + "/" + id);
  }

  crearEstudiante(estudiante: Estudiante){
    return this.http.post<Estudiante>(this.apiUrl, estudiante);
  }  

  editarEstudiante(estudiante: Estudiante){
    return this.http.put<Estudiante>(this.apiUrl + "/" + estudiante.id, estudiante);
  }
}
