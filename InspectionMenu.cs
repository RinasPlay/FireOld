using System;
using System.Collections.Generic;
using System.Linq;

namespace FireInspection
{
    public class InspectionMenu
    {
        private List<Enterprise> enterprises = new List<Enterprise>();
        private List<Inspector> inspectors = new List<Inspector>();
        private List<Inspection> inspections = new List<Inspection>();

        private int nextEnterpriseId = 1;
        private int nextInspectionId = 1;

        public InspectionMenu()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            enterprises.Add(new Enterprise(1, "ООО 'Прогресс'", "ул. Промышленная, 15", 2, 80, "Производство"));
            enterprises.Add(new Enterprise(2, "ТЦ 'Европа'", "пр. Мира, 25", 4, 150, "Торговля"));
            enterprises.Add(new Enterprise(3, "Офис 'ТехноСофт'", "ул. Программистов, 10", 1, 30, "Офис"));

            inspectors.Add(new Inspector { Id = 1, Name = "Иванов А.С.", BadgeNumber = "ФП-001", Rank = "старший инспектор", Specialization = "промышленность" });
            inspectors.Add(new Inspector { Id = 2, Name = "Петрова М.И.", BadgeNumber = "ФП-002", Rank = "инспектор", Specialization = "торговля" });
        }

        public void ShowEnterprises()
        {
            Console.WriteLine("=== БАЗА ПРЕДПРИЯТИЙ ===");
            foreach (var e in enterprises)
            {
                Console.WriteLine($"ID: {e.Id}");
                // ADDED IN TODO 3: используем переопределённый ToString
                Console.WriteLine(e.ToString());
                Console.WriteLine($"Категория риска: {e.GetRiskCategory()}");
                Console.WriteLine(new string('-', 30));
            }
        }

        public void ConductInspection()
        {
            Console.WriteLine("=== ПРОВЕДЕНИЕ ПРОВЕРКИ ===");

            Enterprise selectedEnterprise = SelectEnterprise();
            if (selectedEnterprise == null) return;

            Inspector selectedInspector = SelectInspector();
            if (selectedInspector == null) return;

            Inspection inspection = new Inspection(nextInspectionId++, selectedEnterprise, selectedInspector);

            bool addingViolations = true;
            while (addingViolations)
            {
                Console.WriteLine("\nДобавление нарушения (или оставьте пустым для завершения):");
                Console.Write("Описание нарушения: ");
                string desc = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(desc))
                {
                    addingViolations = false;
                    continue;
                }

                Console.Write("Тип нарушения (Пожарные выходы/Огнетушители/Проводка/...): ");
                string type = Console.ReadLine();

                Console.Write("Серьезность (критическое/значительное/незначительное): ");
                string severity = Console.ReadLine();

                Console.Write("Срок устранения (дней): ");
                if (!int.TryParse(Console.ReadLine(), out int days))
                {
                    Console.WriteLine("Неверное число, нарушение не добавлено.");
                    continue;
                }

                inspection.AddViolation(desc, type, severity, days);
                Console.WriteLine("Нарушение добавлено.");
            }

            // ADDED IN TODO 3: определение результата проверки
            int violCount = inspection.GetViolations().Count;
            if (violCount == 0)
            {
                inspection.Result = "Соответствует";
            }
            else
            {
                decimal score = inspection.CalculateSafetyScore();
                if (score >= 80)
                    inspection.Result = "С нарушениями (незначительные)";
                else if (score >= 50)
                    inspection.Result = "С нарушениями (значительные)";
                else
                    inspection.Result = "Не соответствует";
            }

            Console.WriteLine($"\nРезультат проверки: {inspection.Result}");
            Console.WriteLine($"Оценка безопасности: {inspection.CalculateSafetyScore()}");

            inspections.Add(inspection);
            selectedInspector.AddInspection(inspection);

