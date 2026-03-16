import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarEditarProdutosComponent } from './criar-editar-produtos.component';

describe('CriarEditarProdutosComponent', () => {
  let component: CriarEditarProdutosComponent;
  let fixture: ComponentFixture<CriarEditarProdutosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CriarEditarProdutosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CriarEditarProdutosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
