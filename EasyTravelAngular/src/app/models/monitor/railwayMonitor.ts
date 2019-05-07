import { Train } from '../railway/train';

export class RailwayMonitor {
    from: string;
    to: string;
    departureDate: Date;
    placesType: string;
    minPlaces: number;
    isInProcess: boolean;
    IsSuccessful: boolean;
    trips: Train[]; 
}