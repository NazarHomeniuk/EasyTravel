import { BusTrip } from '../bus/trip';

export class BusMonitor {
    from: string;
    to: string;
    departureDate: Date;
    isInProcess: boolean;
    isSuccessful: boolean;
    trips: BusTrip[];

    constructor() {}
}