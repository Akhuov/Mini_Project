using Class_Project;

Console.WriteLine();



//Services.CreateEmployee(Employee.AddNewEmployee());


var list = Services.GetAllLikePremiumUser();
foreach (var item in list)
{
    Console.WriteLine($"{item.Id} {item.Name} {item.Email} {item.CreatedDate} {item.Status}");
}


