import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventpropbindComponent } from './eventpropbind.component';

describe('EventpropbindComponent', () => {
  let component: EventpropbindComponent;
  let fixture: ComponentFixture<EventpropbindComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventpropbindComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EventpropbindComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
