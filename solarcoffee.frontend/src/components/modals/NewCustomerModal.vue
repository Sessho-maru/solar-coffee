<template>
    <SolarModal>
        <template v-slot:header>
            Add New Customer
        </template>

        <template v-slot:body>
            <ul class="newCustomerForm">
                <li>
                    <label for="firstName">First Name</label>
                    <input type="text" id="firstName" v-model="customer.firstName" />
                </li>
                <li>
                    <label for="lastName">Last Name</label>
                    <input type="text" id="lastName" v-model="customer.lastName" />
                </li>
                <li>
                    <label for="address1">Address Line 1</label>
                    <input type="text" id="address1" v-model="customer.primaryAddress.addressLine1" />
                </li>
                <li>
                    <label for="address2">Address Line 2</label>
                    <input type="text" id="address2" v-model="customer.primaryAddress.addressLine2" />
                </li>
                <li>
                    <label for="city">City</label>
                    <input type="text" id="city" v-model="customer.primaryAddress.city" />
                </li>
                <li>
                    <label for="state">State</label>
                    <input type="text" id="state" v-model="customer.primaryAddress.state" />
                </li>
                <li>
                    <label for="postalCode">Postal Code</label>
                    <input type="text" id="postalCode" v-model="customer.primaryAddress.postalCode" />
                </li>
                <li>
                    <label for="country">Country</label>
                    <input type="text" id="country" v-model="customer.primaryAddress.country" />
                </li>
            </ul>
        </template>

        <template v-slot:footer>
            <SolarButton @SBClicked="emitCreateUser">
                Create
            </SolarButton>
            <SolarButton @SBClicked="emitCloseModal">
                Close        
            </SolarButton>
        </template>
    </SolarModal>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import SolarButton from '../SolarButton.vue';
import SolarModal from './SolarModal.vue';
import { ICustomer, ICustomerAddress } from '../../types/Customers';

@Component({
    name: 'NewCustomerModal',
    components: {
        SolarButton,
        SolarModal
    }
})

export default class NewCustomerModal extends Vue {
    
    customer: ICustomer = {
        id: 0,
        createdOn: new Date(),
        updatedOn: new Date(),
        firstName: "",
        lastName: "",
        primaryAddress: {
            id: 0,
            createdOn: new Date(),
            addressLine1: "",
            addressLine2: "",
            city: "",
            state: "",
            postalCode: "",
            country: "",
        }
    };

    emitCreateUser()
    {
        this.$emit("create:newUser", this.customer);
    }

    emitCloseModal()
    {
        this.$emit("close:modal");
    }
}
</script>

<style lang="scss" scoped>
    .newCustomerForm {
        display: flex;
        flex-wrap: wrap;
        list-style: none;
        padding: 0;
        margin: 0;

        input {
            width: 80%;
            height: 1.8rem;
            margin: 0.8rem 2rem 0.8rem 0.8rem;
            font-size: 1.1rem;
            line-height: 1.3rem;
            padding: 0.2rem;
            color: #555;
        }

        label {
            font-weight: bold;
            margin: 0.8rem;
            display: block;
        }
    }
</style>