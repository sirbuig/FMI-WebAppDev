import {Component, OnChanges, OnDestroy, OnInit, SimpleChanges} from '@angular/core';
import {CommonModule} from "@angular/common";
import {MatCardModule} from "@angular/material/card";
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule} from '@angular/material/list';
import {FormsModule} from "@angular/forms";
import {MatInput} from "@angular/material/input";

@Component({
  selector: 'app-demo',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule, MatDividerModule, MatButtonModule, MatListModule, FormsModule, MatInput],
  templateUrl: './demo.component.html',
  styleUrl: './demo.component.scss'
})
export class DemoComponent implements OnInit, OnDestroy, OnChanges {
  constructor() {
    let div = document.getElementById('titleContainer');
    console.log('Constructor html element value', div);
  }

  ngOnChanges(changes: SimpleChanges): void {
      throw new Error('Method not implemented.');
  }
  ngOnDestroy(): void {
      throw new Error('Method not implemented.');
  }
  ngOnInit(): void {
    let div = document.getElementById('titleContainer');
    console.log('ngOnInit html element value', div);
  }

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
