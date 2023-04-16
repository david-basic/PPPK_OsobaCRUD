using PPPK_OsobaCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_OsobaCRUD.Dao
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Osoba>> GetPeopleAsync(string queryString);
        Task<Osoba> GetPersonAsync(string id);
        Task AddPersonAsync(Osoba person);
        Task UpdatePersonAsync(Osoba person);
        Task DeletePersonAsync(Osoba person);
    }
}
