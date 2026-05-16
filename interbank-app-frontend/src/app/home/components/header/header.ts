import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { ButtonCustome } from "../../../shared/components/button-custome/button-custome";
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-header-home',
  imports: [ButtonCustome,RouterLink],
  templateUrl: './header.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class Header {

  isHidden = signal<boolean>(true)

  changeVisibility(){
    this.isHidden.set(!this.isHidden())
  }

}
