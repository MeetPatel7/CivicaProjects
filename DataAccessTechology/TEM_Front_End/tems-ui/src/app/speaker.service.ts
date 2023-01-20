import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISpeaker } from './ispeaker';

@Injectable({
  providedIn: 'root'
})
export class SpeakerService {

  readonly speakerUrl = "https://localhost:7103/api/v1/events/";

  constructor(private httpClient : HttpClient) { }

  getSpeaker(eventId : number): Observable<ISpeaker[]>{
    return this.httpClient.get<ISpeaker[]>(this.speakerUrl + eventId + '/authors');
  }
}
