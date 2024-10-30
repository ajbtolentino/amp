describe("User Login", function () {
    beforeEach(function () {
        cy.login(Cypress.env('user_name'), Cypress.env('user_password'));
    });

    it("Home Page", function () {
        cy.visit("/");
        cy.contains("Login").click();
        cy.contains("Logout").should("be.visible");
    });

    it("Events", function () {
        cy.visit("/");
        cy.get("[label='Get Started']").click();
    });
})