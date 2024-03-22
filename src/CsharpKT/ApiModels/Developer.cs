namespace CsharpKT.ApiModels
{
    public class Developer
    {
        private Developer()
        {
        }

        public string Id { get; private set; }
        public string Name { get; private set; }

        public static Developer Create(
            string id,
            string name)
        {
            return new Developer
            {
                Id = id,
                Name = name
            };
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }
    }
}
