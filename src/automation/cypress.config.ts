const { defineConfig } = require("cypress");

module.exports = defineConfig({
  e2e: {
    env: {
      authUrl: "https://amp-idp.azurewebsites.net"
    },
    baseUrl: "http://amp-ems-dev.azurewebsites.net",
    specPattern: "cypress/e2e/**/*.spec.{js,jsx,ts,tsx}",
    viewportHeight: 1000,
    viewportWidth: 1280,
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
  },
});
