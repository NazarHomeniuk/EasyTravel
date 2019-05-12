import { Time } from '@angular/common';

export class BusTrip {
    from: string;
    to: string;
    departureTime: Time;
    arrivalTime: Time;
    date: Date;
    arrivalDate: string;
    departureDate: string;
    distance: number;
    price: number;
    busName: string;
    bookingLink: string;
}