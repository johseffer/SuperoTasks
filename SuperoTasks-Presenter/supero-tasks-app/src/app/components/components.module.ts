import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BasePageComponent } from './ui/base-page/base-page.component';
import { MaterialModule } from 'src/app/material/material.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Router, RouterModule } from '@angular/router';
import { PageTopComponent } from './ui/page-top/page-top.component';
import { PageContentComponent } from './ui/page-content/page-content.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BoardComponent } from './kanban/board/board.component';
import { CardComponent } from './kanban/card/card.component';
import { CardFormPageComponent } from './kanban/card/card-form-page/card-form-page.component';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  entryComponents: [
    CardFormPageComponent
  ]
  ,
  declarations: [
    BasePageComponent,
    PageTopComponent,
    PageContentComponent,
    BoardComponent,
    CardComponent,
    CardFormPageComponent],
  exports: [
    BasePageComponent,
    PageTopComponent,
    PageContentComponent,
    MaterialModule,
    BoardComponent,
    CardComponent
  ]
})
export class ComponentsModule { }
