import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';

@Component({
  selector: 'app-button-custome',
  imports: [],
  templateUrl: './button-custome.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ButtonCustome {

  type = input<string>("green");
  text = input.required<string>();

  onClick = output<void>();

}
