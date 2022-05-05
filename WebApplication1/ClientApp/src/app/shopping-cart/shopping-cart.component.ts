import { Component, OnInit, Type } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import Car from '../models/Car';
import { CartItem } from '../models/CartItem';
import { ConfirmModalComponent } from './confirm-modal/confirm-modal.component';

const MODALS: { [name: string]: Type<any> } = {
  autofocus: ConfirmModalComponent
};

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})

export class ShoppingCartComponent implements OnInit {
  items: CartItem[] = [];
  total: number = 0;
  car: Car | undefined;
  constructor(private router: Router,
    private modalService: NgbModal
  ) {
    this.car = this.router.getCurrentNavigation()?.extras.state as Car;
  }

  ngOnInit(): void {
    if (this.car) {
      var item: CartItem = {
        car: this.car,
        quantity: 1
      };
      if (localStorage.getItem('cart') == null) {
        let cart: any = [];
        cart.push(JSON.stringify(item));
        localStorage.setItem('cart', JSON.stringify(cart));
      } else {
        let cart: any = JSON.parse(localStorage.getItem('cart') || '{}');
        let index: number = -1;
        for (var i = 0; i < cart.length; i++) {
          let item: CartItem = JSON.parse(cart[i]);
          if (item.car.vehicleId == this.car.vehicleId) {
            index = i;
            break;
          }
        }
        if (index == -1) {
          cart.push(JSON.stringify(item));
          localStorage.setItem('cart', JSON.stringify(cart));
        } else {
          let item: CartItem = JSON.parse(cart[index]);
          item.quantity += 1;
          cart[index] = JSON.stringify(item);
          localStorage.setItem("cart", JSON.stringify(cart));
        }
      }
      this.loadCart();
    } else {
      this.loadCart();
    }

  }

  loadCart(): void {

    this.total = 0;
    this.items = [];
    let cart = JSON.parse(localStorage.getItem('cart') || '{}');
    for (var i = 0; i < cart.length; i++) {
      let item = JSON.parse(cart[i]);
      this.items.push({
        car: item.car,
        quantity: item.quantity
      });
      this.total += item.car.price * item.quantity;
    }
  }

  remove(id: string): void {
    let cart: any = JSON.parse(localStorage.getItem('cart') || '{}');

    this.open('autofocus', () => {
        for (var i = 0; i < cart.length; i++) {
          let item: CartItem = JSON.parse(cart[i]);
          if (item.car.vehicleId.toString() == id) {
            cart.splice(i, 1);
            break;
          }
        }
        localStorage.setItem("cart", JSON.stringify(cart));
        this.loadCart();
    }, () => {
      
    });
  }

  open(name: string, modalOkCallback: Function, modalDismissCallback: Function) {
    this.modalService.open(MODALS[name]).result.then((result) => {
      modalOkCallback();
    }, (reason) => {
      modalDismissCallback();
    });;
  }
}
