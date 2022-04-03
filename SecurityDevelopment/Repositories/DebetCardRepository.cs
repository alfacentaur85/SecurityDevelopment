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
    public class DebetCardRepository : IRepositoryDebetCard
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger<DebetCardRepository> _logger;

        public DebetCardRepository(IConfiguration configuration, ILogger<DebetCardRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public JsonResult Create(IReadOnlyList<DebetCard> DebetCards)
        {
            string query = @"INSERT INTO ""DebetCards""(""Id"", ""Number"", ""CVC"", ""Balance"", ""DateFrom"", ""DateTo"", ""OwnerId"") VALUES(@Id, @Number, @CVC, @Balance, @DateFrom, @DateTo, @OwnerId)";

            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection))
                {
                    foreach (var p in DebetCards)
                    {
                        npgsqlCommand.Parameters.Clear();
                        npgsqlCommand.Parameters.AddWithValue("Id", p.Id);
                        npgsqlCommand.Parameters.AddWithValue("Number", p.Number);
                        npgsqlCommand.Parameters.AddWithValue("CVC", p.CVC);
                        npgsqlCommand.Parameters.AddWithValue("Balance", p.Balance);
                        npgsqlCommand.Parameters.AddWithValue("DateFrom", p.DateFrom);
                        npgsqlCommand.Parameters.AddWithValue("DateTo", p.DateTo);
                        npgsqlCommand.Parameters.AddWithValue("OwnerId", p.Owner.Id);

                        npgsqlCommand.Prepare();
                        npgsqlCommand.ExecuteNonQuery();
                    }
                }
                npgsqlConnection.Close();
            }

            return new JsonResult("Entries have been added");
        }

        public JsonResult Update(IReadOnlyList<DebetCard> DebetCards)
        {
            string query = @"UPDATE ""DebetCards"" SET ""Number""=@Number, ""CVC""=@CVC, ""Balance""=@Balance,  ""DateFrom""=@DateFrom, ""DateTo""=@DateTo, ""OwnerId""=@OwnerId ""Id""=@Id";

            string sqlDataSource = _configuration.GetConnectionString("SecurityDevelopmentCon");

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(sqlDataSource))
            {
                npgsqlConnection.Open();
                using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(query, npgsqlConnection))
                {
                    foreach (var p in DebetCards)
                    {
                        npgsqlCommand.Parameters.Clear();
                        npgsqlCommand.Parameters.AddWithValue("Id", p.Id);
                        npgsqlCommand.Parameters.AddWithValue("Number", p.Number);
                        npgsqlCommand.Parameters.AddWithValue("CVC", p.CVC);
                        npgsqlCommand.Parameters.AddWithValue("Balance", p.Balance);
                        npgsqlCommand.Parameters.AddWithValue("DateFrom", p.DateFrom);
                        npgsqlCommand.Parameters.AddWithValue("DateTo", p.DateTo);
                        npgsqlCommand.Parameters.AddWithValue("OwnerId", p.Owner.Id);

                        npgsqlCommand.Prepare();
                        npgsqlCommand.ExecuteNonQuery();
                    }
                }
                npgsqlConnection.Close();
            }

            return new JsonResult("Entries have been updated");
        }


        public JsonResult DeleteById(int Id)
        {
            string query = @"DELETE FROM ""DebetCards"" WHERE ""Id""=@Id";

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
            string query = @"SELECT * FROM ""DebetCards""";

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

            string query = @"SELECT * FROM ""DebetCards"" WHERE ""Number"" LIKE @param ";

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

            string query = @"SELECT * FROM ""DebetCards"" WHERE ""Id"" = @Id";

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
