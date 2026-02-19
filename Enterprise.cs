namespace FireInspection
{
    public class Enterprise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int FloorCount { get; set; }
        public int EmployeeCount { get; set; }
        public string EnterpriseType { get; set; }

        public Enterprise(int id, string name, string address, int floors, int employees, string type)
        {
            Id = id;
            Name = name;
            Address = address;
            FloorCount = floors < 1 ? 1 : floors;
            EmployeeCount = employees < 0 ? 0 : employees;
            EnterpriseType = type;
        }

        // ADDED IN TODO 3: информативное строковое представление
        public override string ToString()
        {
            return $"{Name} ({EnterpriseType}) - {Address}, {FloorCount} этажей, {EmployeeCount} сотрудников";
        }

        public string GetRiskCategory()
        {
            if (EmployeeCount > 100 || FloorCount > 5) return "Высокая";
            if (EmployeeCount > 50 || FloorCount > 3) return "Средняя";
            return "Низкая";
        }
    }
}   