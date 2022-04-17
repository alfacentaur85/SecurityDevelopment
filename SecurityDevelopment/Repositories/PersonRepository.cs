using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecurityDevelopment.Abstractions;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SecurityDevelopment.Models;
using Newtonsoft.Json;

namespace SecurityDevelopment.Repositories
{
    public class PersonRepository : IRepositoryPerson
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<PersonRepository> _logger;

        public PersonRepository(IConfiguration configuration, ILogger<PersonRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public JsonResult Create(IReadOnlyList<Person> persons)
        {
            string query = @"INSERT INTO ""Persons""(""Id"", ""FirstName"", ""Surname"", ""Birthday"") VALUES(@Id, @FirstName, @Surname, @Birthday)";

            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection))
                {
                    foreach (var p in persons)
                    {
                        npgsqlCommand.Parameters.Clear();
                        npgsqlCommand.Parameters.AddWithValue("Id", p.Id);
                        npgsqlCommand.Parameters.AddWithValue("FirstName", p.FirstName);
                        npgsqlCommand.Parameters.AddWithValue("Surname", p.Surname);
                        npgsqlCommand.Parameters.AddWithValue("Birthday", p.Birthday);

                        npgsqlCommand.Prepare();
                        npgsqlCommand.ExecuteNonQuery();
                    }
                }
                npgsqlConnection.Close();
            }

            var logMsg = JsonConvert.SerializeObject(persons);
            _logger.LogInformation(logMsg);

            return new JsonResult("Entries have been added");
        }

        public JsonResult Update(IReadOnlyList<Person> persons)
        {
            string query = @"UPDATE ""Persons"" SET ""FirstName""=@FirstName, ""Surname""=@Surname, ""Birthday""=@Birthday WHERE ""Id""=@Id";

            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection))
                {
                    foreach (var p in persons)
                    {
                        npgsqlCommand.Parameters.Clear();
                        npgsqlCommand.Parameters.AddWithValue("Id", p.Id);
                        npgsqlCommand.Parameters.AddWithValue("FirstName", p.FirstName);
                        npgsqlCommand.Parameters.AddWithValue("Surname", p.Surname);
                        npgsqlCommand.Parameters.AddWithValue("Birthday", p.Birthday);

                        npgsqlCommand.Prepare();
                        npgsqlCommand.ExecuteNonQuery();
                    }
                }
                npgsqlConnection.Close();
            }

            var logMsg = JsonConvert.SerializeObject(persons);
            _logger.LogInformation(logMsg);

            return new JsonResult("Entries have been updated");
        }


        public JsonResult DeleteById(int Id)
        {
            string query = @"DELETE FROM ""Persons"" WHERE ""Id""=@Id";

            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection))
                {
                        npgsqlCommand.Parameters.Clear();
                        npgsqlCommand.Parameters.AddWithValue("Id", Id);
                        npgsqlCommand.Prepare();
                        npgsqlCommand.ExecuteNonQuery();
                }
                npgsqlConnection.Close();
            }
            return new JsonResult("Entrie have been deleted");
        }

        public JsonResult GetAll()
        {
            string query = @"SELECT * FROM ""Persons""";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");
            NpgsqlDataReader npgsqlDataReader;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection))
                {
                    npgsqlCommand.Prepare();
                    npgsqlDataReader = npgsqlCommand.ExecuteReader();
                    table.Load(npgsqlDataReader);

                    npgsqlDataReader.Close();
                    npgsqlConnection.Close();
                }
            }
            var JSONresult = JsonConvert.SerializeObject(table);
            return new JsonResult(JSONresult);
        }

        public JsonResult GetByAnyStringValue(string anyStringValue)
        {

            string query = @"SELECT * FROM ""Persons"" WHERE ""FirstName"" LIKE @param OR ""FirstName"" LIKE @param ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");
            NpgsqlDataReader npgsqlDataReader;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection))
                {
                    npgsqlCommand.Parameters.Clear();
                    npgsqlCommand.Parameters.AddWithValue("param", string.Concat("%", anyStringValue, "%"));
                    npgsqlCommand.Prepare();
                    npgsqlDataReader = npgsqlCommand.ExecuteReader();
                    table.Load(npgsqlDataReader);

                    npgsqlDataReader.Close();
                    npgsqlConnection.Close();
                }
            }
            var JSONresult = JsonConvert.SerializeObject(table);
            return new JsonResult(JSONresult);
        }

        public JsonResult GetById(int id)
        {

            string query = @"SELECT * FROM ""Persons"" WHERE ""Id"" = @Id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");
            NpgsqlDataReader npgsqlDataReader;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection))
                {
                    npgsqlCommand.Parameters.Clear();
                    npgsqlCommand.Parameters.AddWithValue("id", id);
                    npgsqlCommand.Prepare();
                    npgsqlDataReader = npgsqlCommand.ExecuteReader();
                    table.Load(npgsqlDataReader);

                    npgsqlDataReader.Close();
                    npgsqlConnection.Close();
                }
            }
            var JSONresult = JsonConvert.SerializeObject(table);
            return new JsonResult(JSONresult);
        }
    }
}
