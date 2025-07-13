import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  constructor(private readonly http: HttpClient) { }

  addLink$(link: string): Observable<string> {
    return this.http.post<string>(environment.api, `"${link}"`, {
      headers: {'Content-Type': 'application/json'}
    });
  }

  getLink$(id: string): Observable<string> {
    return this.http.get<string>(environment.api + '/' + id);
  }
}
