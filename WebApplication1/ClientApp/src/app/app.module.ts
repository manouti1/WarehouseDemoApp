import { HttpClientModule } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarDetailsComponent } from './car-details/car-details.component';
import { CarComponent } from './car/car.component';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { EnvironmentUrlService } from './shared/environment-url.service';
import { ErrorHandlerService } from './shared/error-handler.service';
import { ToastService } from './shared/toast-service';
import { WarehouseService } from './shared/warehouse.service';
import { ConfirmModalComponent } from './shopping-cart/confirm-modal/confirm-modal.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { ToastComponent } from './toast/toast.component';


@NgModule({
  declarations: [
    CarComponent,
    CarDetailsComponent,
    ShoppingCartComponent,
    AppComponent,
    InternalServerComponent,
    NotFoundComponent,
    ConfirmModalComponent,
    ToastComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [EnvironmentUrlService, ToastService, NgbActiveModal, WarehouseService, ErrorHandlerService],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }
