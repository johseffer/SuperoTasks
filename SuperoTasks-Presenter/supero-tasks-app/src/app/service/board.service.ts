import { Injectable } from '@angular/core';
import { HttpService } from './http/http.service';
import { BoardModel } from '../models/board-model';

@Injectable()
export class BoardService {
  data: any;

  constructor(public httpService: HttpService) {

  }

  getBoard(boardId: number) {
    return this.httpService.get(`http://localhost:62824/api/Board/${boardId}`);
  }

  addBoard(board: BoardModel) {
    return this.httpService.post(`http://localhost:62824/api/Board`, board);
  }

  DeleteBoard(boardId: number) {
    return this.httpService.delete(`http://localhost:62824/api/Board/${boardId}`);
  }

  getBoards() {
    return this.httpService.get('http://localhost:62824/api/Board');
  }
}
