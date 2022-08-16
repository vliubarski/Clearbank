namespace ClearBank.DeveloperTest.Data
{
    public interface IStoreProvider
    {
        IDataStore GetDataStoreByType(string type);
    }
}