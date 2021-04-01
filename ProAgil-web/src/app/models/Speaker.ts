import {Event} from './Event';
import {SocialMedia} from './SocialMedia';

export interface Speaker {
  id: number;
  name: string;
  curriculumVitae: string;
  imageUrl: string;
  price: number;
  email: string;
  phoneNumber: string;
  socialMedias: SocialMedia[];
  eventSpeakers: Event[];
}
