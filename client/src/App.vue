<template>
  <div id="app">
    <div class="site-content">
      <SearchBar v-on:find-city="findCity"/>
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
      <SearchHistory :history="history" />
    </div>
  </div>
</template>

<script>
import TodayWeather from "./components/TodayWeather";
import WeatherForecast from "./components/WeatherForecast";
import SearchBar from "./components/SearchBar";
import SearchHistory from "./components/SearchHistory";
import axios from 'axios';

export default {
  name: "App",
  components: {
    SearchHistory,
    SearchBar,
    WeatherForecast,
    TodayWeather
    // HelloWorld
  },
  data() {
    return {
      viewdata: {
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
      history: [
        { city: "Erlangen", humidity: 64.12, temperature: 283.98 },
        { city: "Erlangen", humidity: 64.12, temperature: 283.98 }
      ]
    };
  },
  methods: {
    findCity(city) {
      alert(city);
      axios
        .get("https://localhost:5001/api/weatherforecast")
        .then(res => console.log(res))
        .catch(err => console.log(err));
    }
  }
};
</script>
