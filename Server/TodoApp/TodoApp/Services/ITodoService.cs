using TodoApp.Models;

namespace TodoApp.Services
{
    public interface ITodoService
    {
        List<TodoItemsModel> GetAllItems();
        TodoItemsModel AddNewItem(string TodoTask);
        bool DeleteItem(int id);
    }
}
