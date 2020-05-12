<template>
  <div class="forecast">
    <div class="forecast-header">
      <div class="day">Tuesday</div>
    </div>
    <div class="forecast-content">
      <div class="degree">
        {{forecast.temperature}}
        <sup>o</sup>C
      </div>
      <small>
        {{forecast.humidity}} <span>%</span>
      </small>
    </div>
  </div>
</template>
<script>
export default {
  name: "WeatherForecast",
  props: ["forecast"]
};
</script>
