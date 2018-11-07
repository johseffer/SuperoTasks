import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './home-page/home-page.component';
import { ComponentsModule } from 'src/app/components/components.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TasksPageComponent } from './tasks-page/tasks-page.component';

@NgModule({
  imports: [
    CommonModule,
    ComponentsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    HomePageComponent,
    TasksPageComponent,
    PageNotFoundComponent
  ]
})
export class PagesModule { }
