import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ErrorMessage } from '../../../shared/components/error-message/error-message';
import { ILogin } from '../../../core/interfaces/login.interface';
import { FieldTree, form, minLength, pattern, required, submit, FormField } from '@angular/forms/signals';
import { Router } from '@angular/router';
import { LoginService } from '../../../core/services/login.service';
import { FormCustome } from "../../../shared/components/form-custome/form-custome";

@Component({
  selector: 'app-login-page',
  imports: [FormCustome],
  templateUrl: './login-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  providers: [
    DialogService
  ]
})
export class LoginPage {

  authService = inject(LoginService);
  show = signal<boolean>(false);
  dialog = inject(DialogService);
  router = inject(Router)

  ref: DynamicDialogRef<any> | null | undefined;

  loginModel = signal<ILogin>({
    dni : '',
    password : ''
  })

  loginForm : FieldTree<ILogin> = form(this.loginModel, (path) => {
    required(path.dni, {message: "El campo es requerido"}),
    pattern(path.dni, RegExp('^[0-9]+$'),{message:'El campo solo acepta numeros'})
    required(path.password, {message: "El campo es requerido"}),
    minLength(path.password,6,{message:"La contraseña debe tener  al menos 6 caracteres"})
  });

  changeVisibility(){
    this.show.set(!this.show())
  }

  onClick(event : Event){
    event.preventDefault();

    submit(this.loginForm, async () => {
      this.authService.login(this.loginForm().value()).subscribe({
        next: () => {
          this.router.navigateByUrl('/admin/home')

        },error : (err) => {
          console.log(err,'error')
          this.ref = this.dialog.open(ErrorMessage,{
            closeOnEscape: false,
            closable : true,
            width:'25%',
            height:'45%'
          })
        }
      })
    })
  }



}
