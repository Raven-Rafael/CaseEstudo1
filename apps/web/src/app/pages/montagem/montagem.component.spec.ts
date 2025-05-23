import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MontagemComponent } from './montagem.component';

describe('MontagemComponent', () => {
  let component: MontagemComponent;
  let fixture: ComponentFixture<MontagemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MontagemComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MontagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
