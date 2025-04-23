import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterModule } from '@angular/router'; 

@NgModule({
  declarations: [
    FooterComponent,

  ],
  imports: [
    CommonModule,
    RouterModule,
    NavbarComponent,
    HeaderComponent
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    HeaderComponent
  ]
})
export class LayoutsModule {}
