using RegistryPets.RegisrtyPets.Models;
using System.Data.SQLite;

namespace RegistryPets.RegisrtyPets.Services.Implementation
{
    public class AnimalTypeRepository : IAnimalTypeRepository
    {
        private const string connectionString = "Data Source = RegistryPet.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        public int Create(AnimalType item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Animal_type(type) VALUES(@type)";
            command.Parameters.AddWithValue(@"type", item.Type);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;

        }
        public int Update(AnimalType item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE Animal_type SET type = @type WHERE Id_animal_type = @Id_animal_type";
            command.Parameters.AddWithValue(@"Id_animal_type", item.AnimalTypeId);
            command.Parameters.AddWithValue(@"type", item.Type);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public int Delete(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "DELETE FROME Animal_type WHERE Id_animal_type = @Id_animal_type";
            command.Parameters.AddWithValue(@"Id_animal_type", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public IList<AnimalType> GetAll()
        {
            List<AnimalType> list = new List<AnimalType>();

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Animal_type";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AnimalType animal_type = new AnimalType();
                animal_type.AnimalTypeId = reader.GetInt32(0);
                animal_type.Type = reader.GetString(1);

                list.Add(animal_type);
            }

            connection.Close();
            return list;
        }

        public AnimalType GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Animal_type WHERE Id_animal_type = @Id_animal_type";
            command.Parameters.AddWithValue(@"Id_animal_type", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                AnimalType animal_type = new AnimalType();
                animal_type.AnimalTypeId = reader.GetInt32(0);
                animal_type.Type = reader.GetString(1);

                connection.Close();
                return animal_type;
            }
            else
            {
                connection.Clone();
                return null;
            }
        }

        AnimalType IRepository<AnimalType, int>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
