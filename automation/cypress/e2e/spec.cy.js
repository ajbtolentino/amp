describe('template spec', () => {

  const sessionIdentifier = 'test'

  beforeEach('login to application', () => {
    cy.session(sessionIdentifier, () => {
      cy.visit('/')
      cy.loginToApplication('', '')
    })
  })

  it('login', () => {
    // cy.visit('/')
    // cy.loginToApplication('', '')
    // cy.get('[label="Logout"]').should('be.visible')
    //cy.log('passed')
  })
})