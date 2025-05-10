import { Injectable } from '@angular/core';
import { CarrinhoItem } from '../models/carrinho-item.model';

@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {

  private itens: CarrinhoItem[] = [];

  constructor() {
    this.itens = JSON.parse(localStorage.getItem('carrinho') || '[]');
  }

  getItens(): CarrinhoItem[] {
    return this.itens;
  }

  adicionar(item: CarrinhoItem): void {
    this.itens.push(item);
    this.salvar();
  }

  remover(item: CarrinhoItem): void {
    this.itens = this.itens.filter(i => i !== item);
    this.salvar();
  }

  limpar(): void {
    this.itens = [];
    this.salvar();
  }

  salvar(): void {
    localStorage.setItem('carrinho', JSON.stringify(this.itens));
  }

  getTotal(): number {
    return this.itens.reduce((total, item) => total + item.subtotal * item.quantidade, 0);
  }
}
