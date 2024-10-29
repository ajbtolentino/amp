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
            const log = Cypress.log({
                displayName: "LOGIN",
                message: [`🔐 Authenticating | ${username}`],
                autoEnd: false,
            });

            log.snapshot("before");

            cy.visit("/");
            cy.contains("Login").click();
            cy.wait(3000);

            const args = { username, password };

            cy.origin("https://localhost:5443", { args }, ({ username, password }) => {
                cy.get("#Username").type(username);
                cy.get("#Password").type(password);
                cy.get("form").submit();

            });


            cy.wait(2000);

            cy.contains("Get Started").should("be.visible");
        },
        {
            validate: () => {
                cy.window().its("cookies").invoke("getItem", "idsrv.session").should("exist");
            },
        }
    );
})

Cypress.Commands.add("rewriteHeaders", () => {
    cy.intercept("*", (req) =>
        req.on("response", (res) => {
            const setCookies = res.headers["set-cookie"]
            res.headers["set-cookie"] = (
                Array.isArray(setCookies) ? setCookies : [setCookies]
            )
                .filter((x) => x)
                .map((headerContent) =>
                    headerContent.replace(
                        /samesite=(lax|strict)/gi,
                        "secure; samesite=none"
                    )
                )
        })
    )
})