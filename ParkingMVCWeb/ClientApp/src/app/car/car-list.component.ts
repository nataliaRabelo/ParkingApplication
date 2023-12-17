import { Component, OnInit } from '@angular/core';
import { Car } from './service/car';
import { CarService } from './service/car.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {

  car: Car = new Car();
  cars: Car[] = [];
  selectedCar: Car | undefined;

   
  constructor(private carService: CarService) {
    console.log("entrou no construtor");
  }

 
  ngOnInit(): void {
    console.log("entrou no ngoninit");
    this.carService.getCars().subscribe(
      data => {
        this.cars = data;
        console.log(data);
      },
      error => {
        console.error(error);
      }
    );
  }
   
  addCar(car: Car): void {
    console.log("entrei em add car.")
    this.carService.addCar(car).subscribe(
      data => {
        this.cars.push(data);
      },
      error => {
        console.error(error);
      }
    );
  }

  editCar(car: Car): void {
    this.selectedCar = car;
  }
  
  viewCar(car: Car): void {
    this.selectedCar = car;
  }

  onSubmit(form: any): void {
    const updatedCar: Car = {
      id: this.selectedCar!.id,
      model: form.model,
      color: form.color,
      plate: form.plate
    };

    this.carService.updateCar(this.selectedCar!.id, updatedCar).subscribe(
      data => {
        const index = this.cars.findIndex(c => c.id === this.selectedCar!.id);
        this.cars[index] = data;
        this.selectedCar = undefined;
      },
      error => {
        console.error(error);
      }
    );
  }

  removeCar(car: Car): void {
    if (confirm(`Are you sure you want to remove the car with plate number ${car.plate}?`)) {
      this.carService.deleteCar(car.id).subscribe(
        () => {
          const index = this.cars.findIndex(c => c.id === car.id);
          this.cars.splice(index, 1);
        },
        error => {
          console.error(error);
        }
      );
    }
  }

}
