import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataSharingService {
  private status:boolean = false
  constructor() { }
  getStatus(){
    return this.status
  }
  setStatus(b:boolean){
    this.status = b;
  }
}
