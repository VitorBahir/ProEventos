import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  //styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {

  public events: any = [];
  public filteredEvents: any =[];
  widthImg: number = 150;
  marginImg: number = 2;
  displayImg: boolean = true;
  private _listFilter: string = '';

  public get listFilter(){
    return this._listFilter;
  }

  public set listFilter(value: string){
    this._listFilter = value;
    this.filteredEvents = this.listFilter ? this.eventsFilter(this.listFilter) : this.events;
  }

  eventsFilter(filterBy : string): any{
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event:{theme:string, place:string}) => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      event.place.toLocaleLowerCase().indexOf(filterBy) !== -1
      )
  }

  constructor(private http : HttpClient) { }

  ngOnInit(): void {
    this.getEvents();
  }

  changeImage() {
    this.displayImg = !this.displayImg;
  }

  public getEvents(): void {
    this.http.get('https://localhost:5001/api/events').subscribe(
      response => {
        this.events = response,
        this.filteredEvents = this.events
      },
      error => console.log(error),
      );
  }

}
