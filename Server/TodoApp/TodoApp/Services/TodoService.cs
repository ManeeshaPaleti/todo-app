using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<TodoItemsModel> _todoItems = new List<TodoItemsModel>();
        private int _Id = 1;

        public List<TodoItemsModel> GetAllItems()
        {
            return _todoItems;
        }

        public TodoItemsModel AddNewItem(string TodoTask)
        {
            var newItem = new TodoItemsModel();
            {
                newItem.Id = _Id++;
                newItem.TodoTask = TodoTask;
                _todoItems.Add(newItem);
            }
            return newItem;
        }

        public bool DeleteItem(int id)
        {
            var TodoItem = _todoItems.FirstOrDefault(x=>x.Id==id);
            if(TodoItem!=null)
            {
                _todoItems.Remove(TodoItem);
                return true;
            }
            return false;         
        }
    }
}
