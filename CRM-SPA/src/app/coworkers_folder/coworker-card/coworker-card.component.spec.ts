/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CoworkerCardComponent } from './coworker-card.component';

describe('CoworkerCardComponent', () => {
  let component: CoworkerCardComponent;
  let fixture: ComponentFixture<CoworkerCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoworkerCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoworkerCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
