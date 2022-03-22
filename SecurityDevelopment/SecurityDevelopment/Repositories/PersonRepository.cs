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

        public JsonResult Create(object obj)
        {
            throw new NotImplementedException();
        }

        public JsonResult DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetAll()
        {
            string query = @"SELECT schemaname as ""schemaname"", tablename as ""tablename"" FROM pg_catalog.pg_tables";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");
            NpgsqlDataReader npgsqlDataReader;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection))
                {
                    npgsqlDataReader = npgsqlCommand.ExecuteReader();
                    table.Load(npgsqlDataReader);

                    npgsqlDataReader.Close();
                    npgsqlConnection.Close();
                }
            }
            
            return new JsonResult(table);
        }

        public JsonResult GetByAnyStringValue(string AnyStringValue)
        {
            throw new NotImplementedException();
        }

        public JsonResult GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public JsonResult Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
