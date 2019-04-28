import { TripType, Trip, BusTrip } from '.';
import { Train } from './railway/train';

export class BaseTrip {
    type: TripType;
    train: Train;
    car: Trip;
    bus: BusTrip;
}