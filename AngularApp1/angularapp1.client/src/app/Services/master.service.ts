import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICodeReview } from '../Models/Interface/ICodeReview';

@Injectable({
  providedIn: 'root'
})
export class MasterService {

  constructor(private http: HttpClient) { }


  getAllCodeReviews(): Observable<ICodeReview[]> {

    return this.http.get<ICodeReview[]>("https://localhost:7151/api/codereview")
    }

}
