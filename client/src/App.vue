<template>
  <div id="app">
    <!-- <img alt="Vue logo" src="./assets/logo.png" /> -->
    <!-- <HelloWorld msg="Welcome to Your Vue.js App" /> -->
    <div class="site-content">
      <div class="hero" data-bg-image="images/banner.png">
        <div class="container">
          <form action="#" class="find-location">
            <input type="text" placeholder="Find your location..." />
            <input type="submit" value="Find" />
          </form>
        </div>
      </div>
      <div class="forecast-table">
        <div class="container">
          <div class="forecast-container">
            <div class="today forecast">
              <div class="forecast-header">
                <div class="day">Monday</div>
                <div class="date">6 Oct</div>
              </div>
              <!-- .forecast-header -->
              <div class="forecast-content">
                <div class="location">New York</div>
                <div class="degree">
                  <div class="num">
                    23
                    <sup>o</sup>C
                  </div>
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
            <div class="nextfivedays">
              <div class="forecast">
                <div class="forecast-header">
                  <div class="day">Tuesday</div>
                </div>
                <!-- .forecast-header -->
                <div class="forecast-content">
                  <div class="forecast-icon">
                    <img src="images/icons/icon-3.svg" alt width="48" />
                  </div>
                  <div class="degree">
                    23
                    <sup>o</sup>C
                  </div>
                  <small>
                    18
                    <sup>o</sup>
                  </small>
                </div>
              </div>
              <div class="forecast">
                <div class="forecast-header">
                  <div class="day">Wednesday</div>
                </div>
                <!-- .forecast-header -->
                <div class="forecast-content">
                  <div class="forecast-icon">
                    <img src="images/icons/icon-5.svg" alt width="48" />
                  </div>
                  <div class="degree">
                    23
                    <sup>o</sup>C
                  </div>
                  <small>
                    18
                    <sup>o</sup>
                  </small>
                </div>
              </div>
              <div class="forecast">
                <div class="forecast-header">
                  <div class="day">Thursday</div>
                </div>
                <!-- .forecast-header -->
                <div class="forecast-content">
                  <div class="forecast-icon">
                    <img src="images/icons/icon-7.svg" alt width="48" />
                  </div>
                  <div class="degree">
                    23
                    <sup>o</sup>C
                  </div>
                  <small>
                    18
                    <sup>o</sup>
                  </small>
                </div>
              </div>
              <div class="forecast">
                <div class="forecast-header">
                  <div class="day">Friday</div>
                </div>
                <!-- .forecast-header -->
                <div class="forecast-content">
                  <div class="forecast-icon">
                    <img src="images/icons/icon-12.svg" alt width="48" />
                  </div>
                  <div class="degree">
                    23
                    <sup>o</sup>C
                  </div>
                  <small>
                    18
                    <sup>o</sup>
                  </small>
                </div>
              </div>
              <div class="forecast">
                <div class="forecast-header">
                  <div class="day">Saturday</div>
                </div>
                <!-- .forecast-header -->
                <div class="forecast-content">
                  <div class="forecast-icon">
                    <img src="images/icons/icon-13.svg" alt width="48" />
                  </div>
                  <div class="degree">
                    23
                    <sup>o</sup>C
                  </div>
                  <small>
                    18
                    <sup>o</sup>
                  </small>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="site-content">
          <div class="container">
            <div class="search-history">
              <div>Germany 12 34 56</div>
              <div>Germany 12 34 56</div>
              <div>Germany 12 34 56</div>
              <div>Germany 12 34 56</div>
              <div>Germany 12 34 56</div>
              <div>Germany 12 34 56</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import HelloWorld from "./components/HelloWorld.vue";

export default {
  name: "App",
  components: {
    // HelloWorld
  }
};
</script>

<style>
/* #app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
} */
</style>
