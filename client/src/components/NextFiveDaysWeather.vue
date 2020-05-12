<template>
  <div class="nextfivedays">
    <template v-for="(forecast, i) of viewData.nextFiveDays">
      <WeatherForecast
        :addDays="i + 1"
        :forecast="forecast"
        :key="i"
        :today="viewData.dateTime"
      />
    </template>
  </div>
</template>
<script>
import WeatherForecast from "./WeatherForecast";

export default {
  name: "NextFiveDaysWeather",
  components: { WeatherForecast },
  props: {
    viewData: {}
  }
};
</script>
