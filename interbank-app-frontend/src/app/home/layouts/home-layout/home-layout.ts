import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Footer } from "../../components/footer/footer";
import { Header } from "../../components/header/header";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-home-layout',
  imports: [Footer, Header,RouterOutlet],
  template: 
    `
      <div class="min-h-screen h-auto w-full">
        <app-header-home/>
        <div class="">
          <router-outlet/>
        </div>
        <app-footer-home/>
      </div>

    `,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeLayout {}
