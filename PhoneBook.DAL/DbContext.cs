using System.Data;
using Npgsql;
using PhoneBook.Model;

namespace PhoneBook.DAL;

public class DbContext : ICrud
{
    private const string ConnectionString = 
        "Server=127.0.0.1;Port=5432;Database=phonebook_db;User Id=postgres;Password=1234;SearchPath=test;";
    
    public bool Insert(Person person)
    {
        throw new NotImplementedException();
    }

    public bool Update(Person person)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Person person)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person> GetAll()
    {
        var db = new NpgsqlConnection(ConnectionString);
        db.Open();
        var sql = "SELECT * FROM table_persons";
        var command = new NpgsqlCommand(sql, db);
        var reader = command.ExecuteReader();
        var persons = new List<Person>();
        while (reader.Read())
        {
            persons.Add(new Person()
            {
                Id = reader.GetInt32("id"),
                LastName = reader.GetString("last_name"),
                FirstName = reader.GetString("first_name"),
                IsActive = reader.GetBoolean("is_active")
            });
        }
        db.Close();
        return persons;
    }
}