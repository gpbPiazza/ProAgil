export interface Lot {
  id: number;
  name: string;
  price: number;
  beginningDate?: Date;
  endDate?: Date;
  quantity: number;
  eventId: number;
}
