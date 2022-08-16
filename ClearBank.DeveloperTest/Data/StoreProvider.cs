namespace ClearBank.DeveloperTest.Data
{
    public class StoreProvider : IStoreProvider
    {
        public IDataStore GetDataStoreByType(string type)
        {
            if (type == "Backup")
            {
                return new BackupAccountDataStore();
            }
            else
            {
                return new AccountDataStore();
            }
        }
    }
}
