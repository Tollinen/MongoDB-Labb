namespace TEST_MongoDB
{
    internal interface DAO
    {
        void Create();
        void Read(int id);
        List<string> ReadAll();
        void Update(int id);
        void Delete(int id);
    }
}
