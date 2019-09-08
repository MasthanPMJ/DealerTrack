import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { VehicleSalesComponent } from './vehiclesalesreport/vehiclesalesreport.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DataImportComponent } from './data-import/data-import.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    VehicleSalesComponent,
    FetchDataComponent,
    DataImportComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'vehiclesalesreport', component: VehicleSalesComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'data-import', component: DataImportComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
