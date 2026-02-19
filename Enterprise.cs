namespace FireInspection
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int FloorCount { get; set; }
        public int EmployeeCount { get; set; }

        // ADDED IN TODO 1
        public string EnterpriseType { get; set; }

        public Enterprise(int id, string name, string address, int floors, int employees, string type)
        {
            Id = id;
            Name = name;
            Address = address;

            // TODO 2 будет добавлен позже (проверки)
            FloorCount = floors;
            EmployeeCount = employees;

            // ADDED IN TODO 1: сохраняем тип
            EnterpriseType = type;
        }

        // Заглушка для TODO 3
        public override string ToString() { return Name; }

        public string GetRiskCategory()
        {
            if (EmployeeCount > 100 || FloorCount > 5) return "Высокая";
            if (EmployeeCount > 50 || FloorCount > 3) return "Средняя";
            return "Низкая";
        }
    }
}