import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from './../models/userModel';
import { environment } from './../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(private httpClient: HttpClient) {}

    getAll() {
        return this.httpClient.get<User[]>(`${environment.apiUrl}/users`);
    }

    register(user: User) {
        return this.httpClient.post(`${environment.apiUrl}/users/register`, user);
    }

    delete(id: number) {
        return this.httpClient.delete(`${environment.apiUrl}/users/${id}`);
    }
}