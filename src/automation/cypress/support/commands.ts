// @ts-check
///<reference path="../global.d.ts" />

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
Cypress.Commands.add("login", (username: string, password: string) => {

    cy.session(
        `login-${username}`,
        () => {
            cy.visit("/");
            cy.contains("Login").click();

            cy.wait(3000);

            cy.origin(Cypress.env('authUrl'), { args: { username, password } }, ({ username, password }) => {
                cy.get("form").then(val => {
                    let redirectUrl = val.get(0).getElementsByTagName('input').namedItem('ReturnUrl')?.value;
                    let requestVerificationToken = val.get(0).getElementsByTagName('input').namedItem('__RequestVerificationToken')?.value;
                    cy.request({
                        method: "POST",
                        url: `${Cypress.env('authUrl')}/Account/Login?RedirectUrl=${redirectUrl}`,
                        headers: {
                            "Content-Type": "application/x-www-form-urlencoded",
                            "Accept": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
                        },
                        body: {
                            ReturnUrl: redirectUrl,
                            button: 'login',
                            Username: username,
                            Password: password,
                            __RequestVerificationToken: requestVerificationToken
                        },
                    },).then(response => {
                        const redirects = response?.redirects || [];
                        cy.visit(redirects[1].replace("302: ", ""));
                    })
                });
            });
        });
})
