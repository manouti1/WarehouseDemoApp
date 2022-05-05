import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import CarDetails from '../models/CarDetails';
import ResponseData from "../models/ResponseData";
import { EnvironmentUrlService } from "./environment-url.service";

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private httpClient: HttpClient,private envUrl:EnvironmentUrlService) { }

  getAllCarsByDateAsc(page: number): Observable<ResponseData>  {
    return this.httpClient
      .get<ResponseData>(`${this.envUrl.urlAddress}/warehouse/GetCarsSortedByDateAsc?page=${page}`)
    .pipe(retry(3), catchError(this.httpErrorHandler));
  }

  getCarDetails(vehicleId: number) {
    return this.httpClient.get<CarDetails>(`${this.envUrl.urlAddress}/warehouse/GetMoreInfo/${vehicleId}`, this.httpOptions)
    .pipe(retry(3), catchError(this.httpErrorHandler));
  }
  
  private httpErrorHandler(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error(
        'A client side error occurs. The error message is ' + error.message
      );
    } else {
      console.error(
        'An error happened in server. The HTTP status code is ' +
          error.status +
          ' and the error returned is ' +
          error.message
      );
    }

    return throwError('Error occurred. Please try again');
  }
}
