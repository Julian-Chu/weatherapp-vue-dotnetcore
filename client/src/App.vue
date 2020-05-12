<template>
  <div id="app">
    <div class="site-content">
      <SearchBar v-on:find-city="findCity" />
      <div class="forecast-table">
        <div class="container">
          <div class="forecast-container">
            <TodayWeather v-bind:viewdata="viewdata" />
            <div class="nextfivedays">
              <template v-for="(forecast, i) of viewdata.nextFiveDays">
                <WeatherForecast v-bind:forecast="forecast" :key="i" />
              </template>
            </div>
          </div>
        </div>
      </div>
      <SearchHistory v-bind:searchHistory="searchHistory" />
    </div>
  </div>
</template>

<script>
import TodayWeather from "./components/TodayWeather";
import WeatherForecast from "./components/WeatherForecast";
import SearchBar from "./components/SearchBar";
import SearchHistory from "./components/SearchHistory";
import axios from "axios";

export default {
  name: "App",
  components: {
    SearchHistory,
    SearchBar,
    WeatherForecast,
    TodayWeather
  },
  data() {
    return {
      viewdata: {
        dateTime: Date.now(),
        city: "Erlangen",
        current: {
          humidity: 88,
          temperature: 277.33
        },
        nextFiveDays: [
          {
            humidity: 66.25,
            temperature: 279.82
          },
          {
            humidity: 59.25,
            temperature: 282.45
          },
          {
            humidity: 66.75,
            temperature: 283.57
          },
          {
            humidity: 66.38,
            temperature: 282.3
          },
          {
            humidity: 64.12,
            temperature: 283.98
          }
        ]
      },
      searchHistory: [
        { city: "Erlangen", humidity: 64.12, temperature: 283.98 },
        { city: "Erlangen", humidity: 64.12, temperature: 283.98 }
      ],
    };
  },
  methods: {
    findCity(city) {
      alert(city);
      const queryParams = isNaN(city) ? `cityname=${city}` : `zipcode=${city}`;
      axios
        .get(`https://localhost:5001/api/weather/forecast?${queryParams}`)
        .then(res => {
          console.log(res);
          this.viewdata = res.data;
          this.searchHistory.unshift({
            city: this.viewdata.city,
            humidity: this.viewdata.current.humidity,
            temperature: this.viewdata.current.temperature
          });

          if (this.searchHistory.length > 10) {
            this.searchHistory.pop();
          }

          localStorage.setItem("searchHistory", JSON.stringify(this.searchHistory));
        })
        .catch(err => console.log(err));
    }
  },
  mounted() {
    this.searchHistory = JSON.parse(localStorage.getItem("searchHistory"));
  }
};
</script>
