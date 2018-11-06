import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { HttpService } from 'src/app/service/http/http.service';
import { BoardService } from 'src/app/service/board.service';
import { BoardModel } from 'src/app/models/board-model';
import { CardService } from 'src/app/service/card.service';
import { CardModel } from 'src/app/models/card-model';
import { BsModalService } from 'ngx-bootstrap/modal';
import { CardFormPageComponent } from '../card/card-form-page/card-form-page.component';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {

  boards: BoardModel[];
  displayAddCard = false;
  bsModalRef: any;
  subscription: any;

  constructor(
    protected $bsModalService: BsModalService,
    public boardService: BoardService,
    public cardService: CardService,
    public changeDetectorRef: ChangeDetectorRef) {

  }

  getBoards() {
    this.boardService.getBoards().subscribe(r => {
      this.boards = r as BoardModel[];
      this.changeDetectorRef.detectChanges();
    });
  }

  toggleDisplayAddCard(boardModel: BoardModel) {
    const model = new CardModel();
    model.boardId = boardModel.id;
    const initialState = { entity: model, isEdit: false };
    this.bsModalRef = this.$bsModalService.show(CardFormPageComponent, Object.assign({}, {}, { class: 'modal-sm', initialState }));
    this.subscription = this.bsModalRef.content.close.subscribe(($e) => {
      this.subscription.unsubscribe();
      boardModel.cards.push($e);
    });
  }

  allowDrop($event) {
    $event.preventDefault();
  }

  getBoardJson(boardModel: BoardModel) {
    return JSON.stringify(boardModel);
  }

  drop($event) {
    $event.preventDefault();
    const data = $event.dataTransfer.getData('text');

    let target = $event.target;
    const targetClassName = target.className;

    while (target.className !== 'board-item') {
      target = target.parentNode;
    }
    target = target.querySelector('.cards');

    const boardId = target.attributes['data-boardId'].value;
    const cardId = document.getElementById(data).id;


    this.cardService.updateCardBoard(cardId, boardId).subscribe(
      r => {
        if (targetClassName === 'card') {
          $event.target.parentNode.insertBefore(document.getElementById(data), $event.target);
        } else if (targetClassName === 'board__title') {
          if (target.children.length) {
            target.insertBefore(document.getElementById(data), target.children[0]);
          } else {
            target.appendChild(document.getElementById(data));
          }
        } else {
          target.appendChild(document.getElementById(data));
        }
      },
      error => {
        alert('Erro ao atualizar tarefa!');
       }
    );

  }

  ngOnInit() {
    this.getBoards();
  }

}
