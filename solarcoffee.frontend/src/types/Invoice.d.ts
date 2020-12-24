import { IProduct } from "./Product";

export interface IInvoice {
    customerId: number;
    items: IItemInCart[];
    createdOn?: Date;
    updatedOn?: Date;
}

export interface IItemInCart {
    product?: IProduct;
    quantity: number;
}