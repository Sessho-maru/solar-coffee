<template>
    <SolarModal>

        <template v-slot:header>
            Receive Shipment
        </template>

        <template v-slot:body>
            <label for="product">Product Received:</label>

            <select id="product" v-model="selectedProduct">
                <option disabled value="">Please select one</option>
                <option v-bind:key="inventory.product.id" v-for="inventory in inventories" v-bind:value="inventory">
                    {{ inventory.product.name }}
                </option>
            </select>

            <label for="qtyReceived">Quantity Received:</label>
            <input id="qtyReceived" type="number" v-model="qtyReceived">
        </template>

        <template v-slot:footer>
            <SolarButton @SBClicked="emitSaveNewShipment" aria-label="Save new Shipment">
                Save Received Shipment
            </SolarButton>
            <SolarButton @SBClicked="emitCloseModal" aria-label="Close modal">
                Close
            </SolarButton>
        </template>

    </SolarModal>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator';
import SolarButton from '../SolarButton.vue';
import SolarModal from './SolarModal.vue';
import { IProductInventory, IProduct } from '../../types/Product';
import { IShipment } from '../../types/Shipment';

@Component({
    name: 'ShipmentModal',
    components: { 
        SolarButton,
        SolarModal,
    }
})

export default class ShipmentModal extends Vue{  
    @Prop({required: true, type: Array as () => IProductInventory[]})
    inventories!: IProductInventory[];

    selectedProduct: IProduct = {
        id: 0,
        createdOn: new Date(),
        updatedOn: new Date(),
        name: "",
        description: "",
        price: 0,
        isTaxable: false,
        isArchived: false
    };

    qtyReceived: number = 0;

    emitSaveNewShipment()
    {   
        let shipment: IShipment = {
            productId: this.selectedProduct.id,
            adjustment: this.qtyReceived    
        };

        this.$emit("save:newShipment", shipment);
    }

    emitCloseModal()
    {
        this.$emit("close:modal");
    }
}
</script>

<style lang="scss" scoped>

</style>