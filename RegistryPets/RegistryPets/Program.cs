using RegistryPets.RegisrtyPets.Services;
using RegistryPets.RegisrtyPets.Services.Implementation;
using System.Data.SQLite;

namespace RegistryPets
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //ConfigureSqliteConnection();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
            builder.Services.AddScoped<IAnimalSkillRepository, AnimalSkillRepository>();
            builder.Services.AddScoped<IAnimalTypeRepository, AnimalTypeRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void ConfigureSqliteConnection()
        {
            string connectionString = "Data Source = RegistryPet.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
        }

        private static void PrepareSchema(SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand(connection);

            command.CommandText =
                @"CREATE TABLE IF NOT EXISTS AnimalType(
                Id_animal_type INTEGER PRIMARY KEY,
                Type TEXT)";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE IF NOT EXISTS Skill(
                Id_skill INTEGER PRIMARY KEY,
                Id_animal_type INTEGER,
                Skill TEXT)";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE IF NOT EXISTS Animal(
                Id_animal INTEGER PRIMARY KEY,
                Id_animal_type INTEGER,
                Name VARCHAR(45),
                Birthday DATETIME,
                Description TEXT)";
            command.ExecuteNonQuery();

            command.CommandText =
                @"CREATE TABLE IF NOT EXISTS Animal_skill(
                id_animal_skill INTEGER PRIMARY KEY,
                id_animal INTEGER,
                id_skill INTEGER,
                FOREIGN KEY (id_animal) REFERENCES animal (id_animal) ON DELETE CASCADE,
                FOREIGN KEY (id_skill) REFERENCES skill (id_skill) ON DELETE CASCADE)";
            command.ExecuteNonQuery();
        }
    }
}