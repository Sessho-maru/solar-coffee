<template>
    <div class="inventory-container">
        <h1 id="inventoryTitle">Inventory Dashboard</h1>
        <hr />

        <div class="inventory-actions">
            <SolarButton v-on:click.native="showNewProductModal">
                Add New Item
            </SolarButton>

            <SolarButton v-on:click.native="showNewShipmentModal">
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
                <td>
                    {{ inventory.quantityOnHand }}
                </td>
                <td>
                    {{ inventory.product.price | price }}
                </td>
                <td>
                    {{ inventory.product.isTaxable ?  "Yes" : "No" }}
                </td>
                <td>
                    <div>
                        X
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

    inventories: IProductInventory[] = [
        {
            id: 1,
            createdOn: new Date(),
            updatedOn: new Date(),
            product: {
                id: 1,
                name: "Some Product",
                description: "Good stuff",
                price: 100,
                createdOn: new Date(),
                updatedOn: new Date(),
                isTaxable: true,
                isArchived: false
            },
            quantityOnHand: 100,
            idealQuantity: 100
        },
        {
            id: 2,
            createdOn: new Date(),
            updatedOn: new Date(),
            product: {
                id: 2,
                name: "Another Product",
                description: "Good stuff",
                price: 150,
                createdOn: new Date(),
                updatedOn: new Date(),
                isTaxable: true,
                isArchived: false
            },
            quantityOnHand: 40,
            idealQuantity: 40
        },
    ];

    saveNewProduct(newProduct: IProduct)
    {
        console.log(newProduct);
    }

    saveNewShipment(newShipment: IShipment)
    {
        console.log(newShipment);
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
}
</script>

<style lang="scss" scoped>

</style>