using Computer_Peripheral___Stock_Management.Model;

namespace Computer_Peripheral___Stock_Management.Repository
{
    public interface IPeripheralRepository
    {
        Task AddPeripheral(Peripheral peripheral);
        Task RemovePeripheral(int id);
        Task UpdatePeripheral (Peripheral peripheral);

        Task<Peripheral> GetPeripheral (int id);
        Task<IEnumerable<Peripheral>> GetAllPeripherals();
    }
}