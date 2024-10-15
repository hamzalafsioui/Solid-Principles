// Single Responsibility: This class focuses only on Employee properties
class Employee
{
	public string Name { get; set; }
	public double BasicSalary { get; set; }

	public Employee(string name, double basicSalary)
	{
		Name = name;
		BasicSalary = basicSalary;
	}
}

// Open/Closed: We can extend the SalaryCalculator class with new types of salary calculations without modifying it
interface ISalaryCalculator
{
	double CalculateSalary(Employee employee);
}

class BasicSalaryCalculator : ISalaryCalculator
{
	public double CalculateSalary(Employee employee)
	{
		return employee.BasicSalary;
	}
}

class BonusSalaryCalculator : ISalaryCalculator
{
	public double CalculateSalary(Employee employee)
	{
		return employee.BasicSalary + 1000; // Bonus added
	}
}

// Liskov Substitution: This method can accept any ISalaryCalculator without breaking the code
// Dependency Inversion: SalaryService class - Depends on abstraction (ISalaryCalculator), not on concrete implementations
class SalaryService
{
	private readonly ISalaryCalculator _salaryCalculator;

	// Constructor Dependency Injection: Takes ISalaryCalculator (abstraction) as a dependency
	public SalaryService(ISalaryCalculator salaryCalculator)
	{
		_salaryCalculator = salaryCalculator; // This allows us to inject any type of salary calculator
	}

	// ProcessSalary method uses the injected ISalaryCalculator to calculate salary
	public void ProcessSalary(Employee employee)
	{
		double salary = _salaryCalculator.CalculateSalary(employee);
		Console.WriteLine($"Processed salary for {employee.Name}: {salary}");
	}
}

// Interface Segregation: Separated interfaces, so classes don't have to implement unnecessary methods
interface IReportGenerator
{
	void GenerateReport(Employee employee);
}

interface IPrinter
{
	void PrintReport(string reportContent);
}

class ReportGenerator : IReportGenerator
{
	public void GenerateReport(Employee employee)
	{
		Console.WriteLine($"Generating report for {employee.Name}");
	}
}

class ReportPrinter : IPrinter
{
	public void PrintReport(string reportContent)
	{
		Console.WriteLine($"Printing report: {reportContent}");
	}
}

/*
	 SRP (Single Responsibility): The Employee class only handles employee data, nothing else.
	 OCP (Open/Closed): The BasicSalaryCalculator and BonusSalaryCalculator extend the functionality of salary calculation without changing the ISalaryCalculator interface.
	 LSP (Liskov Substitution): The SalaryService works with any ISalaryCalculator implementation (both basic and bonus).
	 ISP (Interface Segregation): We have two interfaces, IReportGenerator and IPrinter, so classes implement only the methods they need.
	 DIP (Dependency Inversion): The SalaryService depends on the ISalaryCalculator interface, not a specific implementation, which makes it easy to swap different salary calculators.
 */

class Program
{
	static void Main(string[] args)
	{
		// Create an employee
		Employee employee = new Employee("Hamza", 5000);

		// Apply SRP, OCP, and DIP by using the salary calculators
		ISalaryCalculator basicSalaryCalculator = new BasicSalaryCalculator();
		ISalaryCalculator bonusSalaryCalculator = new BonusSalaryCalculator();

		SalaryService salaryServiceBasic = new SalaryService(basicSalaryCalculator);
		SalaryService salaryServiceBonus = new SalaryService(bonusSalaryCalculator);

		// Process salary with basic calculation
		Console.WriteLine("Process Salary with Basic Calculation...");

		salaryServiceBasic.ProcessSalary(employee);
		Console.WriteLine("Process Salary with Bonus Calculation...");
		// Process salary with bonus calculation
		salaryServiceBonus.ProcessSalary(employee);
	}
}
