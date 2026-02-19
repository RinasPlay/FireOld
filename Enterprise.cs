// TODO:
// 1. Добавить свойство для типа предприятия (торговля, производство, офис)
// 2. Реализовать проверку корректности данных (адрес, этажность)
// 3. Реализовать информативное строковое представление предприятия

namespace FireInspection
{
    public class Enterprise
    {
        public int Id { get; set; }                    // Идентификатор
        public string Name { get; set; }               // Название предприятия
        public string Address { get; set; }            // Адрес
        public int FloorCount { get; set; }            // Количество этажей
        public int EmployeeCount { get; set; }         // Количество сотрудников
        
        // TODO 1: Добавить свойство EnterpriseType (тип предприятия)
        
        public Enterprise(int id, string name, string address, int floors, int employees, string type)
        {
            Id = id;
            Name = name;
            Address = address;
            
            // TODO 2: Проверить что количество этажей не отрицательное
            // Если floors < 1, установить 1
            
            // TODO 2: Проверить что количество сотрудников не отрицательное
            // Если employees < 0, установить 0
            
            // TODO 1: Сохранить тип предприятия
        }
        
        public override string ToString()
        {
            // TODO 3: Вернуть строку в формате "ООО 'Ромашка' (торговля) - ул. Ленина, 10, 3 этажа, 50 сотрудников"
            return Name;
        }
        
        // Определить категорию риска
        public string GetRiskCategory()
        {
            // Готовый метод: определить категорию по количеству сотрудников и этажей
            if (EmployeeCount > 100 || FloorCount > 5) return "Высокая";
            if (EmployeeCount > 50 || FloorCount > 3) return "Средняя";
            return "Низкая";
        }
    }
}