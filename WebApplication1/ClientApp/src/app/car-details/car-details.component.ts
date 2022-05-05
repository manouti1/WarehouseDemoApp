import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import CarDetails from '../models/CarDetails';
import { ToastService } from '../shared/toast-service';
import { WarehouseService } from '../shared/warehouse.service';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {
  vehichleId: string | null;
  carDetails: CarDetails | undefined;
  isError: boolean = false;
  constructor(private warehouseService: WarehouseService, private toastService: ToastService, private route: ActivatedRoute) {
    this.vehichleId = this.route.snapshot.paramMap.get('id');
    console.log(this.vehichleId)
  }

  ngOnInit(): void {
    this.getCarDetails();
  }

  getCarDetails() {

    this.warehouseService.getCarDetails(Number(this.vehichleId)).subscribe({
      next: (v) => {
        this.isError = false;
        this.carDetails = v;
      },
      error: (e) => {
        this.isError = true;
        this.toastService.show('Something went wrong, please try again later on.', { classname: 'bg-danger text-light', delay: 15000, autohide: true });
      },
      complete: () => console.info('complete')
    })
  }

}
