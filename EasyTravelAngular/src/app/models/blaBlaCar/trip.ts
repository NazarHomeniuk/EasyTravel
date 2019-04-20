import { Links } from './links';
import { Place } from './place';
import { Price } from './price';
import { Duration } from './duration';
import { Distance } from './distance';
import { Car } from './car';

export class Trip {
    links: Links;
    departureDate: Date;
    departurePlace: Place;
    arrivalPlace: Place;
    price: Price;
    seatsLeft: number;
    seats: number;
    duration: Duration;
    distance: Distance;
    car: Car;
    locationsToDisplay: string[];
}