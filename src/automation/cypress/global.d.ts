/// <reference types="cypress" />

declare namespace Cypress {
    interface Chainable {
        /**
         * Logs-in user by using UI
         */
        login(username: string, password: string): void;
        rewriteHeaders(): void;
    }
}