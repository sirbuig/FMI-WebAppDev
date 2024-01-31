import { Component } from '@angular/core';
import {CommonModule} from "@angular/common";
import {MatCardModule} from "@angular/material/card";
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule} from '@angular/material/list';

@Component({
  selector: 'app-demo',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule, MatDividerModule, MatButtonModule, MatListModule],
  templateUrl: './demo.component.html',
  styleUrl: './demo.component.scss'
})
export class DemoComponent {
  public title: string = 'Demo component';
  public counter: number = 0;
  public users = [
    {id: 1, name: 'Name 1', background: 'Lightgreen'},
    {id: 2, name: 'Name 2', background: 'Blue'},
    {id: 3, name: 'Name 3', background: 'Purple'},
    {id: 4, name: 'Name 4', background: 'Orange'}
  ];
  public selectedUser: any = {};
  addToCounter() {
    this.counter++;
  }

  selectUser(user: any) {
    this.selectedUser = user;
  }

  addUser() {
    let length = this.users.length + 1;
    this.users.push({id: length, name: 'Name' + length, background: 'gray'});
  }

  deleteUser() {
    this.users.pop();
  }
}
