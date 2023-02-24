using RegistryPets.RegisrtyPets.Models;
using System.Data.SQLite;

namespace RegistryPets.RegisrtyPets.Services.Implementation
{
    public class SkillRepository : ISkillRepository
    {

        private const string connectionString = "Data Source = RegistryPet.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        public int Create(Skill item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO Skill(AnimalTypeId , skill) VALUES(@AnimalTypeId, @skill)";
            command.Parameters.AddWithValue(@"AnimalTypeId", item.AnimalTypeId);
            command.Parameters.AddWithValue(@"skill", item.CharacterSkill);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;

        }
        public int Update(Skill item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE Skill SET skill = @skill WHERE SkillId = @SkillId";
            command.Parameters.AddWithValue(@"SkillId", item.SkillId);
            command.Parameters.AddWithValue(@"SkillId", item.CharacterSkill);
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
            command.CommandText = "DELETE FROME skill WHERE SkillId = @SkillId";
            command.Parameters.AddWithValue(@"SkillId", id);
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public IList<Skill> GetAll()
        {
            List<Skill> list = new List<Skill>();

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM skill";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Skill skill = new Skill();
                skill.AnimalTypeId = reader.GetInt32(0);
                skill.CharacterSkill = reader.GetString(1);

                list.Add(skill);
            }

            connection.Close();
            return list;
        }

        public Skill GetById(int id)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM skill WHERE SkillId = @SkillId";
            command.Parameters.AddWithValue(@"SkillId", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Skill skill = new Skill();
                skill.AnimalTypeId = reader.GetInt32(0);
                skill.CharacterSkill = reader.GetString(1);

                connection.Close();
                return skill;
            }
            else
            {
                connection.Clone();
                return null;
            }
        }

    }
}
