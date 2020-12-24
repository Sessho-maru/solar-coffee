import axios from 'axios';
import { IProduct } from '../types/Product';

export default class ProductService {
    API_URL = process.env.VUE_APP_API_URL;

    public async addProduct(newProduct: IProduct)
    {
        let result = await axios.post(`${this.API_URL}/product`, newProduct);
        return result.data;
    }

    public async archiveProduct(productId: number)
    {
        let result = await axios.patch(`${this.API_URL}/product/${productId}`);
        return result.data;
    }
}