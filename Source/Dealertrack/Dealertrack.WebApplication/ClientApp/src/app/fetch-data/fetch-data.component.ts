import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
 
export class FetchDataComponent {

  public deals: DealsData[];
  public  message :string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<DealsData[]>(baseUrl + 'api/deals/').subscribe(result => {
      this.deals = result;
      if (result == null) { this.message="NoContent"};
    }, error => console.error(error));
  }
}

interface DealsData {
  dealNumber: number;
  customerName: number;
  dealershipName: number;
  vehicle: string;
  price: number;
  soldDate: string;
}
