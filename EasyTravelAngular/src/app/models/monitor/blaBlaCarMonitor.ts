import { Trip } from '../blaBlaCar/trip';

export class BlaBlaCarMonitor {
    from: string;
    to: string;
    departureDate: string;
    minPlaces: number;
    isInProcess: boolean;
    isSuccessful: boolean;
    trips: Trip[];
    guid: string;

    constructor() {}
}