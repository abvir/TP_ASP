using App.Data;
using App.Data.Models;


namespace App.RepositoryData;

public class Repository : IRepository
{
    private ApiContext context;

    public Repository()
    {
        string[] companyNames = {
            "Acadian Ambulance",
            "Applied Research Associates",
            "Arizmendi Bakery",
            "Bi-Mart",
            "Black & Veatch",
            "Bob's Red Mill",
            "Brookshire Brothers",
            "Burns & McDonnell",
            "Carter's Foods",
            "Casino Queen",
            "CDM Smith",
            "Certain Affinity",
            "CH2M Hill",
            "The Cheese Board Collective",
            "Chicago and North Western Railway",
            "Columbia Forest Products",
            "Dahl's Foods",
            "Davey Tree Expert Company",
            "Dynetics",
            "Ebby Halliday Realtors",
            "Edgewood Management, LLC",
            "Eureka Casino Resort",
            "Evergreen Cooperatives",
            "Ferrellgas Partners",
            "Food Giant",
            "Frontline Test Equipment",
            "Gardener's Supply Company",
            "Gensler",
            "Golden Artist Colors",
            "Graybar",
            "Great Lakes Brewing Company",
            "Greatland Corporation",
            "Harps Food Stores",
            "HDR, Inc.",
            "Hensel Phelps Construction",
            "Herff Jones",
            "Herman Miller",
            "Houchens Industries",
            "Huck's Food & Fuel",
            "Hy-Vee",
            "John J. McMullen & Associates",
            "Journal Communications",
            "Kimley-Horn and Associates, Inc.",
            "King Arthur Flour",
            "Lampin Corporation",
            "Landmark Education",
            "Lifetouch",
            "Mast General Store",
            "Mathematica Policy Research",
            "Mushkin",
            "MWH Global",
            "New Belgium Brewing Company",
            "Neuberger Berman",
            "Niemann Foods",
            "Oliver Winery",
            "Peter Kiewit Sons'",
            "Phelps County Bank",
            "Publix",
            "Raycom Media",
            "Recology",
            "Robert McNeel & Associates",
            "Rosendin Electric",
            "Scheels",
            "Schreiber Foods",
            "Schweitzer Engineering Laboratories",
            "Springfield ReManufacturing",
            "Southern Exposure Seed Exchange",
            "Stewart's Shops",
            "Stiefel Labs",
            "STV Group",
            "Swales Aerospace",
            "Taylor Guitars",
            "Tidyman's",
            "Torch Technologies",
            "W. L. Gore & Associates",
            "W. W. Norton & Company",
            "Westat",
            "Wimberly Allison Tong & Goo",
            "WinCo Foods",
            "Woodman's Food Market"
        };

        string[] firstNames = {
            "John", "Mary", "Michael", "Jennifer", "James", "Elizabeth", "William", "Linda", "David", "Barbara", "Richard", "Susan"
        };

        string[] lastNames = {
            "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas"
        };

        (string city, string state)[] cities ={
                ("New York City", "New York"),
                ("Los Angeles", " California"),
                ("Chicago", "Illinois"),
                ("Houston", "Texas"),
                ("Phoenix","Arizona"),
                ("Philadelphia","Pennsylvania"),
                ("San Antonio","Texas"),
                ("San Diego","California"),
                ("Dallas","Texas"),
                ("San Jose","California"),
                ("Austin","Texas"),
                ("Jacksonville","Florida"),
                ("San Francisco","California"),
                ("Columbus","Ohio"),
                ("Fort Worth","Texas"),
                ("Indianapolis","Indiana"),
                ("Charlotte","North Carolina"),
                ("Seattle","Washington"),
                ("Denver"," Colorado"),
                ("Washington"," D.C."),
        };

        string[] positions = {
                "Chief Executive Officer (CEO)",
                "Chief Operating Officer (COO)",
                "Chief Financial Officer (CFO)",
                "Chief Technology Officer (CTO)",
                "Chief Marketing Officer (CMO)",
                "Chief Human Resources Officer (CHRO)",
                "Chief Information Officer (CIO)",
                "General Manager (GM)",
                "Vice President (VP) of Sales",
                "Vice President (VP) of Marketing",
                "Vice President (VP) of Finance",
                "Vice President (VP) of Operations",
                "Vice President (VP) of Human Resources",
                "Director of Sales",
                "Director of Marketing",
                "Director of Finance",
                "Director of Operations",
                "Director of Human Resources",
                "Project Manager",
                "Product Manager",
                "Business Development Manager",
                "Account Manager",
                "Sales Representative",
                "Marketing Specialist",
                "Financial Analyst",
                "Human Resources Coordinator",
                "IT Manager",
                "Software Engineer",
                "Data Analyst",
                "Customer Service Representative"
        };

        context = new ApiContext();
        context.Companies.AddRange(
                    Enumerable
                    .Range(1, 15)
                    .Select(c => new Company()
                    {
                        Name = companyNames[Random.Shared.Next(0, companyNames.Length)],
                        City = cities[Random.Shared.Next(0, cities.Length)].city,
                        State = cities[Random.Shared.Next(0, cities.Length)].state,
                        Address = $"{c}\'th street",
                        Phone = $"({Random.Shared.Next(100, 1000)})-{Random.Shared.Next(100, 1000)}-{Random.Shared.Next(1000, 10000)}",
                        Employees = Enumerable
                        .Range(1, 4)
                        .Select(e => new Employee()
                        {
                            LastName = lastNames[Random.Shared.Next(0, lastNames.Length)],
                            FirstName = firstNames[Random.Shared.Next(0, firstNames.Length)],
                            Birthday = new DateTime(1970, 01, 01).AddYears(Random.Shared.Next(0, 35)),
                            CompanyId = c,
                            Position = positions[Random.Shared.Next(0, positions.Length)],
                            Title = (Title)Random.Shared.Next(0, Enum.GetValues<Title>().Length),
                            Notes = Enumerable.Range(1, Random.Shared
                            .Next(0, 4))
                            .Select(n => new Note()
                            {
                                CompanyId = c,
                                EmployeeId = e,
                                InvoiceNumber = Random.Shared.Next(30000, 35000)
                            }).ToList()
                        }).ToList(),
                        Orders = Enumerable
                        .Range(1, 5)
                        .Select(o => new Order()
                        {
                            City = cities[Random.Shared.Next(0, cities.Length)].city,
                            Date = new DateTime(2022, 01, 01).AddDays(Random.Shared.Next(0, 365)),
                            CompanyId = c
                        }).OrderBy(o=>o.Date).ToList()
                    }).ToList()

                ); ;
        context.SaveChanges();
    }

