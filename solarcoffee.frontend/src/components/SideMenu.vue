<template>
    <div class="menu-container">
        <router-link to="/">
            <img id="logo" src="../assets/images/solar_coffee_logo.png" alt="logo">
        </router-link>
        
        <h1>Management Portal</h1>

        <SolarButton id="menuInventory" v-bind:href="'/inventory'" v-bind:isFullWidth="true">
            Inventory
        </SolarButton>

        <SolarButton id="menuCustomers" v-bind:href="'/customers'" v-bind:isFullWidth="true">
            Manage Customers
        </SolarButton>

        <SolarButton id="menuInvoice" v-bind:href="'/invoice/new'" v-bind:isFullWidth="true">
            New Invoice
        </SolarButton>

        <SolarButton id="menuOrders" v-bind:href="'/orders'" v-bind:isFullWidth="true">
            Orders
        </SolarButton>

        <br><br><br><br>

        <SolarButton>
            Sango is best
        </SolarButton>

        <SolarButton>
            Sango is sexy
        </SolarButton>

        <SolarButton>
            at the same time, Sango is cute
        </SolarButton>

    </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import SolarButton from "../components/SolarButton.vue";

@Component({
    name: 'SideMenu',
    components: {
        SolarButton
    }
})

export default class SideMenu extends Vue {}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.menu-container {
    background-color: #fcfcfc;
    height: 100vh;
    width: $menu-width;
    display: flex;
    flex-direction: column;
    padding: 0.8rem;
    box-shadow: 0 1px 1px rgba(0,0,0,0.12), 0 1px 1px rgba(0,0,0,0.24);
    box-sizing: border-box; 
}

#logo {
    width: 100%
}

h1 {
    font-size: 1.2rem;
    margin: 1rem 0;
}

</style>