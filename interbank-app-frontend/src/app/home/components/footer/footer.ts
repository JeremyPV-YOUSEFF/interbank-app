import { ChangeDetectionStrategy, Component } from '@angular/core';
import { TextCustome } from "../../../shared/components/text-custome/text-custome";

@Component({
  selector: 'app-footer-home',
  imports: [TextCustome],
  templateUrl: './footer.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Footer {}
