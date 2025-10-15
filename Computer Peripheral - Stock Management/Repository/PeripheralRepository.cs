using Computer_Peripheral___Stock_Management.Data;
using Computer_Peripheral___Stock_Management.Model;
using Microsoft.EntityFrameworkCore;

namespace Computer_Peripheral___Stock_Management.Repository
{
    public class PeripheralRepository : IPeripheralRepository
    {
        private readonly AppDbContext _db;

        public PeripheralRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Peripheral>> GetAllPeripherals()
        {
            return await _db.peripherals.ToListAsync();
        }

        public async Task<Peripheral?> GetPeripheral(int id)
        {
            return await _db.peripherals.FindAsync(id);
        }

        public async Task AddPeripheral(Peripheral peripheral)
        {
            // Check for duplicate (by Name, etc. if needed)
            var exists = await _db.peripherals.AnyAsync(p => p.Id == peripheral.Id);
            if (exists)
                throw new InvalidOperationException("Peripheral already exists.");

            await _db.peripherals.AddAsync(peripheral);
            await _db.SaveChangesAsync();
        }

        public async Task UpdatePeripheral(Peripheral peripheral)
        {
            var exists = await _db.peripherals.FindAsync(peripheral.Id);
            if (exists == null)
                throw new KeyNotFoundException("Peripheral not found.");

            exists.Price = peripheral.Price;
            exists.Category = peripheral.Category;
            exists.Name = peripheral.Name;
            exists.QuantityInStock = peripheral.QuantityInStock;
            exists.AddedDate = DateTime.Now;

            await _db.SaveChangesAsync();
        }

        public async Task RemovePeripheral(int id)
        {
            var peripheral = await _db.peripherals.FindAsync(id);
            if (peripheral == null)
                throw new KeyNotFoundException("Peripheral not found.");

            _db.peripherals.Remove(peripheral);
            await _db.SaveChangesAsync();
        }
    }
}
