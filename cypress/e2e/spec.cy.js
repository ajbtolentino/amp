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
    // cy.loginToApplication('admin', 'P@assw0rd.123')
    // cy.get('[label="Logout"]').should('be.visible')
    //cy.log('passed')
  })
})