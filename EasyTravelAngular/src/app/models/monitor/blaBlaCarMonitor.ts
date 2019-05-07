import { Trip } from '../blaBlaCar/trip';

export class BlaBlaCarMonitor {
    from: string;
    to: string;
    departureDate: Date;
    minPlaces: number;
    isInProcess: boolean;
    IsSuccessful: boolean;
    trips: Trip[];
}