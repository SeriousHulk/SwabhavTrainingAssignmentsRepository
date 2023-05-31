import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { INumberApiResponse } from './number.api.resp';
import { Observable, map } from 'rxjs';

@Injectable()
export class NumberapisvcService {
  constructor(private http: HttpClient) {}
  getFact(no: number): Observable<INumberApiResponse> {
    console.log('Inside getFact');
    return this.http.get(`http://numberapi.com/${no}?json`).pipe(
      map((resp) => {
        console.log('inside pipe and map');
        return <INumberApiResponse>resp;
      })
    );
  }
}
