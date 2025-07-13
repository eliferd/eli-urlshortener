import {
  Component,
  ViewEncapsulation
} from '@angular/core';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { NzButtonComponent } from 'ng-zorro-antd/button';
import { NzCardComponent } from 'ng-zorro-antd/card';
import { NzColDirective, NzRowDirective } from 'ng-zorro-antd/grid';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzIconDirective } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzQRCodeComponent } from 'ng-zorro-antd/qr-code';
import { NzSpaceComponent, NzSpaceItemDirective } from 'ng-zorro-antd/space';
import { NzSpinComponent } from 'ng-zorro-antd/spin';
import { tap } from 'rxjs';
import { BackendService } from '../app/services/backend.service';

@Component({
  selector: 'app-root',
  imports: [
    NzRowDirective,
    NzColDirective,
    NzFormModule,
    NzInputModule,
    NzButtonComponent,
    ReactiveFormsModule,
    NzCardComponent,
    NzSpaceComponent,
    NzSpaceItemDirective,
    NzQRCodeComponent,
    NzSpinComponent,
    NzIconDirective,
    RouterOutlet
  ],
  encapsulation: ViewEncapsulation.None,
  templateUrl: './app.component.html',
  styleUrl: './app.component.sass'
})
export class AppComponent{
  formControl = new FormControl<string>('', [Validators.required, Validators.pattern('(https:\\/\\/www\\.|http:\\/\\/www\\.|https:\\/\\/|http:\\/\\/)?[a-zA-Z]{2,}(\\.[a-zA-Z]{2,})(\\.[a-zA-Z]{2,})?\\/[a-zA-Z0-9]{2,}|((https:\\/\\/www\\.|http:\\/\\/www\\.|https:\\/\\/|http:\\/\\/)?[a-zA-Z]{2,}(\\.[a-zA-Z]{2,})(\\.[a-zA-Z]{2,})?)|(https:\\/\\/www\\.|http:\\/\\/www\\.|https:\\/\\/|http:\\/\\/)?[a-zA-Z0-9]{2,}\\.[a-zA-Z0-9]{2,}\\.[a-zA-Z0-9]{2,}(\\.[a-zA-Z0-9]{2,})?')]);
  isShorten = false;
  finalUrl: string = '';
  private _loading = false;

  constructor(private readonly backendService: BackendService) {}

  get loading(): boolean {
    return this._loading;
  }

  submit(): void {

    this._loading = true;
    this.backendService.addLink$(this.formControl.value as string).pipe(
      tap(id => {
        this.finalUrl = window.location.href + 'u/' + id;
        this._loading = false;
        this.isShorten = true;
      })
    ).subscribe();
  }
}
