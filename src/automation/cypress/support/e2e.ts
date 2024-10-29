// ***********************************************************
// This example support/e2e.js is processed and
// loaded automatically before your test files.
//
// This is a great place to put global configuration and
// behavior that modifies Cypress.
//
// You can change the location of this file or turn off
// automatically serving support files with the
// 'supportFile' configuration option.
//
// You can read more here:
// https://on.cypress.io/configuration
// ***********************************************************

// Import commands.js using ES2015 syntax:
import './commands'

// Alternatively you can use CommonJS syntax:
// require('./commands')

beforeEach(() => {
    // cy.intercept middleware to remove 'if-none-match' headers from all requests
    // to prevent the server from returning cached responses of API requests
    cy.intercept(
        { url: "http://localhost:4200/**", middleware: true },
        (req) => delete req.headers["if-none-match"]
    );
});