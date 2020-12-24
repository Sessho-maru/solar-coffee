import axios from 'axios';
import { IProductInventory } from "../types/Product";
import { IShipment } from "../types/Shipment";

export default class InventoryService {
    API_URL = process.env.VUE_APP_API_URL;
    
    public async getInventory() : Promise<IProductInventory[]>
    {
        let result = await axios.get(`${this.API_URL}/inventory`);
        return result.data;
    }

    public async updateInventoryQuantity(newShipment : IShipment) : Promise<IProductInventory[]>
    {
        let result = await axios.patch(`${this.API_URL}/inventory`, newShipment);
        return result.data;
    }
}