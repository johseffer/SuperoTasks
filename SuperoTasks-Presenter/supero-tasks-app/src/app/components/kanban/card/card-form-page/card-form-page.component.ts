import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { CardService } from 'src/app/service/card.service';
import { CardModel } from 'src/app/models/card-model';
import { BoardModel } from 'src/app/models/board-model';

@Component({
  selector: 'app-card-form-page',
  templateUrl: './card-form-page.component.html',
  styleUrls: ['./card-form-page.component.scss']
})
export class CardFormPageComponent implements OnInit {
  @Input() board: BoardModel;
  @Output() boardReturn: BoardModel;
  @Input() entity: any;
  @Input() isEdit: boolean;
  title = new FormControl('', [Validators.required, Validators.maxLength(100)]);
  description = new FormControl('', [Validators.required, Validators.maxLength(100)]);
  @Output() close = new EventEmitter<CardModel>(false);

  constructor(private builder: FormBuilder, public bsModalRef: BsModalRef, public cardService: CardService) { }

  delete() {
    if (confirm('Tem certeza que deseja remover a tarefa ' + name + '?')) {
      this.cardService.deleteCard(this.entity.id)
        .subscribe(
          r => {
            this.board.cards.splice(this.board.cards.indexOf(this.entity), 1);
            this.close.emit(this.entity as CardModel);
            this.bsModalRef.hide();
          },
          error => {
            alert('Erro ao excluir registro.');
          });
    }
  }

  save() {
    // if (this.isEdit) {
    //   this.cardService.editCard({ id: this.entity.id, name: this.name.value })
    //     .then(result => {
    this.bsModalRef.hide();
    this.entity.title = this.title.value;
    this.entity.description = this.description.value;
    if (this.isEdit) {
      this.cardService.updateCard(this.entity)
        .subscribe(
          r => {
            this.close.emit(r as CardModel);
          },
          error => {
            alert('Erro ao salvar registro.');
          });
    } else {
      this.cardService.addCard(this.entity)
        .subscribe(
          r => {
            this.close.emit(r as CardModel);
          },
          error => {
            alert('Erro ao salvar registro.');
          });
    }
  }
  cancel() {
    this.bsModalRef.hide();
  }

  getErrorMessageTitle() {
    return this.title.hasError('required') ? 'Digite o título da atividade' : '';
  }

  getErrorMessageDescription() {
    return this.description.hasError('required') ? 'Digite a descrição da atividade' : '';
  }

  ngOnInit() {
    if (this.entity) {
      this.title.setValue(this.entity.title);
      this.description.setValue(this.entity.description);
    }
  }

}
