import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { AlertifyService } from '../../_services/alertify.service';
import { UserService } from '../../_services/user.service';
import { ActivatedRoute } from '@angular/router';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-coworkers',
  templateUrl: './coworkers.component.html',
  styleUrls: ['./coworkers.component.css']
})
export class CoworkersComponent implements OnInit {
  users: User[];
  user: User = JSON.parse(localStorage.getItem('user'));
  positionList = [{value: '', display: 'All'}, {value: 'null', display: 'Without'}];
  userParams: any = {};
  pagination: Pagination;

  constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.users = data['users'].result;
      this.pagination = data['users'].pagination;
    });

    this.userParams.position = ''; /*all */
    this.userParams.orderBy = 'lastActive';
    this.getPositions();
  }

  getPositions() {
    this.userService.getPositions().subscribe( (res: string[]) => {
      res.forEach(element => {
      const position = {value: element, display: element};
      if ((element !== null) && (!this.positionList.includes(position))) {
        this.positionList.push(position);
      }});
    }, error => {
      this.alertify.error(error);
    });
  }

  resetFilters() {
    this.userParams.position = '';
    this.loadUsers();
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers(this.pagination.currentPage, this.pagination.itemsPerPage, this.userParams)
      .subscribe((res: PaginatedResult<User[]>) => {
      this.users = res.result;
      this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }
 }
