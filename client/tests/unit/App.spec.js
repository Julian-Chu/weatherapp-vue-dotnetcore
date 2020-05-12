import {mount} from "@vue/test-utils";
import App from "../../src/App";
import SearchBar from "../../src/components/SearchBar";
import WeatherForecast from "../../src/components/WeatherForecast";
import SearchHistory from "../../src/components/SearchHistory";
import TodayWeather from "../../src/components/TodayWeather";
describe("App.vue", () => {
  var wrapper;
  beforeEach(() => {
    const viewData = {
      city: "Erlangen",
      dateTime: 1588322356525,
      current: {
        humidity: 88,
        temperature: 10
      },
      nextFiveDays: [
        {
          humidity: 66.25,
          temperature: 9
        },
        {
          humidity: 59.25,
          temperature: 8
        },
        {
          humidity: 66.75,
          temperature: 8
        },
        {
          humidity: 66.38,
          temperature: 8
        },
        {
          humidity: 64.12,
          temperature: 9
        }
      ]
    };
    wrapper = mount(App, {
      data() {
        return { viewData: viewData };
      }
    });
  });

  it("render all components correctly", () => {
    expect(wrapper.find(SearchBar).exists()).toBeTruthy();
    expect(wrapper.find(TodayWeather)).toBeTruthy();
    expect(wrapper.findAll(WeatherForecast)).toHaveLength(5);
    expect(wrapper.find(SearchHistory)).toBeTruthy();
  });
});
