<template>
    <div class="inventory-container">
        <h1 id="inventoryTitle">Inventory Dashboard</h1>
        <hr />

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
    </div>    
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { IProductInventory, IProduct } from '../types/Product';

@Component({
    name: 'Inventory',
    components: {}
})

export default class Inventory extends Vue {
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
}
</script>

<style lang="scss" scoped>

</style>