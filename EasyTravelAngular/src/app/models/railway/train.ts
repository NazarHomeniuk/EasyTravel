import { Station } from './station';
import { Type } from './type';
import { Child } from './child';

export class Train {
    num: string;
    category: number;
    isTransformer: string;
    departureDate: Date;
    arrivalDate: Date;
    travelTime: string;
    from: Station;
    to: Station;
    types: Type[];
    child: Child;
    allowStudent: number;
    allowBooking: number;
    isCis: number;
    isEurope: number;
    allowPrivilege: number;
    noReserve: number;
}