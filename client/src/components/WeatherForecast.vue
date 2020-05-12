<template>
  <div class="forecast">
    <div class="forecast-header">
      <div class="day">{{ getWeekday(this.today, this.addDays) }}</div>
    </div>
    <div class="forecast-content">
      <div class="degree">
        {{ forecast.temperature }}
        <sup>o</sup>C
      </div>
      <small> {{ forecast.humidity }} <span>%</span> </small>
    </div>
  </div>
</template>
<script>
import { getWeekday } from "../utils/utils";

export default {
  name: "WeatherForecast",
  props: ["forecast", "today", "addDays"],
  methods: {
    getWeekday
  }
};
</script>
