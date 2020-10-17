import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditarEstudiantePage } from './editar-estudiante.page';

const routes: Routes = [
  {
    path: '',
    component: EditarEstudiantePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EditarEstudiantePageRoutingModule {}
