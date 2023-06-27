import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './features/users/login/login.component';
import { authInterceptorProviders } from './core/interceptors/auth.interceptor';
import { RegisterComponent } from './features/users/register/register.component';
import { HomeComponent } from './features/home/home.component';
import { NavBarComponent } from './ui/nav-bar/nav-bar.component';
import { FooterComponent } from './ui/footer/footer.component';
import { PageNotFoundComponent } from './ui/page-not-found/page-not-found.component';
import { AlertComponent } from './ui/alert/alert.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';
import { CommonModule, DatePipe } from '@angular/common';
import { AddCategoryComponent } from './features/categories/add-category/add-category.component';
import { ListCategoriesComponent } from './features/categories/list-categories/list-categories.component';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './core/services/in-memory-data.service';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
<<<<<<< HEAD
=======
import { AddPriorityComponent } from './features/priorities/add-priority/add-priority.component';
>>>>>>> 488f9320bcf4ca92ff946fa0e26d33be8adc4c64
import { ListPrioritiesComponent } from './features/priorities/list-priorities/list-priorities.component';
@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    NavBarComponent,
    PageNotFoundComponent,
    AlertComponent,
    ListCategoriesComponent,
    AddCategoryComponent,
<<<<<<< HEAD
=======
    AddPriorityComponent,
>>>>>>> 488f9320bcf4ca92ff946fa0e26d33be8adc4c64
    ListPrioritiesComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPaginationModule,
    HttpClientInMemoryWebApiModule.forRoot(
         InMemoryDataService,{ dataEncapsulation: false,passThruUnknownUrl: true }
      ),
    FontAwesomeModule
    
  ],
  providers: [authInterceptorProviders,DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
