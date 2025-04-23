import { NgModule } from '@angular/core';
import { AuthGuard } from './core/guards/auth.guard';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { DocesComponent } from './pages/doces/doces.component';
import { LoginComponent } from './pages/login/login.component';
import { FitnessComponent } from './pages/fitness/fitness.component';
import { PremiumComponent } from './pages/premium/premium.component';
import { CardapioComponent } from './pages/cardapio/cardapio.component';
import { MontagemComponent } from './pages/montagem/montagem.component';
import { CheckoutComponent } from './pages/checkout/checkout.component';
import { CarrinhoComponent } from './pages/carrinho/carrinho.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { EspeciaisComponent } from './pages/especiais/especiais.component';
import { DocespremiumComponent } from './pages/docespremium/docespremium.component';
import { TradicionaisComponent } from './pages/tradicionais/tradicionais.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'doces', component: DocesComponent},
  { path: '**', component: NotFoundComponent },
  { path: 'login', component: LoginComponent },
  { path: 'fitness', component: FitnessComponent },
  { path: 'premium', component: PremiumComponent },
  { path: 'carrinho', component: CarrinhoComponent},
  { path: 'cardapio', component: CardapioComponent },
  { path: 'montagem', component: MontagemComponent },
  { path: 'especiais', component: EspeciaisComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: 'tradicionais', component: TradicionaisComponent },
  { path: 'docespremium', component: DocespremiumComponent},
  { path: 'checkout', component: CheckoutComponent, canActivate: [AuthGuard] }



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