    public IEnumerable<CompanyRow> GetCompanyRows()
        => context.Companies.Select(s => new CompanyRow(s.Id, s.Name, s.City, s.State, s.Phone));

    public CompanyDetail? GetCompanyDetail(int companyId)
    {
        var company = context.Companies.FirstOrDefault(d => d.Id == companyId);
        if (company != null)
            return new CompanyDetail(
                company.Id,
                company.Name,
                company.City,
                company.State,
                company.Address);
        return default;
    }

    public EmployeeDetail? GetEmployeeDetail(int employeeId)
    {
        var employee = context.Employees.FirstOrDefault(employee => employee.Id == employeeId);
        if (employee != null)
            return new EmployeeDetail(
                employee.Id,
                employee.FirstName,
                employee.LastName,
                employee.Title.ToString(),
                employee.Birthday.ToString("yyyy-MM-dd"),
                employee.Position);
        return default;
    }

    public IEnumerable<CompanyOrder> GetCompanyOrderHistoryRows(int companyId)
        => context.History
        .Where(order => order.CompanyId == companyId)
        .Select(order => new CompanyOrder(order.Id, order.Date.ToShortDateString(), order.City));

    public IEnumerable<CompanyNote> GetCompanyNoteRows(int companyId)
    => context.Notes
        .Where(note => note.CompanyId == companyId)
        .Select(note => new CompanyNote(note.Id, note.InvoiceNumber.ToString(), note.Employee == null ? "" : note.Employee.FullName));

    public IEnumerable<CompanyEmployee> GetCompanyEmployees(int companyId)
    => context.Employees
        .Where(employee => employee.CompanyId == companyId)
        .Select(employee => new CompanyEmployee(employee.Id, employee.FirstName, employee.LastName));
}
