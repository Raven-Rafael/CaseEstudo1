import { Component, OnInit } from '@angular/core';
import { Sabor } from 'src/app/core/models/sabor.model';
import { Borda } from 'src/app/core/models/borda.model';
import { CarrinhoService } from 'src/app/core/services/carrinho.service';
import { Router } from '@angular/router';
import { PizzaService } from 'src/app/core/services/pizza.service';
import { BordaService } from 'src/app/core/services/borda.service';
import { CarrinhoItem } from 'src/app/core/models/carrinho-item.model';

@Component({
  selector: 'app-montagem',
  standalone: false,
  templateUrl: './montagem.component.html',
  styleUrls: ['./montagem.component.scss']
})
export class MontagemComponent implements OnInit {

  sabores: Sabor[] = [];
  bordas: Borda[] = [];
  tamanhos: string[] = ['Broto', 'Média', 'Grande', 'Big', 'Gigante'];

  tamanhoSelecionado: string = '';
  saboresSelecionados: Sabor[] = [];
  bordaSelecionada?: Borda;

  constructor(
    private pizzaService: PizzaService,
    private bordaService: BordaService,
    private carrinhoService: CarrinhoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.pizzaService.getSabores().subscribe(s => this.sabores = s);
    this.bordaService.getTodas().subscribe(b => this.bordas = b);
  }

  getLimiteSabores(): number {
    switch (this.tamanhoSelecionado) {
      case 'Broto': return 1;
      case 'Média': return 2;
      case 'Grande': return 3;
      case 'Big': return 4;
      case 'Gigante': return 5;
      default: return 0;
    }
  }

  selecionarSabor(sabor: Sabor): void {
    const index = this.saboresSelecionados.findIndex(s => s.id === sabor.id);

    if (index !== -1) {
      this.saboresSelecionados.splice(index, 1);
    } else if (this.saboresSelecionados.length < this.getLimiteSabores()) {
      this.saboresSelecionados.push(sabor);
    }
  }

  getSubtotal(): number {
    const precoSabores = this.saboresSelecionados.reduce((acc, sabor) => acc + sabor.preco, 0);
    const media = precoSabores / (this.saboresSelecionados.length || 1);
    const precoBorda = this.bordaSelecionada?.preco ?? 0;
    return media + precoBorda;
  }

  adicionarAoCarrinho(): void {
    const item: CarrinhoItem = {
      saborId: this.saboresSelecionados[0].id,
      sabores: this.saboresSelecionados.map(s => s.nome).join(', '),
      tamanho: this.tamanhoSelecionado,
      borda: this.bordaSelecionada?.nome ?? '',
      quantidade: 1,
      subtotal: this.getSubtotal(),
      nomeSabor: '',
      precoUnitario: 0
    };

    this.carrinhoService.adicionar(item);
    this.router.navigate(['/carrinho']);
  }

  get desabilitaBotao(): boolean {
  return (
    !this.tamanhoSelecionado ||
    this.saboresSelecionados.length === 0 ||
    this.saboresSelecionados.length > this.getLimiteSabores()
  );
  }
}
