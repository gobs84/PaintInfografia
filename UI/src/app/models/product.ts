import { Category } from "./category";

export class Product {
    Code: string;
    Name: string;
    Price: number;
    Description: string;
    ImageURL: string;
    Type: number;
    ShippingDeliveryType: string;
    Category: Category;
}