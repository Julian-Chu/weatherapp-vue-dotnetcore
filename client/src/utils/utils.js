const dateToMMDD = timestamp => {
  const datetime = new Date(timestamp);
  const year = datetime.getFullYear();
  const month = datetime.getMonth() + 1;
  const day = datetime.getDate();
  return `${year}-${month}-${day}`;
};

const dict = {
  1: "Monday",
  2: "Tuesday",
  3: "Wednesday",
  4: "Thursday",
  5: "Friday",
  6: "Saturday",
  0: "Sunday"
};
const toWeekday = timestamp => {
  const datetime = new Date(timestamp);
  const day = datetime.getDay();
  return dict[day];
};

const getWeekday = (current, daysToAdd) => {
  const datetime = new Date(current);
  datetime.setDate(datetime.getDate() + daysToAdd);
  const day = datetime.getDay();
  return dict[day];
};

export { dateToMMDD, toWeekday, getWeekday };
