import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'
import { map } from 'rxjs/operators';
import { AnimateTimings } from '@angular/animations';


@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  url='https://localhost:44365/api/Company/GetCompany';
  posturl='https://localhost:44365/api/Company/CreateCompany';
  puturl='https://localhost:44365/api/Company/UpdateCompany';
  deleteurl='https://localhost:44365/api/Company/DeleteCompany/';
    

  constructor(private http:HttpClient) { }
   getAllCompany(){
     return this.http.get<any>( this.url)
     .pipe(map((res:any)=>{
      return res;
     }))
   }
  

  postCompany(data: any){
    return this.http.post<any>(this.posturl, data)
    .pipe(map((res:any)=>{
      return res;
    }))
  }

  

  UpdateCompany(data: any,userId: number){
    return this.http.put<any>(this.puturl,data)
    .pipe(map((res: any)=>{
      return res;
    }))

  }
    
    deletec(userId:number){
      return this.http.delete<any>(this.deleteurl+userId).pipe(map((res: any)=>{return res;}))
    }
}
