using Microsoft.AspNetCore.Mvc;
using SolarCoffee.Services.Inventory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using SolarCoffee.web.ViewModels;
using SolarCoffee.web.Serialization;
using System.Linq;

namespace SolarCoffee.Web.Controllers {
    [ApiController]
    public class InventoryController : ControllerBase 
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet("/api/inventory")]
        public ActionResult GetAllInventories()
        {
            _logger.LogInformation("Getting all inventory");
            List<data.models.ProductInventory> inventories = _inventoryService.GetCurrentInventories();
            List<ProductInventoryModel> inventoryModels = inventories.Select(inventory => new ProductInventoryModel {
                id = inventory.id,
                Product = ProductMapper.DataModelToViewModel(inventory.Product),
                quantityOnHand = inventory.quantityOnHand,
                idealQuantity = inventory.idealQuantity
            }).OrderBy(inventory => inventory.Product.name).ToList();

            return Ok(inventoryModels);
        }

        [HttpPatch("/api/inventory")]
        public ActionResult UpdateInventory([FromBody] ShipmentModel shipment)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            
            _logger.LogInformation($"Updating inventory for ProductId: {shipment.ProductId} - Adjustment: {shipment.Adjustment}");

            int id = shipment.ProductId;
            int adjustment = shipment.Adjustment;
            
            return Ok(_inventoryService.UpdateUnitsAvailableAndReturnResponse(id, adjustment));
        }
    }
}