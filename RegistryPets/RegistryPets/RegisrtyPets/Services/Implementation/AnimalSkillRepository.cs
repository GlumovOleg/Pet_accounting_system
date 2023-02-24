using RegistryPets.RegisrtyPets.Models;
using System.Data.SQLite;

namespace RegistryPets.RegisrtyPets.Services.Implementation
{
    public class AnimalSkillRepository : IAnimalSkillRepository
    {
        private const string connectionString = "Data Source = RegistryPet.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        public int Create(AnimalSkill item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Animal_skill(Id_animal, id_skill) VALUES(@Id_animal, @id_skill)";
            command.Parameters.AddWithValue(@"Id_animal", item.AnimalId);
            command.Parameters.AddWithValue(@"id_skill", item.SkillId);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;

        }
        public int Update(AnimalSkill item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE Animal_skill SET id_skill = @id_skill WHERE id_animal_skill = @id_animal_skill";
            command.Parameters.AddWithValue(@"id_animal_skill", item.AnimalSkillId);
            command.Parameters.AddWithValue(@"Id_animal", item.AnimalId);
            command.Parameters.AddWithValue(@"id_skill", item.SkillId);
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
            command.CommandText = "DELETE FROME Animal_skill WHERE id_animal_skill = @id_animal_skill";
            command.Parameters.AddWithValue(@"id_animal_skill", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public IList<AnimalSkill> GetAll()
        {
            List<AnimalSkill> list = new List<AnimalSkill>();

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Animal_skill";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AnimalSkill animalSkill = new AnimalSkill();
                animalSkill.AnimalSkillId = reader.GetInt32(0);
                animalSkill.AnimalId = reader.GetInt32(1);
                animalSkill.SkillId = reader.GetInt32(2);

                list.Add(animalSkill);
            }

            connection.Close();
            return list;
        }

        public AnimalSkill GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM Animal_skill WHERE id_animal_skill = @id_animal_skill";
            command.Parameters.AddWithValue(@"id_animal_skill", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                AnimalSkill animalSkill = new AnimalSkill();
                animalSkill.AnimalSkillId = reader.GetInt32(0);
                animalSkill.AnimalId = reader.GetInt32(1);
                animalSkill.SkillId = reader.GetInt32(2);

                connection.Close();
                return animalSkill;
            }
            else
            {
                connection.Clone();
                return null;
            }
        }

    }
}
