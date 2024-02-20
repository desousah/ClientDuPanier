using System.Collections.Generic;
using System.Threading.Tasks;
using TDEvalutaion.Models.EntityFramework;

namespace ClientDuPanier.Services
{
    public interface IService
    {
        public Task<List<Fruit>> GetFruitAsync(string nomControleur);
        //public Task<bool> PostSerieAsync(string nomControleur, Serie serie);


    }
}