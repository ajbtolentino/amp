const { defineConfig } = require("cypress");

module.exports = defineConfig({
  viewportHeight: 1080,
  viewportWidth: 1920,

  e2e: {
    setupNodeEvents(on, config) {
      // implement node event listeners here
    },
    experimentalSessionAndOrigin: true,

    baseUrl: 'https://amp-ems-dev.azurewebsites.net/',
    specPattern: 'cypress/e2e/**/*.cy.{js,jsx,ts,tsx}'
  },
});
