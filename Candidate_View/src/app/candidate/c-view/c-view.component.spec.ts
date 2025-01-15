import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CViewComponent } from './c-view.component';

describe('CViewComponent', () => {
  let component: CViewComponent;
  let fixture: ComponentFixture<CViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CViewComponent]
    });
    fixture = TestBed.createComponent(CViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
