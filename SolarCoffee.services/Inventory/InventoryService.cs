using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SolarCoffee.data;
using System.Linq;

namespace SolarCoffee.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly SolarDbContext _db;
        public InventoryService(SolarDbContext dbContext)
        {
            _db = dbContext;
        }
        public List<data.models.ProductInventory> GetCurrentInventories()
        {
            return _db.ProductInventories
                .Include(inventory => inventory.Product)
                .Where(inventory => inventory.Product.isArchived == false)
                .ToList();
        }
        public ServiceResponse<data.models.ProductInventory> UpdateUnitsAvailableAndReturnResponse(int id, int adjustment)
        {
            data.models.ProductInventory inventory = _db.ProductInventories
                .Include(inventory => inventory.Product)
                .First(inventory => inventory.Product.id == id);
            
            if ((inventory.quantityOnHand + adjustment) < 0)
            {
                return ServiceResponse<data.models.ProductInventory>.Failed(null, $"Out of Stock [product({id})]");
            }

            try {
                inventory.quantityOnHand += adjustment;
                CreateSnpashot(inventory);

                _db.SaveChanges();

                return ServiceResponse<data.models.ProductInventory>.Successed(inventory, $"Inventory of product({id}) was updated");
            } catch (Exception e) {
                return ServiceResponse<data.models.ProductInventory>.Failed(null, $"Failed to update inventory of product({id})" + e.StackTrace);
            }
        }
        public data.models.ProductInventory GetByProductId(int Id)
        {
            return _db.ProductInventories
                .Include(Inventory => Inventory.Product)
                .FirstOrDefault(Inventory => Inventory.Product.id == Id);
        }
        public List<data.models.ProductInventorySnapshot> GetSnapshotHistory()
        {
            DateTime earliest = DateTime.UtcNow - TimeSpan.FromHours(6);
            return _db.ProductInventorySnapshots
                .Include(snapshot => snapshot.Product)
                .Where(snapshot => snapshot.SnapshotTime > earliest && snapshot.Product.isArchived == false)
                .ToList();
        }
        private void CreateSnpashot(data.models.ProductInventory inventory)
        {
            data.models.ProductInventorySnapshot snapshot = new data.models.ProductInventorySnapshot {
                SnapshotTime = DateTime.UtcNow,
                Product = inventory.Product,
                quantityOnHand = inventory.quantityOnHand
            };

            _db.Add(snapshot);
        }
    }
}