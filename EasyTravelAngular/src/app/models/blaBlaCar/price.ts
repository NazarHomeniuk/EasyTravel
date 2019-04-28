import { JsonProperty } from 'json2typescript';

export class Price {
    value: number;
    currency: string;
    symbol: string;
    @JsonProperty('string_value')
    stringValue: string;
    @JsonProperty('price_colors')
    priceColor: string;
}