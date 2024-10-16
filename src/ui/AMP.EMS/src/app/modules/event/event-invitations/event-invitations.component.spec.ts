import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventInvitationsComponent } from './event-invitations.component';

describe('EventInvitationsComponent', () => {
  let component: EventInvitationsComponent;
  let fixture: ComponentFixture<EventInvitationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EventInvitationsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventInvitationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
