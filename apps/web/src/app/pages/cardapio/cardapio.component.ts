import { Component, OnInit } from '@angular/core';
import { Sabor } from '../../core/models/sabor.model';
import { PizzaService } from '../../core/services/pizza.service';

@Component({
  selector: 'cardapio.component',
  standalone: false,
  templateUrl: './cardapio.component.html',
  styleUrls: ['./cardapio.component.scss']
})
export class CardapioComponent implements OnInit {

  sabores: Sabor[] = [];

  constructor(private pizzaService: PizzaService) {}

  ngOnInit(): void {
    this.pizzaService.getSabores().subscribe({
      next: (sabores) => this.sabores = sabores,
      error: (err) => console.error('Erro ao carregar sabores', err)
    });
  }

  getImagem(sabor: Sabor): string {
    const nomeNormalizado = sabor.nome
      .toLowerCase()
      .normalize('NFD')
      .replace(/[\u0300-\u036f]/g, '')
      .replace(/\s+/g, '_');

    return `assets/imagens/sabores/${nomeNormalizado}.jpg`;
  }
}
