import { Component, OnInit } from '@angular/core';
import { PizzaService } from 'src/app/core/services/pizza.service';
import { Sabor } from 'src/app/core/models/sabor.model';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  pizzasDestaque: Sabor[] = [];

  constructor(private pizzaService: PizzaService) {}

  ngOnInit(): void {
    this.pizzaService.getSabores().subscribe(sabores => {

      this.pizzasDestaque = sabores.slice(0, 3);
    });
  }
}
