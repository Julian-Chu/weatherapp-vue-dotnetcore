[![Build Status](https://travis-ci.com/Julian-Chu/weatherapp-vue-dotnetcore.svg?branch=master)](https://travis-ci.com/Julian-Chu/weatherapp-vue-dotnetcore)
# Overview
- Vuejs 2.X
- ASP.NET Core 3.1
# Install
```shell
npm run full-install
```
# Run
### frontend:
```shell
npm run client
```

### backend
**backend app will get API key from environment variable, please set OPENWEATHER_APIKEY={your open weather api key} before run server**
```shell
// bash
OPENWEATHER_APIKEY={your open weather api key} npm run server
```
or
```shell
// windows command line 
set OPENWEATHER_APIKEY={your open weather api key}
npm run server
```

original template from: [link](https://www.themezy.com/free-website-templates/128-steel-weather-free-responsive-website-template)

modified by using css grid
