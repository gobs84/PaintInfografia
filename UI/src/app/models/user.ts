import {ShippingAddresses } from '../models/shippingAddresses';

export class User{
    Username: string;
    Password: string;
    Name: string;
    LastName: string;
    ShippingAddresses: ShippingAddresses[];
}
