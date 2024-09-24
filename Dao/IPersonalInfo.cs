using System;
using Task_Profile.Models;

namespace Task_Profile.Dao
{
    public interface IPersonalInfo
    {
        
        Task<List<Persons>> GetPersonInfo();

        Task<int> InsertPerson(Persons p);

        Task<int> UpdatePersonAddress(int id, string ResidentialAddress);

        Task<Persons> GetPersonById(int id);

        Task<int> DeletePersonById(int id);
    }
}
