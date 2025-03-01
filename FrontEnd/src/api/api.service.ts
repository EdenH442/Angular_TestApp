import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:5216/api/actions'; 

  constructor(private http: HttpClient) {}

  // Call the button API
  buttonClicked(): Observable<any> {
    return this.http.post(`${this.apiUrl}/buttonclicked`, {});
  }

  showItemList(): Observable<any> {
    return this.http.get(`${this.apiUrl}/items`);
  }
}
