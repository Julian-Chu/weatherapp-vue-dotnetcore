<template>
  <div class="hero">
    <div class="container">
      <form class="find-location" @submit.prevent="submit">
        <input type="text" v-model="city" placeholder="Find your location..." />
        <input type="submit" value="Find" />
      </form>
    </div>
  </div>
</template>
<script>
export default {
  name: "SearchBar",
  data() {
    return { city: "" };
  },
  methods: {
    submit(){
      this.$emit("find-city", this.city);
    }
  }
};
</script>
