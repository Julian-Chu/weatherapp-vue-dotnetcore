<template>
  <div class="today forecast">
    <div class="forecast-header">
      <div class="date">{{ dateToMMDD(viewData.dateTime) }}</div>
      <div class="date">{{ toWeekday(viewData.dateTime) }}</div>
      <!--      <div class="date">{{ dateToMMDD(viewdata.datetime) }}</div>-->
      <!--      <div class="day">{{ toWeekday(viewdata.datetime) }}</div>-->
    </div>
    <div class="forecast-content">
      <div class="location">{{ viewData.city }}</div>
      <div class="degree">
        <div class="num">
          {{ viewData.current.temperature }}
          <sup>o</sup>C
        </div>
        <small> {{ viewData.current.humidity }} <span>%</span> </small>
      </div>
    </div>
  </div>
</template>
<script>
import { dateToMMDD, toWeekday } from "../utils/utils";
export default {
  name: "TodayWeather",
  props: ["viewData"],
  methods: {
    dateToMMDD,
    toWeekday
  }
};
</script>
