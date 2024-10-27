// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add('login', (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add('drag', { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add('dismiss', { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite('visit', (originalFn, url, options) => { ... })

Cypress.Commands.add('loginToApplication', (username, password) => {

    cy.get('[label="Login"]').click()
    cy.wait(2000)

    // cy.location().then((url) => {
    //     cy.log('URL:' + url)
    //     cy.wait(2000)

    //     // const encodedURL = encodeURI(fullUrl);

    //     // const url = new URL(encodedURL);
    //     // const baseUrl = `${url.protocol}//${url.host}`;

    //     // cy.origin(baseUrl, { args: { username, password } }, ({ username, password }) => {
    //     //     setTimeout(() => {
    //     //         cy.get('#Username').focus().type(username)
    //     //         cy.get('#Password').focus().type(password)
    //     //         cy.get('form').submit()

    //     //     }, 2000);

    //     // });

    // });

    cy.origin('https://amp-idp.azurewebsites.net', { args: { username, password } }, ({ username, password }) => {
        cy.get('#Username').focus().type(username)
        cy.get('#Password').focus().type(password)
        cy.get('form').submit()
        cy.wait(5000)
    });

});