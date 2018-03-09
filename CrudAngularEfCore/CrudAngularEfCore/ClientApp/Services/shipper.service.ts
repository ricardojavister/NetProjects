﻿import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class ShipperService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getEmployees() {
        return this._http.get(this.myAppUrl + 'api/Shipper/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getEmployeeById(id: number) {
        return this._http.get(this.myAppUrl + "api/Shipper/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveEmployee(shipper) {
        return this._http.post(this.myAppUrl + 'api/Shipper/Create', employee)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateEmployee(employee) {
        return this._http.put(this.myAppUrl + 'api/Shipper/Edit', employee)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteEmployee(id) {
        return this._http.delete(this.myAppUrl + "api/Shipper/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}  