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
        var db = new NpgsqlConnection(ConnectionString);
        db.Open();
        var sql = """
                  UPDATE table_persons 
                  SET last_name = @last_name, 
                      first_name = @first_name, 
                      is_active = @is_active 
                  WHERE id = @id
                  """;
        var command = new NpgsqlCommand(sql, db);
        command.Parameters.AddWithValue("id", person.Id);
        command.Parameters.AddWithValue("last_name", person.LastName);
        command.Parameters.AddWithValue("first_name", person.FirstName);
        command.Parameters.AddWithValue("is_active", person.IsActive);
        var result = command.ExecuteNonQuery();
        db.Close();
        
        return result > 0;
    }

    public IEnumerable<Person> GetAll()
    {
        var db = new NpgsqlConnection(ConnectionString);
        db.Open();
        var sql = "SELECT * FROM table_persons WHERE is_active = TRUE";
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