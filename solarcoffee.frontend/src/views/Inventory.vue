<template>
    <div class="inventory-container">
        <h1 id="inventoryTitle">Inventory Dashboard</h1>
        <hr />

        <div class="inventory-action">
            <SolarButton @SBClicked="showNewProductModal">
                Add New Item
            </SolarButton>

            <SolarButton @SBClicked="showNewShipmentModal">
                Receive Shipment
            </SolarButton>
        </div>

        <table id="inventoryTable" class="table">
            <tr>
                <th>Item</th>
                <th>Quatity on-hand</th>
                <th>Unit Price</th>
                <th>Taxable</th>
                <th>Delete</th>
            </tr>

            <tr v-bind:key="inventory.id" v-for="inventory in inventories">
                <td>
                    {{ inventory.product.name }}
                </td>
                <td v-bind:class="`${ applyColor(inventory.quantityOnHand, inventory.idealQuantity) }`">
                    {{ inventory.quantityOnHand }}
                </td>
                <td>
                    {{ inventory.product.price | price }}
                </td>
                <td>
                    {{ inventory.product.isTaxable ?  "Yes" : "No" }}
                </td>
                <td>
                    <div class="material-icons product-archive" v-on:click="archiveProduct(inventory.id)">
                        clear
                    </div>
                </td>
            </tr>
        </table>

        <NewProductModal v-if="isNewProductModalVisable" @save:newProduct="saveNewProduct" @close:modal="closeModal"/>
        <ShipmentModal v-if="isShipmentModalVisable" v-bind:inventories="inventories" @save:newShipment="saveNewShipment" @close:modal="closeModal"/>
        
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { IProductInventory, IProduct } from '../types/Product';
import { IShipment } from '../types/Shipment';
import SolarButton from '../components/SolarButton.vue';
import NewProductModal from '../components/modals/NewProductModal.vue';
import ShipmentModal from '../components/modals/ShipmentModal.vue';
import InventoryService from '../services/inventory_service';
import ProductService from '../services/product_service';

const inventoryService = new InventoryService();
const productService = new ProductService();

@Component({
    name: 'Inventory',
    components: {
        SolarButton,
        NewProductModal,
        ShipmentModal,
    },
})

export default class Inventory extends Vue {

    isNewProductModalVisable: boolean = false;
    isShipmentModalVisable: boolean = false;

    inventories: IProductInventory[] = [];

    created(): void
    {
        this.fetchData();
    }

    async fetchData()
    {
        this.inventories = await inventoryService.getInventory();
    }   

    async saveNewProduct(newProduct: IProduct)
    {
        await productService.addProduct(newProduct);
        this.isNewProductModalVisable = false;
        await this.fetchData();
    }

    async archiveProduct(productId: number)
    {
        await productService.archiveProduct(productId);
        await this.fetchData();
    }

    async saveNewShipment(newShipment: IShipment)
    {
        await inventoryService.updateInventoryQuantity(newShipment);
        this.isShipmentModalVisable = false;
        await this.fetchData();
    }

    showNewProductModal()
    {
        this.isNewProductModalVisable = true;
    }

    showNewShipmentModal()
    {
        this.isShipmentModalVisable = true;
    }

    closeModal()
    {
        this.isNewProductModalVisable = false;
        this.isShipmentModalVisable = false;
    }

    applyColor(current: number, target: number)
    {
        if (current <= 0)
        {
            return "red";
        }

        if (Math.abs(target-current) > 8)
        {
            return "yellow";
        }

        return "green";
    }
}
</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";
    .green {
        font-weight: bold;
        color: $solar-green;
    }

    .yellow {
        font-weight: bold;
        color: $solar-yellow;
    }

    .red {
        font-weight: bold;
        color: $solar-red;
    }

    .inventory-action {
        display: flex;
        margin-bottom: 0.8rem;
    }

    .product-archive {
        cursor: pointer;
        font-weight: bold;
        font-size: 1.2rem;
        color: $solar-red;
    }
</style>