import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Car from '../models/Car';
import ResponseData from '../models/ResponseData';
import { ToastService } from '../shared/toast-service';
import { WarehouseService } from '../shared/warehouse.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styles: [

  ]
})
export class CarComponent implements OnInit {
  page: number = 1;
  collectionSize: number = 0;
  cars: Car[] = [];
  pageSize = 10;
  isError: boolean = false;
  previousPage: number = 1;
  constructor(private warehouseService: WarehouseService, private toastService: ToastService, private router: Router) {
    this.loadData();
  }

  ngOnInit(): void {}
  
  loadPage(page: number) {
    if (page !== this.previousPage) {
      this.previousPage = page;
      this.loadData();
    }
  }
  goToDetails(id: number) {
    this.router.navigate(['/car-details', id]);
  }
  loadData() {
    this.warehouseService.getAllCarsByDateAsc(this.page).subscribe({
      next: (v: ResponseData) => {
        this.isError = false;
        this.cars = v.car;
        this.collectionSize = v.collectionSize;
      },
      error: (e) => {
        this.isError = true;
        this.toastService.show('Something went wrong, please try again later on.', { classname: 'bg-danger text-light', delay: 15000, autohide: true });
      },
      complete: () => console.info('complete')
    });
  }

}
