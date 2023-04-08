import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any =[];
  widthImg: number = 150;
  marginImg: number = 2;
  displayImg: boolean = true;
  private _listFilter: string = '';

  public get listFilter(){
    return this._listFilter;
  }

  public set listFilter(value: string){
    this._listFilter = value;
    this.eventosFiltrados = this.listFilter ? this.eventsFilter(this.listFilter) : this.eventos;
  }

  eventsFilter(filterBy : string): any{
    filterBy = filterBy.toLocaleLowerCase();
    return this.eventos.filter(
      (evento:{tema:string, local:string}) => evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filterBy) !== -1
      )
  }

  constructor(private http : HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  changeImage() {
    this.displayImg = !this.displayImg;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response,
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error),
      );
  }

}
