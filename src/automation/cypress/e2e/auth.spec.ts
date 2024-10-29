describe("User Login", function () {
    beforeEach(function () {
        cy.login("", "");
        cy.visit("/");
    });

    it("Home Page", function () {
        cy.contains("Logout").should("be.visible");
    });
})