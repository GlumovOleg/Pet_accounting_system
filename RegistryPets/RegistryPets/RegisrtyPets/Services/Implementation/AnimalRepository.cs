using RegistryPets.RegisrtyPets.Models;
using System.Data.SQLite;

namespace RegistryPets.RegisrtyPets.Services.Implementation
{
    public class AnimalRepository: IAnimalRepository

    {

        private const string connectionString = "Data Source = RegistryPet.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        public int Create(Animal item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Animal(animalTypeId, name, birthday, description) VALUES(@animalTypeId, @name, @birthday, @description)";
            command.Parameters.AddWithValue(@"animalTypeId", item.AnimalTypeId);
            command.Parameters.AddWithValue(@"name", item.Name);
            command.Parameters.AddWithValue(@"birthday", item.Birthday.Ticks);
            command.Parameters.AddWithValue(@"description", item.Description);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;

        }
        public int Update(Animal item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE Animal SET  = @name, birthday = @birthday, description = @description WHERE animalId = @animalId";
            command.Parameters.AddWithValue(@"animalId", item.AnimalId);
            command.Parameters.AddWithValue(@"name", item.Name);
            command.Parameters.AddWithValue(@"birthday", item.Birthday.Ticks);
            command.Parameters.AddWithValue(@"description", item.Description);
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
            command.CommandText = "DELETE FROME animal WHERE animalId = @animalId";
            command.Parameters.AddWithValue(@"animalId", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public IList<Animal> GetAll()
        {
            List<Animal> list = new List<Animal>();

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Animal";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Animal animal = new Animal();
                animal.AnimalId = reader.GetInt32(0);
                animal.AnimalTypeId = reader.GetInt32(1);
                animal.Name = reader.GetString(2);
                animal.Birthday = new DateTime(reader.GetInt64(3));
                animal.Description = reader.GetString(4);

                list.Add(animal);
            }

            connection.Close();
            return list;
        }

        public Animal GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Animal WHERE AnimalId = @animalId";
            command.Parameters.AddWithValue(@"animalId", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Animal animal = new Animal();
                animal.AnimalId = reader.GetInt32(0);
                animal.AnimalTypeId = reader.GetInt32(1);
                animal.Name = reader.GetString(2);
                animal.Birthday = new DateTime(reader.GetInt64(3));
                animal.Description = reader.GetString(4);

                connection.Close();
                return animal;
            }
            else
            {
                connection.Clone();
                return null;
            }
        }

    }
}
