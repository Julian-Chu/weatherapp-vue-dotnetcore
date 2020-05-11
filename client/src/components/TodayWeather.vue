<template>
  <div class="today forecast">
    <div class="forecast-header">
      <div class="day">Monday</div>
      <div class="date">6 Oct</div>
    </div>
    <div class="forecast-content">
      <div class="location">{{viewdata.city}}</div>
      <div class="degree">
        <div class="num">
          {{viewdata.current.temperature}}
          <sup>o</sup>C
        </div>
        <small>
          {{viewdata.current.humidity}} <span>%</span>
        </small>
        <div class="forecast-icon">
          <img src="images/icons/icon-1.svg" alt width="90" />
        </div>
        <!-- </div>
              <span>
                <img src="images/icon-umberella.png" alt />20%
              </span>
              <span>
                <img src="images/icon-wind.png" alt />18km/h
              </span>
              <span>
                <img src="images/icon-compass.png" alt />East
                </span>-->
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "TodayWeather",
  props: ["viewdata"]
};
</script>
