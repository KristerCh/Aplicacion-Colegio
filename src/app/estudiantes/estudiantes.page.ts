import { Component, OnInit } from '@angular/core';
import { Estudiante } from "../models/estudiante";
import { EstudianteService } from '../services/estudiante.service';
import { Router } from '@angular/router';
import { AlertController, Platform } from '@ionic/angular';

@Component({
  selector: 'app-estudiantes',
  templateUrl: './estudiantes.page.html',
  styleUrls: ['./estudiantes.page.scss'],
})
export class EstudiantesPage implements OnInit {
  estudiantes: Estudiante[];

  constructor(
    private _estudiantesService: EstudianteService,
    private router: Router,
    public alertController: AlertController,
    private platform: Platform
  ) { }

  ngOnInit() {
  }

  ionViewWillEnter(){
    this.obtenerEstudiantes();
  }

  crearEstudiante(){
    this.router.navigate(["/estudiantes/crear"]);
  }

  editarEstudiante(id: number){
    this.router.navigate([`/estudiantes/editar/${id}`]);
  }

  obtenerEstudiantes(event = null){
    this._estudiantesService.obtenerEstudiantes().subscribe(data => {
      this.estudiantes = data;
      if(event){
        event.target.complete();
      }
    });
  }

  presentAlert(id){
    this.alertController.create({
      message: "Desea eliminar Estudiante?",
      header: "Confirmar",
      buttons: [{
        text: "No",
        role: "Cancel",
        handler: blah => {}
      },{
        text: "Si",
        handler: () => {
          this._estudiantesService.eliminarEstudiante(id).subscribe(() => {
            this.obtenerEstudiantes();
          });
        }
      }
    ]
    })
    .then(alert => alert.present());
  }

  eliminarEstudiante(id: number){
    if(this.platform.is("cordova")){
      this.presentAlert(id);
    }else{
      const res = confirm("Desea eliminar Estudiante?");
      if(res){
        this._estudiantesService.eliminarEstudiante(id).subscribe(() => {
          this.obtenerEstudiantes();
        });
      }
    }
  }
}
