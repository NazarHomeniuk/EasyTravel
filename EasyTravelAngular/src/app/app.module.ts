import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule  } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatStepperModule } from '@angular/material/stepper';
import { MatExpansionModule } from '@angular/material/expansion';
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { AmazingTimePickerModule } from 'amazing-time-picker';
import { MatSnackBarModule } from '@angular/material/snack-bar';

import { MustMatchDirective } from './directives/index';

import { AuthGuardService } from './guards/auth-guard.service';

import { JwtInterceptor, ErrorInterceptor } from './helpers';

import { 
  DashboardComponent,
  FindComponent,
  FindFormComponent,
  TripsComponent,
  LoadingComponent,
  RailwayCardComponent,
  BlaBlaCarCardComponent,
  BusCardComponent,
  TripCardComponent,
  AuthComponent,
  LoginComponent,
  RegisterComponent
} from './components/';

import { 
  LocationsService,
  RailwayService,
  BlaBlaCarService,
  BusService,
  UserService 
} from './services';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    FindFormComponent,
    TripsComponent,
    FindComponent,
    LoadingComponent,
    RailwayCardComponent,
    BlaBlaCarCardComponent,
    BusCardComponent,
    TripCardComponent,
    AuthComponent,
    LoginComponent,
    RegisterComponent,
    MustMatchDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    MatCardModule,
    MatAutocompleteModule,
    MatInputModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
    MatDatepickerModule,
    MatStepperModule,
    MatExpansionModule,
    MatNativeDateModule,
    NgxMaterialTimepickerModule,
    AmazingTimePickerModule,
    MatSnackBarModule
  ],
  providers: [
    LocationsService,
    RailwayService,
    BlaBlaCarService,
    BusService,
    MatDatepickerModule,
    UserService,
    AuthGuardService,
    { provide: MAT_DATE_LOCALE, useValue: 'uk-UA' },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
