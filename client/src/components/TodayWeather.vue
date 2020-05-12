<template>
  <div class="today forecast">
    <div class="forecast-header">
      <div class="date">{{ dateToMMDD(viewdata.dateTime) }}</div>
      <div class="date">{{ toWeekday(viewdata.dateTime) }}</div>
      <!--      <div class="date">{{ dateToMMDD(viewdata.datetime) }}</div>-->
      <!--      <div class="day">{{ toWeekday(viewdata.datetime) }}</div>-->
    </div>
    <div class="forecast-content">
      <div class="location">{{ viewdata.city }}</div>
      <div class="degree">
        <div class="num">
          {{ viewdata.current.temperature }}
          <sup>o</sup>C
        </div>
        <small> {{ viewdata.current.humidity }} <span>%</span> </small>
      </div>
    </div>
  </div>
</template>
<script>
import { dateToMMDD, toWeekday } from "../utils/utils";
export default {
  name: "TodayWeather",
  props: ["viewdata"],
  methods: {
    dateToMMDD,
    toWeekday
  }
};
</script>
