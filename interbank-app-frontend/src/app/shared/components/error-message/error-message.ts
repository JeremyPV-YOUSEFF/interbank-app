import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ButtonCustome } from "../button-custome/button-custome";

@Component({
  selector: 'app-error-message',
  imports: [ButtonCustome],
  templateUrl: './error-message.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ErrorMessage {}
