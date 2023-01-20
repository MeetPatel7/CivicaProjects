import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ITalkDetail } from './italk-detail';

@Injectable({
  providedIn: 'root'
})
export class TalkdetailService {

  readonly talkDetailUrl = 'https://localhost:7103/api/v1/';

  constructor(private httpClient : HttpClient) { }

  getTalkDetails(eventId: number, speakerId: number): Observable<ITalkDetail[]> {
    return this.httpClient.get<ITalkDetail[]>(this.talkDetailUrl + 'events/' + eventId + '/authors/' + speakerId + '/talks');
  }
}
