import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { EstudiantesPageRoutingModule } from './estudiantes-routing.module';

import { EstudiantesPage } from './estudiantes.page';
import { Routes } from '@angular/router';

const routes: Routes = [{
  path: '',
  component: EstudiantesPage
}];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    EstudiantesPageRoutingModule
  ],
  declarations: [EstudiantesPage]
})
export class EstudiantesPageModule {}
