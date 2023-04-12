import { Batch } from "./Batch";
import { SocialMedia } from "./SocialMedia";
import { Speaker } from "./Speaker";

export interface Event {
  id : number;
  place : string;
  eventDate? : Date;
  theme : string;
  amountPeople : number;
  imageURL : string;
  phone : string;
  email : string;
  batches : Batch[];
  socialMedias : SocialMedia[];
  speakersEvents : Speaker[];
}
