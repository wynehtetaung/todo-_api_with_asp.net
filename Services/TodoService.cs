using MongoDB.Driver;
using TodoModel;

namespace TodoServiceApi
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todo;

        public TodoService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDbURL"));
            var database = client.GetDatabase("todo");
            _todo = database.GetCollection<Todo>("todo_item");
        }


        public List<Todo> Get() => _todo.Find(t => true).ToList();
        public Todo Get(string id) => _todo.Find(t => t.Id == id).FirstOrDefault();
        public Todo Create(Todo todo) {_todo.InsertOne(todo); return todo;}
        public void Update(string id)
        {
            var findTodo = _todo.Find(t => t.Id == id ).FirstOrDefault();
            if(findTodo != null)
            {
                findTodo.Check = !findTodo.Check;
            _todo.ReplaceOne(t => t.Id == id, findTodo);
            }
        }

        public void Update(string id, Todo todo)
        {
            _todo.ReplaceOne(t => t.Id == id,todo);
        }
            
        public void Delete(string id) => _todo.DeleteOne(t => t.Id == id);

        public void DeleteItem(string option)
        {
            if(option == "complete")
            {
                _todo.DeleteMany(t => t.Check == true);
            }else if(option == "all")
            {
                _todo.DeleteMany(Builders<Todo>.Filter.Empty);
            }
        }

    }
}