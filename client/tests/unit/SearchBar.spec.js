import { mount } from "@vue/test-utils";
import SearchBar from "../../src/components/SearchBar";

describe("SearchBar.vue Tests", () => {
  it("should emit find-city event", async function() {
    const wrapper = mount(SearchBar);

    wrapper.vm.$emit("find-city", "Test");
    await wrapper.vm.$nextTick();
    expect(wrapper.emitted("find-city")[0]).toEqual(["Test"]);
  });

  it("should clear city state after submit", async function() {
    const wrapper = mount(SearchBar);
    wrapper.setData({
      city: "test"
    });
    expect(wrapper.vm.$data.city).toBe("test");
    wrapper.find("form").trigger("submit.prevent");
    await wrapper.vm.$nextTick();
    expect(wrapper.vm.$data.city).toBe("");
  });
});
