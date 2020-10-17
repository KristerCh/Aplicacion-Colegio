import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { EditarEstudiantePage } from './editar-estudiante.page';

describe('EditarEstudiantePage', () => {
  let component: EditarEstudiantePage;
  let fixture: ComponentFixture<EditarEstudiantePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarEstudiantePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(EditarEstudiantePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
