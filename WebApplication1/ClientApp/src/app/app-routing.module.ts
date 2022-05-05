import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarDetailsComponent } from './car-details/car-details.component';
import { CarComponent } from './car/car.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';

const routes: Routes = [
  { path: '', redirectTo: '/cars', pathMatch: 'full'  },
  { path: 'cars', component: CarComponent },
	{ path: 'car-details/:id', component: CarDetailsComponent },
  { path: 'cart', component: ShoppingCartComponent },
  { path: '404', component: NotFoundComponent },
  { path: '500', component: InternalServerComponent },
	{ path: '**', redirectTo: '/404', pathMatch: 'full' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
