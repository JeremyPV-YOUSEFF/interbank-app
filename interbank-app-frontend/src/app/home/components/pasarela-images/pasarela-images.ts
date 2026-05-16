import { ChangeDetectionStrategy, Component, input, OnDestroy, OnInit, signal } from '@angular/core';
import { ButtonCustome } from "../../../shared/components/button-custome/button-custome";

@Component({
  selector: 'app-pasarela-images',
  imports: [ButtonCustome],
  templateUrl: './pasarela-images.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PasarelaImages implements OnInit,OnDestroy {
 

  images = input<string[]>([]);

  image = signal<string>('');

  content : any;

  ngOnInit(): void {
    const account = this.images().length;

    let i = 0;
    this.image.set(this.images()[i])
    this.content = setInterval(() => {
      i++;
      if (i<=account-1) {
        console.log('valor de 1 uno',i)
      }else{
        i = 0;
        console.log('valor de 1 dos',i)
      }
      this.image.set(this.images()[i])
    }, 5000);
  }

  ngOnDestroy(): void {
    clearInterval(this.content);
  }
  

}
