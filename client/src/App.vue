<template>
  <div id="app">
    <div class="site-content">
      <SearchBar v-bind:errMessage="errorMessage" v-on:find-city="findCity" />
      <div class="forecast-table" v-if="viewData">
        <div class="container">
          <div class="forecast-container">
            <TodayWeather :view-data="viewData" />
            <NextFiveDaysWeather :view-data="viewData" />
          </div>
        </div>
      </div>
      <SearchHistory v-bind:searchHistory="searchHistory" />
    </div>
  </div>
</template>

<script>
import TodayWeather from "./components/TodayWeather";
import SearchBar from "./components/SearchBar";
import SearchHistory from "./components/SearchHistory";
import axios from "axios";
import NextFiveDaysWeather from "./components/NextFiveDaysWeather";

export default {
  name: "App",
  components: {
    NextFiveDaysWeather,
    SearchHistory,
    SearchBar,
    TodayWeather
  },
  data() {
    return {
      viewData: null,
      errorMessage: "",
      searchHistory: []
    };
  },
  methods: {
    findCity: async function(city) {
      this.errorMessage = "";
      const queryParams = isNaN(city) ? `cityname=${city}` : `zipcode=${city}`;
      try {
        const res = await axios.get(
          `https://localhost:5001/api/weather/forecast?${queryParams}`
        );
        this.viewData = res.data;
        this.searchHistory.unshift({
          city: this.viewData.city,
          humidity: this.viewData.current.humidity + " %",
          temperature: this.viewData.current.temperature + "\u00B0C"
        });

        if (this.searchHistory.length > 10) {
          this.searchHistory.pop();
        }

        localStorage.setItem(
          "searchHistory",
          JSON.stringify(this.searchHistory)
        );
      } catch (err) {
        this.errorMessage = err.response.data.message + ": " + city;
        setTimeout(() => (this.errorMessage = ""), 2000);
      }
    }
  },
  mounted() {
    this.searchHistory =
      JSON.parse(localStorage.getItem("searchHistory")) || [];
  }
};
</script>
