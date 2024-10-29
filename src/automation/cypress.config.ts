const { defineConfig } = require("cypress");

module.exports = defineConfig({
  e2e: {
    chromeWebSecurity: false,
    baseUrl: "http://localhost:4200",
    specPattern: "cypress/e2e/**/*.spec.{js,jsx,ts,tsx}",
    viewportHeight: 1000,
    viewportWidth: 1280,
    experimentalRunAllSpecs: true,
    setupNodeEvents(on, config) {
      // implement node event listeners here
      on('before:browser:launch', (browser: any, launchOptions) => {
        if (browser.name === 'chrome' || browser.name === 'edge') {
          launchOptions.args.push('--disable-features=SameSiteByDefaultCookies') // bypass 401 unauthorised access on chromium-based browsers
          return launchOptions
        }
      })
    },
  },
});
