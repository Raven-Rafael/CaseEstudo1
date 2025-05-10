import { Component, OnInit } from '@angular/core';
import { CarrinhoService } from 'src/app/core/services/carrinho.service';
import { CarrinhoItem } from 'src/app/core/models/carrinho-item.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-carrinho',
  standalone: false,
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.scss']
})
export class CarrinhoComponent implements OnInit {

  carrinho: CarrinhoItem[] = [];

  constructor(
    private carrinhoService: CarrinhoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.carrinho = this.carrinhoService.getItens();
  }

  aumentarQuantidade(item: CarrinhoItem): void {
    item.quantidade++;
    this.carrinhoService.salvar();
  }

  diminuirQuantidade(item: CarrinhoItem): void {
    if (item.quantidade > 1) {
      item.quantidade--;
      this.carrinhoService.salvar();
    }
  }

  removerItem(item: CarrinhoItem): void {
    this.carrinhoService.remover(item);
    this.carrinho = this.carrinhoService.getItens();
  }

  get total(): number {
    return this.carrinho.reduce((acc, item) => acc + (item.subtotal * item.quantidade), 0);
  }

  finalizarPedido(): void {
    this.router.navigate(['/checkout']);
  }
}
