using Class_Project.DTO;
using System.Data.SqlClient;
using static Class_Project.Employee;

namespace Class_Project
{
    public class Services
    {
        public static string connectionString = "Server=WIN-F7NIMF7A3VO;Database=BootCamp_N7;Trusted_Connection=True;Pooling = True;";
        public static List<ShowDTO> GetAllLikePremiumUser()
        {
            var listOfEmployees = new List<ShowDTO>();
            using (var connect = new SqlConnection())
            {
                connect.ConnectionString = connectionString;
                try
                {
                    connect.Open();

                    Console.WriteLine("DB connected!");

                    string query = "Select * from Employees";

                    SqlCommand cmd = new SqlCommand(query, connect);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int c = 0;
                        string s = "";
                        string[] strings = new string[reader.FieldCount];
                        while (reader.Read())
                        {
                            c = reader.FieldCount;
                            for (int i = 0; i < c; i++)
                            {
                                s += reader[i] + " ";
                            }
                            strings = s.Split();
                            listOfEmployees.Add(new ShowDTO
                            {
                                Id = int.Parse(strings[0]),
                                Name = strings[1],
                                Surname = strings[2],
                                Email = strings[3],
                                Status = (Status_Enum)int.Parse(strings[6]),
                                Role = (Role_Enum)int.Parse(strings[7]),
                                CreatedDate = strings[8],
                                ModifyDate = strings[9],
                                DeletedDate = strings[10],
                            });
                            s = "";
                        }

                        return listOfEmployees.Where(x => x.Status != Status_Enum.Deleted).ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public static List<Employee> GetAllLikeAdmin()
        {
            var listOfEmployees = new List<Employee>();
            using (var connect = new SqlConnection())
            {
                connect.ConnectionString = connectionString;
                try
                {
                    connect.Open();

                    Console.WriteLine("DB connected!");

                    string query = "Select * from Employees";

                    SqlCommand cmd = new SqlCommand(query, connect);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int c = 0;
                        string s = "";
                        string[] strings;
                        while (reader.Read())
                        {
                            c = reader.FieldCount;
                            for (int i = 0; i < c; i++)
                            {
                                s += reader[i] + " ";
                            }
                            strings = s.Split();
                            listOfEmployees.Add(new Employee
                            {
                                Id = int.Parse(strings[0]),
                                Name = strings[1],
                                Surname = strings[2],
                                Email = strings[3],
                                Login = strings[4],
                                Password = strings[5],
                                Status = (Status_Enum)int.Parse(strings[6]),
                                Role = (Role_Enum)int.Parse(strings[7]),
                                CreatedDate = strings[8],
                                ModifyDate = strings[9],
                                DeletedDate = strings[10],
                            });
                            s = "";
                        }
                        return listOfEmployees;//.Where(x => x.Status != Status_Enum.Deleted).ToList();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public static ShowDTO GetByIdLikePremiumUser(int id)
        {
            var allEmployees = GetAllLikePremiumUser();
            var result = allEmployees.FirstOrDefault(x => x.Id == id);
            if (result != null && result.Status != Status_Enum.Deleted)
            {
                return result;
            }
            Console.WriteLine("Employee don`t found or deleted before!");
            return null;
        }
        public static Employee GetByIdLikeAdmin(int id)
        {
            var allEmployees = GetAllLikeAdmin();
            var result = allEmployees.FirstOrDefault(x => x.Id == id);
            return result;
           
        }

        public static void CreateEmployee(CreateDTO employee)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    string insertQuery = "";
                    insertQuery += @$"Insert into Employees(Name,Surname,Email,Login,Password,Status,Role,CreatedDate)
                                        Values('{employee.Name}'
                                        ,'{employee.Surname}'
                                        ,'{employee.Email}'
                                        ,'{employee.Login}'
                                        ,'{employee.Password}'
                                        ,{(int)employee.Status}
                                        ,{(int)employee.Role}
                                        ,'{DateTime.Now.ToString("dd.MM.yy")}');";

                    SqlCommand cmd = new SqlCommand(insertQuery, connect);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Rows Added");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }

            }
        }
        public static void UpdateById(int id, UpdateDTO updateDTO)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    string updatetQuery = @$"UPDATE Employees SET Name = '{updateDTO.Name}', Surname = '{updateDTO.Surname}', 
                                                    Email = '{updateDTO.Email}',Login = '{updateDTO.Login}',
                                                    Password = '{updateDTO.Password}',Status = {(int)Status_Enum.Updated},
                                                    Role = {(int)updateDTO.Role},ModifyDate = '{DateTime.Now.ToString("dd.MM.yy")}' WHERE Employees.Id = {id} ;";

                    SqlCommand cmd = new SqlCommand(updatetQuery, connect);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Employee Updated");

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public static void DeleteFromBaseById(int id)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    string queryCommand = $"Delete from Employee where Employee.Id = {id}";
                    SqlCommand cmd = new SqlCommand(queryCommand, connect);
                    cmd.ExecuteNonQuery();
                    Console.Write("Employee Deleted From base");
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        public static void DeleteById(int id)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                try
                {
                    var emp = GetByIdLikeAdmin(id);
                    if (emp != null && emp.Status != Status_Enum.Deleted)
                    {
                        connect.Open();
                        var commandString = $"UPDATE Employees SET Status = {(int)Status_Enum.Deleted}, DeletedDate = '{DateTime.Now.ToString("dd.MM.yy")}' Where Employees.Id = {id}";
                        var sqlCommand = new SqlCommand(commandString, connect);
                        sqlCommand.ExecuteNonQuery();
                        Console.WriteLine("Employee Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Employee was deleted before!!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
