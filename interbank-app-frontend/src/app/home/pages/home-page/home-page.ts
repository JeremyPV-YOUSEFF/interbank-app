import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { PasarelaImages } from "../../components/pasarela-images/pasarela-images";
import { ButtonCustome } from "../../../shared/components/button-custome/button-custome";
import { Gift } from '../../../core/interfaces/gift.interface';
import { FieldTree, form, pattern, required } from '@angular/forms/signals';
import { FormCustome } from "../../../shared/components/form-custome/form-custome";

@Component({
  selector: 'app-home-page',
  imports: [PasarelaImages, ButtonCustome, FormCustome],
  templateUrl: './home-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomePage {

  ptModel = signal<Gift>({
    dni : '',
  })

  ptForm : FieldTree<Gift> = form(this.ptModel, (path) => {
    required(path.dni, {message: "El campo es requerido"}),
    pattern(path.dni, RegExp('^[0-9]+$'),{message:'El campo solo acepta numeros'})
  });

  onSubmit(event : Event){
    event.preventDefault();

  }

}
