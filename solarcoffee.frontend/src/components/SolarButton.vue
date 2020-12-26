<template>
    <div class="link">
        <button v-on:click="buttonClicked" v-bind:disabled="disabled" v-bind:class="['solar-button', isFullWidth ? 'full-width' : '']">
            <slot>
              
            </slot>
        </button>
    </div>    
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { Prop } from 'vue-property-decorator';

@Component({
    name: 'SolarButton',
    components: {}
})

export default class SolarButton extends Vue {
    @Prop({  required: false, type: Boolean, default: false })
    isFullWidth?: boolean;

    @Prop({ required: false, type: Boolean, default: false })
    disabled?: boolean;

    buttonClicked()
    {
        this.$emit("SBClicked");
    }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.solar-button {
    background: lighten($solar-blue, 10%);
    color: white;
    padding: 0.8rem;
    transition: background-color 0,5s;
    margin: 0.3rem 0.2rem;
    display: inline-block;
    cursor: pointer;
    font-size: 1rem;
    min-width: 100px;
    border: none;
    border-bottom: 2px solid darken($solar-blue, 20%);
    border-radius: 3px;
    margin-bottom: 4px;

    &:hover {
        background: lighten($solar-blue, 20%);
        transition: background-color 0.5s;
    }

    &:disabled {
        background: lighten($solar-blue, 15%);
        border-bottom: 2px solid lighten($solar-blue, 20%);
        cursor: not-allowed;
    }
}

.full-width {
    display: block;
    width: 100%;
}

</style>