import {Lot} from './Lot';
import { SocialMedia } from './SocialMedia';
import {Speaker} from './Speaker';

export interface Event {
  id: number;
  place: string;
  eventDate: Date;
  theme: string;
  peopleAmount: number;
  lot: string;
  imageUrl: string;
  lots: Lot[];
  phoneNumber: string;
  email: string;
  socialMedias: SocialMedia[];
  eventSpeakers: Speaker[];
}
