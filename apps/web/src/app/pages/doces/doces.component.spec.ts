import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocesComponent } from './doces.component';

describe('DocesComponent', () => {
  let component: DocesComponent;
  let fixture: ComponentFixture<DocesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DocesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DocesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
