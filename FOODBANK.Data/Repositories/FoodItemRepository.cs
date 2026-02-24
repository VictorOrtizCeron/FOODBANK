using FOODBANK.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FOODBANK.Models;

namespace FOODBANK.Data.Repositories;

public interface IFoodItemRepository
{
    Task<bool> UpsertAsync(FoodItem entity, bool isUpdating);
    Task<bool> CreateAsync(FoodItem entity);
    Task<bool> DeleteAsync(FoodItem entity);
    Task<IEnumerable<FoodItem>> ReadAsync();
    Task<FoodItem?> FindAsync(int id);
    Task<bool> UpdateAsync(FoodItem entity);
    Task<bool> UpdateManyAsync(IEnumerable<FoodItem> entities);
    Task<bool> ExistsAsync(FoodItem entity);
}
