import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  widthImg: number = 50;
  marginImg: number = 2;

  constructor(private http: HttpClient) { }

  public getEventos(): void {
    this.http.get(`https://localhost:44362/api/eventos`).subscribe(
      response => this.eventos = response,
      error => console.log(error)
      );
  }

  ngOnInit(): void {
    this.getEventos();
  }

}
