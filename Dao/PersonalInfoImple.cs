using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Reflection;
using Task_Profile.Models;

namespace Task_Profile.Dao
{
    public class PersonalInfoImple : IPersonalInfo
    {
        NpgsqlConnection _connection;
        public PersonalInfoImple(NpgsqlConnection connection)
        {
            this._connection = connection;
        }

        
        public async Task<List<Persons>> GetPersonInfo()
        {
            List<Persons?> PersonInfoList = new List<Persons?>();
           
            string errorMessage = string.Empty;
            string query = @"select * from Personalinfo.persons";
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                    command.CommandType = CommandType.Text;

                    NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                    if ((reader.HasRows))
                    {
                        while (reader.Read())
                        {
                            Persons person = new Persons();
                            person.Id = reader.GetInt32(0);
                            person.Name = reader.GetString(1);
                            person.DateOfBirth = reader.GetDateTime(2);
                            person.ResidentialAddress = reader.GetString(3);
                            person.PermanentAddress = reader.GetString(4);
                            person.PhoneNumber = reader.GetString(5);
                            person.EmailAddress = reader.GetString(6);
                            person.MaritalStatus = reader.GetString(7);
                            person.Gender = reader.GetString(8);
                            person.Occupation = reader.GetString(9);
                            person.AadharCardNumber = reader.GetString(10);
                            person.PanNumber = reader.GetString(11);
                            PersonInfoList.Add(person);
                           
                        }

                    }
                    reader?.Close();

                }
            }
            catch (NpgsqlException e)
            {
                errorMessage = e.Message;
                Console.WriteLine("----Exception -----: message");
            }
            return PersonInfoList;

        }

        public async Task<int> InsertPerson(Persons p)
        {
            int rowsInserted = 0;
            string message;
            string insertQuery = $@"insert into Personalinfo.persons(name, dateofbirth, residentialaddress, permanentaddress, phonenumber, emailaddress, maritalstatus, gender,occupation, aadharcardnumber, pannumber) values('{p.Name}','{p.DateOfBirth}','{p.ResidentialAddress}','{p.PermanentAddress}','{p.PhoneNumber}','{p.EmailAddress}','{p.MaritalStatus}','{p.Gender}','{p.Occupation}','{p.AadharCardNumber}','{p.PanNumber}')";
            Console.WriteLine("Query" + insertQuery);
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, _connection);
                    insertCommand.CommandType = CommandType.Text;
                    rowsInserted = await insertCommand.ExecuteNonQueryAsync();
                }

            }
            catch (NpgsqlException e)
            {
                message = e.Message;
                Console.WriteLine("---------Exception----------" + message);
            }
            return rowsInserted;
        }



        public async Task<int> UpdatePersonAddress(int id, string ResidentialAddress)
        {
            int rowsAffected = 0;
            string query = $"update Personalinfo.persons set residentialaddress = @residentialaddress where id =@pid;";
            try
            {
                using (_connection)
                {
                    NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                    await _connection.OpenAsync();
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("residentialaddress", ResidentialAddress);
                    command.Parameters.AddWithValue("pid", id);

                    rowsAffected = await command.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return (rowsAffected);
        }

        public async Task<int> DeletePersonById(int id)
        {
            int rowAffected = 0;
            string insertQuery = $"delete from Personalinfo.persons where id =@pid"; ;
            Console.WriteLine("query" + insertQuery);
            
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand deleteCommand = new NpgsqlCommand(insertQuery, _connection);
                    deleteCommand.CommandType = CommandType.Text;
                    //updateCommand.Parameters.AddWithValue("@pid", id);
                    deleteCommand.Parameters.Add("@pid", NpgsqlDbType.Integer).Value = id;
                    rowAffected = await deleteCommand.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }


            return rowAffected;

        }

        public async Task<Persons> GetPersonById(int id)
        {
            string errorMessage = string.Empty;
            Persons person = null;
            string query = @"select * from Personalinfo.persons where id=@pid";
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@pid", id);
                    NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                    if ((reader.HasRows))
                    {
                        while (reader.Read())
                        {
                            person = new Persons();
                            person.Id = reader.GetInt32(0);
                            person.Name = reader.GetString(1);
                            person.DateOfBirth = reader.GetDateTime(2);
                            person.ResidentialAddress = reader.GetString(3);
                            person.PermanentAddress = reader.GetString(4);
                            person.PhoneNumber = reader.GetString(5);
                            person.EmailAddress = reader.GetString(6);
                            person.MaritalStatus = reader.GetString(7);
                            person.Gender = reader.GetString(8);
                            person.Occupation = reader.GetString(9);
                            person.AadharCardNumber = reader.GetString(10);
                            person.PanNumber = reader.GetString(11);
                            
                        }

                    }
                    reader?.Close();

                }
            }
            catch (NpgsqlException e)
            {
                errorMessage = e.Message;
                Console.WriteLine("----Exception -----: message");
            }
            return person;
        }
        

    }
}
