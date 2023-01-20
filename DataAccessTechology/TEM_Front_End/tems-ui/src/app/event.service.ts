import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEvent } from './ievent';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  readonly eventUrl = "https://localhost:7103/api/v1/Events";
  
  constructor(private httpClient : HttpClient) { }

  getEvent(): Observable<IEvent[]>{
    return this.httpClient.get<IEvent[]>(this.eventUrl);
  }
}
