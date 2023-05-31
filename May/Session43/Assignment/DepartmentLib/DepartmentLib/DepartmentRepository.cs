using DepartmentLib.Model;
using System.Data.SqlClient;

namespace DepartmentLib
{
    public class DepartmentRepository
    {
        private string _connectionString;

        public DepartmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Department> Get()
        {
            var connectionString = _connectionString;
            var connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select * from DEPT", connection);
            List<Department> departments = new List<Department>();
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Department department = new Department
                    {
                        DeptNo = Convert.ToInt32(reader["DEPTNO"]),
                        DName = Convert.ToString(reader["DNAME"]),
                        Location = Convert.ToString(reader["LOC"])
                    };

                    departments.Add(department);
                }
            }
            return departments;
        }
        public void Add(Department department)
        {
            var connectionString = _connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO DEPT(DNAME,LOCATION)VALUES(@NAME,@LOCATION)", connection);
                command.Parameters.AddWithValue("@DEPTNO", department.DeptNo);
                command.Parameters.AddWithValue("@DNAME", department.DName);
                command.Parameters.AddWithValue("@LOC", department.Location);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public int Count()
        {
            int count = 0;
            var connectionString = _connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM DEPT";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                count = (int)command.ExecuteScalar();
            }

            return count;
        }

        public async Task<List<Department>> GetAsync()
        {
            List<Department> departments = new List<Department>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT DEPTNO, DNAME, LOC FROM DEPT";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Department department = new Department
                        {
                            DeptNo = Convert.ToInt32(reader["DEPTNO"]),
                            DName = Convert.ToString(reader["DNAME"]),
                            Location = Convert.ToString(reader["LOC"])
                        };

                        departments.Add(department);
                    }
                }
            }
            return departments;
        }
        public async Task AddAsync(Department department)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO DEPT (DEPTNO, DNAME, LOC) VALUES (@DEPTNO, @DNAME, @LOC)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DEPTNO", department.DeptNo);
                command.Parameters.AddWithValue("@DNAME", department.DName);
                command.Parameters.AddWithValue("@LOC", department.Location);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }
        public async Task<int> CountAsync()
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM DEPT";
                SqlCommand command = new SqlCommand(query, connection);

                await connection.OpenAsync();
                count = (int)await command.ExecuteScalarAsync();
            }

            return count;
        }
    }
}