import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
 
 
@Injectable({
  providedIn: 'root'
})
export class CarsService {
 
 
 
  private baseUrl = 'api/Cars/';  
 
  constructor(private http: HttpClient) { }
 
  getAll(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}`);
  }
 
  get(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}${id}`);
  }
 
  create(data: any): Observable<any> {
    return this.http.post(this.baseUrl, data);
  }
 
  update(id: number, data: any): Observable<any> {
    return this.http.put(`${this.baseUrl}${id}`, data);
  }
 
  delete(id: string, make: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}/${make}`);
  }

 
}
