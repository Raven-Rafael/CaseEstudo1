import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { AlreadyLoggedGuard } from './core/guards/already-logged.guard';
import { HomeComponent } from './pages/home/home.component';
import { DocesComponent } from './pages/doces/doces.component';
import { LoginComponent } from './pages/login/login.component';
import { FitnessComponent } from './pages/fitness/fitness.component';
import { PremiumComponent } from './pages/premium/premium.component';
import { CadastroComponent} from './pages/cadastro/cadastro.component';
import { CardapioComponent } from './pages/cardapio/cardapio.component';
import { MontagemComponent } from './pages/montagem/montagem.component';
import { CheckoutComponent } from './pages/checkout/checkout.component';
import { CarrinhoComponent } from './pages/carrinho/carrinho.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { EspeciaisComponent } from './pages/especiais/especiais.component';
import { DocespremiumComponent } from './pages/docespremium/docespremium.component';
import { TradicionaisComponent } from './pages/tradicionais/tradicionais.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'cadastro', component: CadastroComponent, canActivate: [AlreadyLoggedGuard] },
  { path: 'doces', component: DocesComponent },
  { path: 'login', component: LoginComponent, canActivate: [AlreadyLoggedGuard] },
  { path: 'fitness', component: FitnessComponent },
  { path: 'premium', component: PremiumComponent },
  { path: 'carrinho', component: CarrinhoComponent, canActivate: [AuthGuard] },
  { path: 'cardapio', component: CardapioComponent },
  { path: 'montagem', component: MontagemComponent, canActivate: [AuthGuard] },
  { path: 'especiais', component: EspeciaisComponent },
  { path: 'checkout', component: CheckoutComponent, canActivate: [AuthGuard] },
  { path: 'tradicionais', component: TradicionaisComponent },
  { path: 'docespremium', component: DocespremiumComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
