import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PagesModule } from 'src/app/pages/pages.module';
import { AppComponent } from './app.component';
import { ComponentsModule } from './components/components.module';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { HttpService } from './service/http/http.service';
import { TasksService } from './service/tasks.service';
import { HttpHandler, HttpClientModule } from '@angular/common/http';
import { ErrorHandlerInterceptor } from './service/http/error-handler.interceptor';
import { BoardService } from 'src/app/service/board.service';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BcModalModule } from './components/bc-modal';
import { TasksPageComponent } from './pages/tasks-page/tasks-page.component';
import { CardService } from './service/card.service';

const appRoutes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: 'tasks', component: TasksPageComponent },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ComponentsModule,
    PagesModule,
    HttpClientModule,
    BcModalModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: false } // <-- debugging purposes only
    )
  ],
  exports: [ComponentsModule],
  providers: [
    HttpService,
    ErrorHandlerInterceptor,
    TasksService,
    BoardService,
    CardService,
    BsModalService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
