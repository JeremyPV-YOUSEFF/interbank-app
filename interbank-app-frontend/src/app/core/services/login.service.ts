import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ILogin, LoginResponse } from '../interfaces/login.interface';
import { Observable, tap } from 'rxjs';

const url = environment.backendUrl;

@Injectable({
  providedIn: 'root',
})
export class LoginService {

  http = inject(HttpClient)

  login(data : ILogin):Observable<LoginResponse>{
    return this.http.post<LoginResponse>(`${url}/auth/authentication/login`,data)
    .pipe(tap((data) => this.keepToken(data.token)))
  }

  keepToken(token : string){
    localStorage.setItem('tk',token);
  }

}
