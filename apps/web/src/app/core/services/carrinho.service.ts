import { Injectable } from '@angular/core';
import { CarrinhoItem } from '../models/carrinho-item.model';

@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {

  private itens: CarrinhoItem[] = [];

  getItens(): CarrinhoItem[] {
    return this.itens;
  }

  adicionar(item: CarrinhoItem): void {
    this.itens.push(item);
  }

  remover(index: number): void {
    this.itens.splice(index, 1);
  }

  limpar(): void {
    this.itens = [];
  }

  getTotal(): number {
    return this.itens.reduce((total, item) => total + item.subtotal, 0);
  }
}