            Console.WriteLine("Проверка завершена и сохранена.");
        }

        // ADDED IN TODO 3: реализация MonitorViolations
        public void MonitorViolations()
        {
            Console.WriteLine("=== МОНИТОРИНГ НАРУШЕНИЙ ===");

            foreach (var enterprise in enterprises)
            {
                var entInspections = inspections.Where(i => i.Enterprise.Id == enterprise.Id).ToList();

                if (entInspections.Count == 0)
                {
                    Console.WriteLine($"Предприятие {enterprise.Name} - проверок не проводилось");
                    continue;
                }

                int totalViolations = 0;
                int overdueViolations = 0;
                decimal totalSafety = 0;

                foreach (var insp in entInspections)
                {
                    insp.GetViolationStats(out int total, out int critical, out int overdue);
                    totalViolations += total;
                    overdueViolations += overdue;
                    totalSafety += insp.CalculateSafetyScore();
                }

                decimal avgSafety = totalSafety / entInspections.Count;

                Console.WriteLine($"Предприятие: {enterprise.Name}");
                Console.WriteLine($"  Всего нарушений: {totalViolations}");
                Console.WriteLine($"  Просроченных: {overdueViolations}");
                Console.WriteLine($"  Средний балл безопасности: {avgSafety:F2}");
                Console.WriteLine();
            }

            Console.WriteLine("--- Статистика инспекторов ---");
            foreach (var inspector in inspectors)
            {
                inspector.GetWorkStats(out int totalInsp, out int totalViol, out decimal avgScore);
                Console.WriteLine($"Инспектор {inspector.Name}: проверок {totalInsp}, нарушений {totalViol}, активных нарушений {inspector.GetActiveViolationsCount()}, средний балл {avgScore:F2}");
            }
        }

        // ADDED IN TODO 3: реализация MarkViolationAsFixed
        public void MarkViolationAsFixed()
        {
            Console.WriteLine("=== УСТРАНЕНИЕ НАРУШЕНИЯ ===");

            Enterprise selectedEnterprise = SelectEnterprise();
            if (selectedEnterprise == null) return;

            var entInspections = inspections.Where(i => i.Enterprise.Id == selectedEnterprise.Id).ToList();
            if (entInspections.Count == 0)
            {
                Console.WriteLine("У этого предприятия нет проверок.");
                return;
            }

            List<Violation> activeViolations = new List<Violation>();
            foreach (var insp in entInspections)
            {
                activeViolations.AddRange(insp.GetViolations().Where(v => !v.IsFixed));
            }

            if (activeViolations.Count == 0)
            {
                Console.WriteLine("Нет активных нарушений.");
                return;
            }

            Console.WriteLine("Активные нарушения:");
            for (int i = 0; i < activeViolations.Count; i++)
            {
                var v = activeViolations[i];
                Console.WriteLine($"{i + 1}. {v.Description} (серьезность: {v.Severity}, срок: {v.FixDeadline:dd.MM.yyyy})");
            }

            Console.Write("Выберите номер нарушения для отметки как устраненного: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > activeViolations.Count)
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }

            activeViolations[choice - 1].MarkAsFixed();
            Console.WriteLine("Нарушение отмечено как устраненное.");
        }

        public void ShowMainMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== ПОЖАРНАЯ ИНСПЕКЦИЯ 'ОГНЕЩИТ' ===");
                Console.WriteLine("1. База предприятий");
                Console.WriteLine("2. Провести проверку");
                Console.WriteLine("3. Мониторинг нарушений");
                Console.WriteLine("4. Отметить устранение");
                Console.WriteLine("5. Статистика инспекции");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ShowEnterprises(); break;
                    case "2": ConductInspection(); break;
                    case "3": MonitorViolations(); break;
                    case "4": MarkViolationAsFixed(); break;
                    case "5": ShowInspectionStats(); break;
                    case "6": running = false; break;
                    default: Console.WriteLine("Неверный выбор!"); break;
                }

                if (running && choice != "6")
                {
                    Console.WriteLine("\nНажмите Enter...");
                    Console.ReadLine();
                }
            }
        }

        // ADDED IN TODO 3: доработан подсчёт активных нарушений
        private void ShowInspectionStats()
        {
            Console.WriteLine("=== СТАТИСТИКА ИНСПЕКЦИИ ===");
            Console.WriteLine($"Всего предприятий: {enterprises.Count}");
            Console.WriteLine($"Всего проверок: {inspections.Count}");

            int totalViolations = 0;
            int activeViolations = 0;

            foreach (var inspection in inspections)
            {
                totalViolations += inspection.GetViolations().Count;
                activeViolations += inspection.GetViolations().Count(v => !v.IsFixed);
            }

            Console.WriteLine($"Всего нарушений: {totalViolations}");
            Console.WriteLine($"Активных нарушений: {activeViolations}");
        }

        private Enterprise SelectEnterprise()
        {
            // ... без изменений ...
        }

        private Inspector SelectInspector()
        {
            // ... без изменений ...
        }
    }
}