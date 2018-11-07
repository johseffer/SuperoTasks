import { Component, Input, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { CardFormPageComponent } from './card-form-page/card-form-page.component';
import { CardModel } from 'src/app/models/card-model';
import { BoardModel } from 'src/app/models/board-model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
  @Input() board: BoardModel;
  @Input() card: CardModel;

  subscription: any;
  bsModalRef: any;

  constructor(protected $bsModalService: BsModalService) { }

  ngOnInit() {
  }

  public openDetail(event, item) {
    const initialState = { entity: this.card, isEdit: true, board: this.board };
    this.bsModalRef = this.$bsModalService.show(CardFormPageComponent, Object.assign({}, {}, { class: 'modal-sm', initialState }));
    this.subscription = this.bsModalRef.content.close.subscribe(($e) => {
      this.subscription.unsubscribe();
      this.card = $e;
    });
  }

  dragStart(ev) {
    ev.dataTransfer.setData('text', ev.target.id);
  }
}
