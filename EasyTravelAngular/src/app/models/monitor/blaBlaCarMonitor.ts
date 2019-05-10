import { Trip } from '../blaBlaCar/trip';

export class BlaBlaCarMonitor {
    from: string;
    to: string;
    departureDate: Date;
    minPlaces: number;
    isInProcess: boolean;
    isSuccessful: boolean;
    trips: Trip[];

    constructor() {}
}