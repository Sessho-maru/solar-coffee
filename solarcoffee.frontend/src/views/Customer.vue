<template>
    <div>
        <h1 id="customersTitle">Manage Customers</h1>
        <hr/>

        <div class="customer-action">
            <SolarButton @SBClicked="showNewCustomerModal">
                Add Customer
            </SolarButton>
        </div>

        <table id="customerTable" class="table">
            <tr>
                <th>Customer</th>
                <th>Address</th>
                <th>State</th>
                <th>Since</th>
                <th>Delete</th>
            </tr>
            
            <tr v-bind:key="customer.id" v-for="customer in customers">
                <td>
                    {{ customer.firstName + " " + customer.lastName }}
                </td>
                <td>
                    {{ customer.primaryAddress.addressLine1 + " " + customer.primaryAddress.addressLine2 }}
                </td>
                <td>
                    {{ customer.primaryAddress.state }}
                </td>
                <td>
                    {{ customer.createdOn | humanizeDate }}
                </td>
                <td>
                    <div class="material-icons customer-delete" v-on:click="deleteCustomer(customer.id)">
                        clear
                    </div>
                </td>
            </tr>
        </table>

        <NewCustomerModal v-if="isNewCustomerModalVisible" @create:newUser="createNewCustomer" @close:modal="closeModal" />
    </div>

</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import SolarButton from '../components/SolarButton.vue';
import NewCustomerModal from '../components/modals/NewCustomerModal.vue';
import { ICustomer } from '../types/Customers';
import CustomerService from '../services/customer_service';

const customerService = new CustomerService();

@Component({
    name: 'Customers',
    components: {    
        SolarButton,
        NewCustomerModal
    },    
})

export default class Customer extends Vue {

    isNewCustomerModalVisible: boolean = false;

    customers: ICustomer[] = [];

    created()
    {
        this.fetchData();
    }

    async fetchData()
    {
        this.customers = await customerService.getCustomers();
    }

    async createNewCustomer(newCustomer: ICustomer)
    {
        await customerService.addCustomers(newCustomer);
        this.isNewCustomerModalVisible = false;
        await this.fetchData();        
    }
    
    async deleteCustomer(customerId: number)
    {
        await customerService.deleteCustomer(customerId);
        this.fetchData();
    }

    showNewCustomerModal()
    {
        this.isNewCustomerModalVisible = true;    
    }

    closeModal()
    {
        this.isNewCustomerModalVisible = false;
    }
}
</script>

<style lang='scss' scoped>
@import "@/scss/global.scss";

    .customer-action {
        display: flex;
        margin-bottom: 0.8rem;
    }

    .customer-delete {
        cursor: pointer;
        font-weight: bold;
        font-size: 1.2rem;
        color: $solar-red;
    }

</style>