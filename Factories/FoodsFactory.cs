using BalancaDaVidaAPI.Models;
using BalancaDaVidaAPI.Properties;
using Newtonsoft.Json;
using System.Linq;

namespace BalancaDaVidaAPI.Factories
{
    public static class FoodsFactory
    {
        public static List<Food> CreateFoodList()
        {
            List<Food> foodList = ReadFromJsonFile();
            return foodList.ToList();
        }

        public static List<Food> CreateFoodList(int numberOfFoods)
        {
            List<Food> foodList = ReadFromJsonFile();

            return foodList.Take(numberOfFoods).ToList();
        }

        public static Food GetById(int ID)
        {
            List<Food> foodList = ReadFromJsonFile();

            return foodList.FirstOrDefault(x => x.ID == ID);
        }

        public static List<Food> GetByName(string name)
        {
            List<Food> foodList = ReadFromJsonFile();

            return foodList.Where(x => x.nome.ToLower().Contains(name.ToLower())).ToList();
        }

        public static List<Food> ReadFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<Food>>(Resources.JsonForApI);
        }
    }
}
