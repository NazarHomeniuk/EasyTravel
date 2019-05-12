import { Links } from './links';
import { Place } from './place';
import { Price } from './price';
import { Duration } from './duration';
import { Distance } from './distance';
import { Car } from './car';

export class Trip {
    links: Links;
    departure_date: string;
    arrival_date: string;
    departure_place: Place;
    arrival_place: Place;
    price: Price;
    seats_left: number;
    seats: number;
    duration: Duration;
    distance: Distance;
    car: Car;
    locations_to_display: string[];
}