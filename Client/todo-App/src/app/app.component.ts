import { Component, OnInit } from '@angular/core';
import { TodoService, TodoItem } from './todo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'todo-App';
  todos: TodoItem[] = [];
  newItem = '';

  constructor(private todoService: TodoService) {}

  ngOnInit() {
    this.loadTodos();
  }

  loadTodos() {
    this.todoService.getAllTodoItems().subscribe(data => {
      this.todos = data;
    });
  }

  addTodo() {
    if (!this.newItem.trim()) return;

    this.todoService.addTodoItem(this.newItem.trim()).subscribe({
      next: () => {
        this.newItem = '';
        this.loadTodos();
      }
    });
  }

  deleteTodo(id: number) {
    this.todoService.deleteTodoItem(id).subscribe(() => this.loadTodos());
  }
}
