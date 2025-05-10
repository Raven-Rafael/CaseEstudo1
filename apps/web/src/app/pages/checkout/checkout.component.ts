import { Component, OnInit } from '@angular/core';
import { CarrinhoItem } from 'src/app/core/models/carrinho-item.model';
import { CarrinhoService } from 'src/app/core/services/carrinho.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-checkout',
  standalone: false,
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  itens: CarrinhoItem[] = [];
  total: number = 0;

  constructor(
    private carrinhoService: CarrinhoService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.itens = this.carrinhoService.getItens();
    this.total = this.carrinhoService.getTotal();
  }

  confirmarPedido(): void {
    this.snackBar.open('Pedido finalizado com sucesso!', 'Fechar', {
      duration: 3000,
      verticalPosition: 'top',
      horizontalPosition: 'center'
    });

    this.carrinhoService.limpar();
    this.router.navigate(['/home']);
  }
}
