using Class_Project;

Console.WriteLine();



//Services.CreateEmployee(Employee.AddNewEmployee());



//Services.UpdateById(2,Employee.UpdateEmployee());

Services.DeleteById(1);

var list = Services.GetAllLikeAdmin();
foreach (var item in list)
{
    Console.WriteLine($"{item.Id} {item.Name} {item.Email} {item.CreatedDate} {item.Status}");
}


