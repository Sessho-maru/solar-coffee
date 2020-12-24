<template>
    <SolarModal>

        <template v-slot:header>
            Add New Product
        </template>

        <template v-slot:body>
            <ul class="newProductForm">
                <li>
                    <label for="isTaxable">Is this product taxable?</label>
                    <input type="checkbox" id="isTaxable" v-model="newProduct.isTaxable">
                </li>
                <li>
                    <label for="isTaxable">Name</label>
                    <input type="text" id="productName" v-model="newProduct.name">
                </li>
                <li>
                    <label for="isTaxable">Description</label>
                    <input type="text" id="productDesciption" v-model="newProduct.description">
                </li>
                <li>
                    <label for="isTaxable">Price (USD)</label>
                    <input type="text" id="productPrice" v-model="newProduct.price">
                </li>
            </ul>
        </template>

        <template v-slot:footer>
            <SolarButton @SBClicked="emitSaveProduct">
                Save Product
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
import { IProductInventory, IProduct } from '../../types/Product';

@Component({
    name: 'NewProductModal',
    components: {
        SolarButton,
        SolarModal,
    }
})

export default class NewProductModal extends Vue{  
    newProduct: IProduct = {
        id: 0,
        createdOn: new Date(),
        updatedOn: new Date(),
        name: "",
        description: "",
        price: 0,
        isTaxable: false,
        isArchived: false
    };

    emitSaveProduct()
    {
        this.$emit("save:newProduct", this.newProduct);
    }

    emitCloseModal()
    {
        this.$emit("close:modal");
    }
}
</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";    
.newProductForm {
    list-style: none;
    padding: 0;
    margin: 0;

    input {
        width: 100%;
        height: 1.8rem;
        margin-bottom: 1.2rem;
        font-size: 1.1rem;
        line-height: 1.3rem;
        padding: 0.2rem;
        color: #555;
    }

    label {
        font-weight: bold;
        display: block;
        margin-bottom: 0.3rem;
    }
}
</style>