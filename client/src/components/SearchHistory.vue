<template>
  <div class="site-content">
    <div class="container">
      <div class="search-history">
        <div v-for="(hist, i) of searchHistory" :key="i">
          {{ hist.city }} {{ hist.temperature }} {{ hist.humidity }}
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "SearchHistory",
  props: ["searchHistory"]
};
</script>
