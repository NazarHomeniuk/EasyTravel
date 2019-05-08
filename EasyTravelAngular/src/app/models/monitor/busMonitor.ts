import { BusTrip } from '../bus/trip';

export class BusMonitor {
    from: string;
    to: string;
    departureDate: Date;
    isInProcess: boolean;
    IsSuccessful: boolean;
    trips: BusTrip[];

    constructor() {}
}