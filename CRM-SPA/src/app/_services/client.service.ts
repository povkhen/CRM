import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../_models/Client';
import { Order } from '../_models/order';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(this.baseUrl + 'clients');
  }

  getClient(id): Observable<Client> {
    return this.http.get<Client>(this.baseUrl + 'clients/' + id);
  }

  addOrder(id: number, order: Order) {
    return this.http.post(this.baseUrl + 'clients/' + id + '/addorder', order);
  }
}
