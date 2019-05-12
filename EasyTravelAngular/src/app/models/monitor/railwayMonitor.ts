import { Train } from '../railway/train';

export class RailwayMonitor {
    from: string;
    to: string;
    departureDate: string;
    placesType: string;
    minPlaces: number;
    isInProcess: boolean;
    isSuccessful: boolean;
    trips: Train[]; 

    constructor() {}
}