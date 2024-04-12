namespace CsharpKT.UnitTestsModels
{
    public enum CarColor
    {
        Red,
        Green,
        Blue
    }

    public class Car
    {
        private Car()
        {
        }

        public string EngineType { get; private set; }
        public bool IsRunning { get; private set; }
        public List<string> Passengers { get; private set; }
        public CarColor Color { get; private set; }
        public DateTime ProductionDate { get; private set; }

        public static Car CreateNewCar(
            CarColor color,
            string EngineType,
            DateTime productionTime)
        {
            return new Car
            {
                EngineType = EngineType,
                Color = color,
                Passengers = [],
                ProductionDate = productionTime,
            };
        }

        public static Car CreateNewCar(
            CarColor color,
            string EngineType,
            IDateTimeProvider productionTime)
        {
            return new Car
            {
                EngineType = EngineType,
                Color = color,
                Passengers = [],
                ProductionDate = productionTime.UtcNow,
            };
        }

        public void StartEngine()
        {
            IsRunning = true;
        }

        public void AddPassenger(string passenger)
        {
            _ = string.IsNullOrWhiteSpace(passenger) ? throw new ArgumentNullException(passenger) : passenger;
            Passengers.Add(passenger);
        }

        public void RemovePassenger(string passenger)
        {
            Passengers.Remove(passenger);
        }
    }
}
