import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface TodoItem {
  id: number;
  todoTask: string;
}

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private apiUrl = 'https://localhost:7225/api/Todo';

  constructor(private http: HttpClient) {}

  // Get all ToDo Items
  getAllTodoItems(): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(this.apiUrl);
  }

  // Add a new Item
  addTodoItem(todoTask: string): Observable<TodoItem> {
    const payload = { todoTask }; // Same as { todoTask: todoTask }
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<TodoItem>(this.apiUrl, payload, { headers });
  }

  // Delete an item
  deleteTodoItem(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
