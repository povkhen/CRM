import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-coworker-card',
  templateUrl: './coworker-card.component.html',
  styleUrls: ['./coworker-card.component.css']
})
export class CoworkerCardComponent implements OnInit {
  @Input() user: User;
  constructor() { }

  ngOnInit() {
  }

}
