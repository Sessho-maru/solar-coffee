using System.Collections.Generic;

namespace SolarCoffee.Services.Inventory
{
    public interface IInventoryService
    {
        List<data.models.ProductInventory> GetCurrentInventories();
        ServiceResponse<data.models.ProductInventory> UpdateUnitsAvailableAndReturnResponse(int id, int adjustment);
        data.models.ProductInventory GetByProductId(int productId);
        List<data.models.ProductInventorySnapshot> GetSnapshotHistory();
    }
}