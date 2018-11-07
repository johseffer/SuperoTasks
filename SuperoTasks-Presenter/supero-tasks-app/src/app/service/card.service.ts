import { Injectable } from '@angular/core';
import { HttpService } from './http/http.service';
import { CardModel } from '../models/card-model';

@Injectable()
export class CardService {
  data: any;

  constructor(public httpService: HttpService) {

  }

  getCard(cardId: string) {
    return this.httpService.get(`http://localhost:62824/api/Card/${cardId}`);
  }

  addCard(card: CardModel) {
    return this.httpService.post(`http://localhost:62824/api/Card`, card);
  }

  updateCard(card: CardModel) {
    return this.httpService.put(`http://localhost:62824/api/Card`, card);
  }

  updateCardBoard($cardId: string, $boardId: string) {
    return this.httpService.put(`http://localhost:62824/api/Card/UpdateBoard`, { cardId: $cardId, boardId: $boardId });
  }

  deleteCard(cardId: number) {
    return this.httpService.delete(`http://localhost:62824/api/Card/${cardId}`);
  }

  getCards() {
    return this.httpService.get('http://localhost:62824/api/Card');
  }
}
