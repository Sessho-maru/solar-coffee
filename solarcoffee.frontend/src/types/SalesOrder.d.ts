import { ICustomer } from '../types/Customers';
import { IItemInCart } from '../types/Invoice';

export interface ISalesOrder {
    id: number;
    createdOn: Date;
    updatedOn?: Date;
    customer: ICustomer;
    salesOrderItems: IItemInCart[];
    grandTotal: number,
    isPaid: boolean;
}