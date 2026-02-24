using FOODBANK.Business;
using FOODBANK.Data.Repositories;
using FOODBANK.Models;


namespace FOODBANK.Business;

public interface IFoodItemBusiness
{
    Task<bool> CreateFoodItemAsync(FoodItem item);
    Task<IEnumerable<FoodItem>> GetFoodItemsAsync();
}

public class FoodItemBusiness(IFoodItemRepository foodItemRepository) : IFoodItemBusiness
{
    public async Task<bool> CreateFoodItemAsync(FoodItem item)
    {

        return await foodItemRepository.CreateAsync(item);
    }

    public async Task<IEnumerable<FoodItem>> GetFoodItemsAsync()
    {
        return await foodItemRepository.ReadAsync();
    }
}