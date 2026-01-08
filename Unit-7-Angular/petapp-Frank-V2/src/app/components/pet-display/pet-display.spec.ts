import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PetDisplay } from './pet-display';

describe('PetDisplay', () => {
  let component: PetDisplay;
  let fixture: ComponentFixture<PetDisplay>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PetDisplay]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PetDisplay);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
