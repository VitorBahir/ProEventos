import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventService } from 'src/app/services/event.service';
import { Event } from 'src/app/models/Event';
import { Router } from '@angular/router';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss']
})
export class EventListComponent implements OnInit {

  modalRef = {} as BsModalRef;

  public events: Event[] = [];
  public filteredEvents: Event[] =[];
  public widthImg = 150;
  public marginImg = 2;
  public displayImg = true;
  private listFiltered = '';

  public get listFilter(){
    return this.listFiltered;
  }

  public set listFilter(value: string){
    this.listFiltered = value;
    this.filteredEvents = this.listFilter ? this.eventsFilter(this.listFilter) : this.events;
  }

  public eventsFilter(filterBy : string): Event[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event:{theme:string, place:string}) => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
      event.place.toLocaleLowerCase().indexOf(filterBy) !== -1
      )
  }

  constructor(
    private eventService : EventService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router : Router
              ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEvents();
  }

  public changeImage() : void {
    this.displayImg = !this.displayImg;
  }

  public getEvents(): void {
    this.eventService.getEvents().subscribe({
      next : (events : Event[]) => {
        this.events = events,
        this.filteredEvents = this.events;
      },
      error: (error : any) => {console.log(error)
        , this.spinner.hide()
        , this.toastr.error('Erro ao carregar os eventos.', 'Erro!');},
      complete:() =>  this.spinner.hide()
  });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.toastr.success('O evento foi deletado com Sucesso.', 'Deletado!');
  }

  decline(): void {
    this.modalRef.hide();
  }

  detailEvent(id : number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }

}
