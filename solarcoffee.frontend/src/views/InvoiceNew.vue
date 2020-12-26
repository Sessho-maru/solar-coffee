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
                    <option v-bind:key="itemInInven.id" v-for="itemInInven in inventory" v-bind:value="itemInInven">
                        {{ itemInInven.product.name }}
                    </option>
                </select>

                <label for="quantity">Quantity:</label>
                <input v-model="selectedItem.quantity" id="quantity" type="number" />
            </div>
            
            <div class="invoice-item-actions">
                <SolarButton v-bind:disabled="selectedItem.product === undefined || Number(selectedItem.quantity) <= 0" @SBClicked="addItem">Add Item</SolarButton>
            </div>

            <div class="invoice-cart" v-if="itemCart.length > 0">
                <div class="runningTotal">
                    <h3>Running Total:</h3>
                    {{ runningTotal() | price }}
                </div>

                <hr />

                <div v-html="displayTable()"></div>
            </div>

        </div>
        
        <div class="invoice-step" v-if="invoiceStep === 3"> <!-- Review Order -->
            <h2>Step 3: Review and Submit</h2>
            <SolarButton @SBClicked="submitInvoice">Submit Invoice</SolarButton>
            <hr />

            <div class="invoice-step-detail" id="invoice" ref="invoice">
                <div class="invoice-logo">
                    <img id="imgLogo" src="../assets/images/solar_coffee_logo.png" alt="Solar Coffee logo">
                    <h3>1337 Solar Lane</h3>
                    <h3>San Somewhere, CA 90000</h3>
                    <h3>USA</h3>

                    <div class="invoice-order-list">
                        <div class="invoice-header">
                            <h3>Invoice: {{ new Date() | humanizeDate }}</h3>
                            <h3>Customer: {{ this.selectedCustomer.firstName + " " + this.selectedCustomer.lastName }}</h3>
                            <h3>Address: {{ this.selectedCustomer.primaryAddress.addressLine2 ? this.selectedCustomer.primaryAddress.addressLine1 + " " + this.selectedCustomer.primaryAddress.addressLine2 : this.selectedCustomer.primaryAddress.addressLine1 }}</h3>
                        </div>
                        <h3>
                            {{ this.selectedCustomer.primaryAddress.city }},
                            {{ this.selectedCustomer.primaryAddress.state }},
                            {{ this.selectedCustomer.primaryAddress.postalCode }}
                        </h3>
                        <h3>
                            {{ this.selectedCustomer.primaryAddress.country }}
                        </h3>
                    </div>

                    <div v-html="displayTable()"></div>
                </div>
            </div>
        </div>

        <hr />

        <div class="invoice-steps-actions">
            <SolarButton @SBClicked="prev" v-bind:disabled="isPossiblePrev() === false">Previous</SolarButton>
            <SolarButton v-if="invoiceStep <= 2" @SBClicked="next" v-bind:disabled="isPossibleNext() === false">{{ invoiceStep === 2 ?  'Finalize Order' : 'Next'}}</SolarButton>
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

    displayTable(): string
    {
        let table = `
            <table class="table">
                <tr>
                    <th> Product </th>
                    <th> Description </th>
                    <th> Qty. </th>
                    <th> Price </th>
                    <th> Subtotal </th>
                </tr>
        `;

        this.itemCart.map((each) => {
            table += `
                <tr>
                    <td>${ each.product.product.name }</td>
                    <td>${ each.product.product.description }</td>
                    <td>${ each.quantity }</td>
                    <td>${ each.product.product.price }</td>
                    <td>${ this.$options.filters.price(each.product.product.price * each.quantity) }</td>
                </tr>
            `
        });

        if (this.invoiceStep === 3)
        {
            table += `
                <tr>
                    <th colspan="4"></th>
                    <th>Grand Total</th>
                </tr>
                <tfoot>
                    <tr>
                    <td colspan="4" style="font-weight: bold;">Balance due upon receipt:</td>
                    <td style="font-weight: bold; color: #22a885;">${ this.$options.filters.price(this.runningTotal() )}</td>
                    </tr>
                </tfoot>
            `
        }

        return table + `</table>`;
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

    async submitInvoice(): Promise<void>
    {
        this.invoice = {
            customerId: this.selectedCustomerId,
            items: this.itemCart
        }

        await invoiceService.makeNewInvoice(this.invoice);
    }

    get selectedCustomer(): ICustomer
    {
        return this.customers.find((customer) => customer.id === this.selectedCustomerId);
    }

    updated(): void
    {
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
            if (this.selectedCustomerId === 0)
            {
                return false;
            }
            return true;
        }

        if (this.invoiceStep === 2)
        {
            if (this.itemCart.length === 0)
            {
                return false;
            }
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
        this.itemCart = [];
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

<style lang="scss" scoped>
@import "@/scss/global.scss";

    .invoice-steps-actions {
        display: flex;
        width: 100%;
    }

    .invoice-order-list {
        margin-top: 1.2rem;
        padding: 0.8rem;

        .line-item {
            display: flex;
            border-bottom: 1px dashed #ccc;
            padding: 0.8rem;
        }

        .item-col {
            flex-grow: 1;
        }
    }

    .invoice-step-detail {
        margin: 1.2rem;
    }

    .invoice-item-actions {
        display: flex;
    }

    .price-pre-tax {
        font-weight: bold;
    }

    .invoice-header {
        width: 100%;
        margin-bottom: 1.2rem;
    }

    .invoice-logo {
        padding-top: 1.4rem;
        text-align: center;

        img {
            width: 280px;
        }
    }

</style>