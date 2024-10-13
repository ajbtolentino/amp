import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvitationDetailsComponent } from './invitation-details.component';

describe('InvitationDetailsComponent', () => {
  let component: InvitationDetailsComponent;
  let fixture: ComponentFixture<InvitationDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InvitationDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvitationDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
