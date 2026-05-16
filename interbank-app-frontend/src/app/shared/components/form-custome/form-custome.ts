import { NgClass } from '@angular/common';
import { ChangeDetectionStrategy, Component, input, signal } from '@angular/core';
import { FieldTree, FormField } from '@angular/forms/signals';

@Component({
  selector: 'app-form-custome',
  imports: [NgClass,FormField],
  templateUrl: './form-custome.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class FormCustome {

  placeholderContent = input<string>('');
  formFieldData = input.required<FieldTree<string|number>>();  
  typeInput = input<string>('text')

  showP = signal<boolean>(false);

  show = signal<boolean>(false);
  opt = input<number>(1);

  isFieldInvalid(): boolean{
    const fieldSignal = this.formFieldData()();
    if(!fieldSignal) return false;
    return fieldSignal.touched() && fieldSignal.errors().length > 0;
  }
  
  isFieldValid():boolean{
    const fieldSignal = this.formFieldData()();
    if(!fieldSignal) return false;
    return fieldSignal.touched() && fieldSignal.errors().length == 0;
  }

  isFocus(){
    this.show.set(true)
  }

  isBlur(){
    this.show.set(false)
  }


  changeVisibility(){
    this.showP.set(!this.showP())
  }

}
