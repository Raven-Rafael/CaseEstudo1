import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocespremiumComponent } from './docespremium.component';

describe('DocespremiumComponent', () => {
  let component: DocespremiumComponent;
  let fixture: ComponentFixture<DocespremiumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DocespremiumComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DocespremiumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
