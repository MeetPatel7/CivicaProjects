import { Time } from "@angular/common";

export interface ITalkDetail {
    id:number;
    eventId:number;
    speakerId:number;
    title:string;
    room:string;
    description:string;
    tags:string;
    startTime:Time;
    endTime:Time;
}
