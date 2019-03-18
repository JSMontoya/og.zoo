import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/shared/generics/base-service';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService<User> {
  constructor(http: HttpClient) {
    super(http, 'user');
  }
}
