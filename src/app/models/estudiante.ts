import {Curso} from './curso';
import { from } from 'rxjs';
import { CursorError } from '@angular/compiler/src/ml_parser/lexer';

export class Estudiante {
    id: number;
    nombre: string;
    cursoId: number;
    curso: Curso;
}