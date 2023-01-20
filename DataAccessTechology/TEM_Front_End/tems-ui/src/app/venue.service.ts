import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { IVenue } from './ivenue';

@Injectable({
  providedIn: 'root'
})
export class VenueService {

  readonly venueUrl = "https://localhost:7103/api/v1/Venue";

  constructor(private httpClient : HttpClient) { }

  getVenue(): Observable<IVenue[]>{
    return this.httpClient.get<IVenue[]>(this.venueUrl);
  }
}
