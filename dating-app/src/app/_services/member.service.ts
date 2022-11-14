import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Member } from '../_models/member';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class MemberService {
    headers = new HttpHeaders({
        'Content-Type': 'application/json'
    });

    baseUrl = 'https://localhost:7030/api/member';
    constructor(
        private httpClient: HttpClient,
    ) { }

    getMembers(): Observable<Member[]> {
        return this.httpClient.get<Member[]>(this.baseUrl);
    }

    getMemberByUsername(username: string): Observable<Member> {
        return this.httpClient.get<Member>(`${this.baseUrl}/${username}`);
    }
}
