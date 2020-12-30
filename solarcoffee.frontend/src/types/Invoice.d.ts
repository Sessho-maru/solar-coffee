import { IProduct } from "./Product";

export interface IInvoice {
    createdOn?: Date;
    updatedOn?: Date;
    customerId: number;
    items: IItemInCart[];
    grandTotal: number;
}

export interface IItemInCart {
    product?: IProduct;
    quantity: number;
    subTotal: number;
}