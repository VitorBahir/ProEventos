import { SocialMedia } from "./SocialMedia";
import { Event } from "./Event";

export interface Speaker {
  id : number;
  name : string;
  curriculum : string;
  imagemURL : string;
  phone : string;
  email : string;
  socialMedias : SocialMedia[];
  speakersEvents : Event[];
}
