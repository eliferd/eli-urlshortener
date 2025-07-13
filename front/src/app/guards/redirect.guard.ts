import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { map, tap} from 'rxjs';
import { BackendService } from '../services/backend.service';

export const redirectGuard: CanActivateFn = (route, state) => {
  const backendService = inject(BackendService);
  return backendService.getLink$(route.paramMap.get('id') as string).pipe(
    tap(finalUrl => window.location.href = finalUrl),
    map(finalUrl => !!finalUrl)
  );
};
