import { Routes } from '@angular/router';
import { redirectGuard } from '../app/guards/redirect.guard';
import { LinkRedirectComponent } from '../app/components/link-redirect/link-redirect.component';

export const routes: Routes = [
  {
    path: 'u/:id',
    component: LinkRedirectComponent,
    canActivate: [redirectGuard],
    pathMatch: 'full',
  }
];
