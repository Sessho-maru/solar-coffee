<template>
    <div>
        <h1 id="invoiceTitle">
            Create Invoice
        </h1>
        <hr />

        <div class="invoice-step" v-if="invoiceStep === 1"> <!-- Select a Customer from list -->
            <h2>Step 1: Select Customer</h2>

            <div v-if="customers.length > 0" class="invoice-step-detail">
                <label for="customer">Customer:</label>
                <select v-model="selectedCustomerId" class="invoice-customers" id="customer">
                    <option disabled >Please select a Customer</option>
                    <option v-bind:key="customer.id" v-for="customer in customers" v-bind:value="customer.id">
                        {{ customer.firstName + " " + customer.lastName }}
                    </option>
                </select>
            </div>
        </div>

        <div class="invoice-step" v-if="invoiceStep === 2"> <!-- Process Ordering -->
            <h2>Step 2: Create Order</h2>
            
            <div>
                <label for="product">Product:</label>
                <select v-model="selectedItem.product" class="invoiceItem" id="product">
                    <option disabled >Please select a Product</option>
                    <option v-bind:key="itemInInven.id" v-for="itemInInven in inventory" v-bind:value="itemInInven">
                        {{ itemInInven.product.name }}
                    </option>
                </select>

                <label for="quantity">Quantity:</label>
                <input v-model="selectedItem.quantity" id="quantity" type="number" min="0" />
            </div>
            
            <div class="invoice-item-actions">
                <SolarButton v-bind:disabled="selectedItem.product === undefined || selectedItem.quantity === 0" @SBClicked="addItem">Add Item</SolarButton>
                <SolarButton v-bind:disabled="itemCart.length === 0" @SBClicked="finalizeOrder">Finalize Order</SolarButton>
                <SolarButton :disabled="true">Disabled</SolarButton>
            </div>

            <div class="invoice-cart" v-if="itemCart.length > 0">
                <div class="runningTotal">
                    <h3>Running Total:</h3>
                    {{ runningTotal() | price }}
                </div>

                <hr />

                <table class="table">
                    <tr>
                        <th>Product</th>
                        <th>Description</th>
                        <th>Qty.</th>
                        <th>Price</th>
                        <th>Subtotal</th>
                    </tr>
                    <tr v-bind:key="item.id" v-for="item in itemCart">
                        <td>{{ item.product.product.name }}</td>
                        <td>{{ item.product.product.description }}</td>
                        <td>{{ item.quantity }}</td>
                        <td>{{ item.product.product.price }}</td>
                        <td>{{ (item.product.product.price * item.quantity) | price }}</td>
                    </tr>
                </table>
            </div>

        </div>
        
        <div class="invoice-step" v-if="invoiceStep === 3"> <!-- Review Order -->
            
        </div>

        <hr />

        <div class="invoice-steps-actions">
            <SolarButton @SBClicked="prev" v-bind:disabled="isPossiblePrev === false">Previous</SolarButton>
            <SolarButton @SBClicked="next" v-bind:disabled="isPossibleNext === false">Next</SolarButton>
            <SolarButton @SBClicked="startOver">StartOver</SolarButton>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

import SolarButton from '../components/SolarButton.vue';

import { IInvoice, IItemInCart } from '../types/Invoice';
import { ICustomer } from '../types/Customers';
import { IProductInventory } from '../types/Product';

import CustomerService from '../services/customer_service';
import InventoryService from '../services/inventory_service';
import InvoiceService from '../services/invoice_service';

const customerService = new CustomerService();
const inventoryService = new InventoryService();
const invoiceService = new InvoiceService();

@Component({
    name: 'InvoiceNew',
    components: {    
        SolarButton
    },    
})

export default class InvoiceNew extends Vue {
    invoiceStep: number = 1;
    invoice: IInvoice = {
        customerId: 0,
        items: []
    }

    customers: ICustomer[] = [];
    selectedCustomerId: number = 0;
    
    inventory: IProductInventory[] = [];

    itemCart: IItemInCart[] = [];
    selectedItem: IItemInCart = {
        product: undefined,
        quantity: 0
    }

    async fetchData(): Promise<void>
    {
        this.customers = await customerService.getCustomers();
        this.inventory = await inventoryService.getInventory();
    }

    async created(): Promise<void>
    {
        await this.fetchData();
    }

    updated(): void
    {
        console.log("current Cart: ", this.itemCart);
    }

    addItem(): void
    {
        let isAlready = false;
        this.selectedItem.quantity = Number(this.selectedItem.quantity);

        this.itemCart.map((each) => {
            if (each.product.id === this.selectedItem.product.product.id)
            {
                isAlready = true;
                each.quantity += this.selectedItem.quantity;

                this.selectedItem = { product: undefined, quantity: 0 };
                return;
            }   
        });

        if (isAlready === false)
        {
            this.itemCart.push(this.selectedItem);
            this.selectedItem = { product: undefined, quantity: 0 };
        }
    }

    isPossibleNext(): boolean
    {
        if (this.invoiceStep === 1)
        {
            return this.selectedCustomerId !== 0;
        }

        if (this.invoiceStep === 2)
        {
            return true;
        }

        return false;
    }

    isPossiblePrev(): boolean
    {
        return this.invoiceStep !== 1;
    }

    prev(): void
    {
        if (this.invoiceStep === 1)
        {
            return;
        }

        this.invoiceStep -= 1;
    }

    next(): void
    {
      if (this.invoiceStep === 3)
        {
            return;
        }

        this.invoiceStep += 1;
    }
    
    startOver()
    {
        this.invoice = { customerId: 0, items: [] };
        this.invoiceStep = 1;
    }

    finalizeOrder(): void
    {
        this.invoiceStep = 3;
    }

    runningTotal(): number
    {
        let total: number = 0;
        this.itemCart.map((each) => {
            let item: IItemInCart = each;
            total += item.product.product.price * each.quantity;
        });

        return total;
    }
}
</script>

<style lane="scss" scoped>

    .invoice-steps-actions {
        display: flex;
        width: 100%;
    }

    .invoice-step-detail {
    margin: 1.2rem;
    }

</style>