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
        // Mantener la misma lógica mínima de APW.Business: passthrough
        // Aquí podrías añadir validaciones específicas si lo deseas.
        return await foodItemRepository.CreateAsync(item);
    }

    public async Task<IEnumerable<FoodItem>> GetFoodItemsAsync()
    {
        return await foodItemRepository.ReadAsync();
    }
}