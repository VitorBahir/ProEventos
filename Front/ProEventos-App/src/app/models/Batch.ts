import { Event } from "./Event";

export interface Batch {
  id : number;
  name : string;
  price : number;
  startDate? : Date;
  endDate? : Date;
  quantity : number;
  eventId : number;
  event : Event;
}
