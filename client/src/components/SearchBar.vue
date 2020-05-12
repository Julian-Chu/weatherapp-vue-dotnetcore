<template>
  <div class="hero">
    <div class="container">
      <form class="find-location" @submit.prevent="submit">
        <input
          type="text"
          v-model="city"
          placeholder="Please input city name or zipcode"
          v-on:keyup="validateInput"
          data-city
        />
        <input
          type="submit"
          value="Find"
          v-bind:disabled="!city || !validations.zipcodeIsValid"
          v-bind:style="[city.length === 0 ? { opacity: '30%' } : {}]"
        />
      </form>
      <p v-show="!validations.zipcodeIsValid">Zipcode should be 5 digits</p>
      <p v-show="errMessage">{{ errMessage }}</p>
    </div>
  </div>
</template>
<script>
import _ from "lodash";
export default {
  name: "SearchBar",
  props: ["errMessage"],
  data() {
    return {
      city: "",
      validations: {
        zipcodeIsValid: true
      }
    };
  },
  methods: {
    submit: function() {
      this.$emit("find-city", this.city);
      this.city = "";
    },
    validateInput: _.debounce(function() {
      this.validations.zipcodeIsValid = true;
      if (this.city.length === 0) return;
      if (!isNaN(this.city) && this.city.length !== 5) {
        this.validations.zipcodeIsValid = false;
      }
    }, 600)
  }
};
</script>
