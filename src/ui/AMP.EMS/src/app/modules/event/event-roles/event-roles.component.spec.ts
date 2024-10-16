import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventRolesComponent } from './event-roles.component';

describe('EventRolesComponent', () => {
  let component: EventRolesComponent;
  let fixture: ComponentFixture<EventRolesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EventRolesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventRolesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
