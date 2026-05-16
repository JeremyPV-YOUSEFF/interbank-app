import { ChangeDetectionStrategy, Component, input } from '@angular/core';

@Component({
  selector: 'app-text-custome',
  imports: [],
  templateUrl: './text-custome.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TextCustome {

  type = input<number>(1);
  text = input.required<string>();

}
