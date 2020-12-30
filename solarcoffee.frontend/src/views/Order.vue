<template>
    <div>
        <h1 id="ordersTitle">
            Sales Orders
        </h1>
        <hr />
        <table id="sales-orders" class="table" v-if="orders.length > 0">
            <tr>
                <th>CustomerId</th>
                <th>OrderId</th>
                <th>Order Total</th>
                <th>Order Status</th>
                <th>Order Complete</th>
            </tr>
            <tr v-for="order in orders" v-bind:key="order.id">
                <td>{{ order.customer.id + " ( " +order.customer.firstName + " " + order.customer.lastName + " )"}}</td>
                <td>{{ order.id }}</td>
                <td>{{ order.grandTotal | price }}</td>
                <td v-bind:class="{ green: order.isPaid }">{{ getStatus(order.isPaid) }}</td>
                <td>
                    <div v-if="order.isPaid === false" class="material-icons" v-on:click="markComplete(order.id)">
                        done
                    </div>
                </td>
            </tr>
        </table>
    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

import { ISalesOrder } from '../types/SalesOrder'

import OrderService from '../services/order_service'

const orderService = new OrderService();

@Component({
    name: 'Orders',
    components: {    
        
    },    
})

export default class Order extends Vue {
    orders: ISalesOrder[] = [];

    created(): void
    {
        this.fetchData();
    }

    async fetchData()
    {
        this.orders = await orderService.getOrders();
    }

    getStatus(isPaid: boolean): string
    {
        return isPaid ? "Paid in full" : "Unpaid";
    }

    async markComplete(id: number)
    {
        await orderService.makeOrderComplete(id);
        await this.fetchData();
    }

}
</script>

<style lang="scss" scoped>

</style>