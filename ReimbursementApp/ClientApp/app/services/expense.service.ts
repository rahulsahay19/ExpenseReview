﻿import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ExpenseService {
    constructor(private http: Http, @Inject('BASE_URL') private originUrl: string) { }

    getExpenses() {
        return this.http.get(this.originUrl + 'api/expense')
            //Once, we get the response back, it has to get mapped to json
            .map(res => res.json());
    }

    myExpenses() {
        return this.http.get(this.originUrl + 'api/expense/myexpenses')
            //Once, we get the response back, it has to get mapped to json
            .map(res => res.json());
    }
    submitExpense(expense) {
        return this.http.post(this.originUrl + 'api/expense',expense)
            //Once, we get the response back, it has to get mapped to json
            .map(res => res.json());
    }

    approveExpense(id, reason, approvedDate, expense) {
        expense[0].reason = reason;
        expense[0].approvedDate = approvedDate;
        const body = JSON.stringify(expense[0]);
        const headers = new Headers({ 'Content-Type': 'application/json' });
        return this.http.put(this.originUrl + 'api/expense/', body, { headers: headers })
        .map(res => res.json());
    }
    editExpense(expense) {
        const body = JSON.stringify(expense);
        const headers = new Headers({ 'Content-Type': 'application/json' });
        return this.http.put(this.originUrl + 'api/expense/', body, { headers: headers })
            .map(res => res.json());
    }

    rejectExpense(id, reason, approvedDate, expense) {
        expense[0].reason = reason;
        expense[0].approvedDate = approvedDate;
        expense[0].rejectedFlag = "Rejected";
        const body = JSON.stringify(expense[0]);
        const headers = new Headers({ 'Content-Type': 'application/json' });
        return this.http.put(this.originUrl + 'api/expense/', body, { headers: headers })
            .map(res => res.json());
    }

    getExpenseById(id) {
        return this.http.get(this.originUrl + 'api/expense/' + id)
            .map(res => res.json());
    }

    getExpenseByName(name) {
        return this.http.get(this.originUrl + 'api/expense/GetByName/' + name)
            .map(res => res.json());
    }

    getExpenseByDesig(desig) {
        return this.http.get(this.originUrl + 'api/expense/GetByDesignation/' + desig)
            .map(res => res.json());
    }

    getExpenseByManager(manager) {
        return this.http.get(this.originUrl + 'api/expense/GetByManager/' + manager)
            .map(res => res.json());
    }
}