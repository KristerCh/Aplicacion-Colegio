import { Component, OnInit } from '@angular/core';
import { Estudiante } from '../models/estudiante';
import { EstudianteService } from "../services/estudiante.service";
import { CursosService } from "../services/cursos.service";
import { Router } from "@angular/router"
import { Curso } from '../models/curso';

@Component({
  selector: 'app-crear-estudiante',
  templateUrl: './crear-estudiante.page.html',
  styleUrls: ['./crear-estudiante.page.scss'],
})
export class CrearEstudiantePage implements OnInit {
  cursos: Curso[];
  estudiante: Estudiante;

  constructor(
    private _cursosService: CursosService, 
    private _estudianteService: EstudianteService,
    public router: Router
  ) { this.estudiante = new Estudiante(); }

  ngOnInit() {
    this._cursosService.obtenerCursos().subscribe(res => {
      this.cursos = res;
    });
  }

  crearEstudiante(){
    if(this.estudiante){
      this._estudianteService.crearEstudiante(this.estudiante).subscribe(() => {
        this.router.navigate(["/estudiantes"]);
      });
    }
  }

  cancelar(){
    this.router.navigate(["/estudiantes"]);
  }

}
