import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { CardapioComponent } from './pages/cardapio/cardapio.component';
import { LoginComponent } from './pages/login/login.component';
import { PrecoPipe } from './shared/pipes/preco.pipe';
import { MontagemComponent } from './pages/montagem/montagem.component';
import { CheckoutComponent } from './pages/checkout/checkout.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { CarrinhoComponent } from './pages/carrinho/carrinho.component';
import { LayoutsModule } from './layouts/layouts.module';
import { TradicionaisComponent } from './pages/tradicionais/tradicionais.component';
import { EspeciaisComponent } from './pages/especiais/especiais.component';
import { PremiumComponent } from './pages/premium/premium.component';
import { DocesComponent } from './pages/doces/doces.component';
import { DocespremiumComponent } from './pages/docespremium/docespremium.component';
import { FitnessComponent } from './pages/fitness/fitness.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PrecoPipe,
    MontagemComponent,
    CheckoutComponent,
    NotFoundComponent,
    CarrinhoComponent,
    TradicionaisComponent,
    EspeciaisComponent,
    PremiumComponent,
    DocesComponent,
    DocespremiumComponent,
    FitnessComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    CardapioComponent,
    LoginComponent,
    LayoutsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
