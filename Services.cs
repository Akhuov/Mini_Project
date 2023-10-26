using System.Data.SqlClient;
using static Class_Project.Employee;

namespace Class_Project
{
    public class Services
    {
        public static string connectionString = "Server=WIN-F7NIMF7A3VO;Database=BootCamp_N7;Trusted_Connection=True;Pooling = True;";

        public static List<Employee> GetAll()
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
                                s+=reader[i] + " ";
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
                        return listOfEmployees;
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public static void CreateEmployee(Employee employee)
        {
            using (var connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    string insertQuery = "";
                    insertQuery += @$"Insert into Employees(Name,Surname,Email,Login,Password,Status,Role,CreatedDate,ModifyDate,DeletedDate)
                                        Values('{employee.Name}'
                                        ,'{employee.Surname}'
                                        ,'{employee.Email}'
                                        ,'{employee.Login}'
                                        ,'{employee.Password}'
                                        ,{(int)employee.Status}
                                        ,{(int)employee.Role}
                                        ,'{employee.CreatedDate}'
                                        ,'{employee.ModifyDate}'
                                        ,'{employee.DeletedDate}');";

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
    }
}
