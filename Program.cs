using Class_Project;

Console.WriteLine();



//Services.CreateEmployee(Employee.AddNew());


var list = Services.GetAll();
foreach (var item in list)
{
    Console.WriteLine($"{item.Id} {item.Name} {item.Login} {item.Email} {item.CreatedDate} {item.Status}");
}


