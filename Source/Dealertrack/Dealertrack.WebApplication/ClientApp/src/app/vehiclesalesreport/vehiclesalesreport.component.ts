import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-vehiclesalesreport',
  templateUrl: './vehiclesalesreport.component.html'
})
export class VehicleSalesComponent {

  public vehiclesales: VehicleSales[];
  public message: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<VehicleSales[]>(baseUrl + 'api/deals/vehiclesales').subscribe(result => {
      this.vehiclesales = result;
      if (result == null) { this.message = "NoContent" };
    }, error => console.error(error));
  }
}

interface VehicleSales {
  name: string;
  unitSold: number;

}
