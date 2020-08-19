import { Router } from '@angular/router';
import { AppModule } from './../../app.module';
import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { AuthenticationService } from './../../services/authentication.service';
import { UserService } from './../../services/user.service';
import { User } from './../../models/userModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  currentUser: User;
  users = [];

  constructor(
    private authenticationService: AuthenticationService,
    private userService: UserService,
    private router: Router
  ) { 
    this.currentUser = this.authenticationService.currentUserValue;
  }

  ngOnInit() {
    this.loadAllUsers();
  }

  deleteUser(id: number) {
    this.userService.delete(id)
      .pipe(first())
      .subscribe(() => this.loadAllUsers());
  }

  logoutUser() {
    this.authenticationService.logout();
    this.router.navigate(['/start']);
  }

  private loadAllUsers() {
    this.userService.getAll()
      .pipe(first())
      .subscribe(users => this.users = users);
  }

}
