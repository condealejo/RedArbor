using RedArbor.Employee.Data.Abstract;
using RedArbor.Employee.Data.Interfaces;
using RedArbor.Employee.Data.Utility;
using RedArbor.Employee.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedArbor.Employee.Data.Concrete
{
    public class EmployeeData : DataBase, IEmployeeData
    {
        private readonly Int16  StatusDelete  = 3;
        public bool DeleteEmployee(long prmCompanyID) 
        {
            bool result = false;
            using (var conn = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[stpEmployeeDelete]", (SqlConnection)conn))
                {
                    var parametersMapper = command;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@prmCompanyID", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Input, Value = prmCompanyID });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@prmStatusID", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = StatusDelete });
                    command.ExecuteNonQuery();
                    result = true;
                }
                conn.Close();
            }
            return result;
        }

        public List<Entities.Concrete.Employee.Employee> GetAllEmployees()
        {
            List<Entities.Concrete.Employee.Employee> employeeList = new List<Entities.Concrete.Employee.Employee>();
            using (var conn = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[stpEmployeeSelect]", (SqlConnection)conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var lclEmployeee = EmployeeMapper.SqlDataReaderToEntity(reader);
                            employeeList.Add(lclEmployeee);
                        }
                    }
                }
                conn.Close();
            }
            return employeeList;
        }

        public Entities.Concrete.Employee.Employee GetEmployeeByCompanyID(long prmCompanyID)
        {
            Entities.Concrete.Employee.Employee employee = null;
            using (var conn = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[stpEmployeeSelectByCompanyID]", (SqlConnection)conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@prmCompanyID", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Input, Value = prmCompanyID });
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employee = EmployeeMapper.SqlDataReaderToEntity(reader);
                        }
                    }
                }
                conn.Close();
            }
            return employee;
        }

        public bool InsertEmployee(Entities.Concrete.Employee.Employee prmEmployee)
        {
            bool result = false;
            using (var conn = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[stpEmployeeInsert]", (SqlConnection)conn)) 
                {
                    var parametersMapper = command;
                    command.CommandType = CommandType.StoredProcedure;
                    EmployeeMapper.EntityToParameters(ref parametersMapper, prmEmployee);
                    command.Parameters.Add(new SqlParameter { ParameterName = "@prmSuccessFlag", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output, Value = result });
                    var rowsAffected = command.ExecuteNonQuery();
                    result = (bool)command.Parameters["@prmSuccessFlag"].Value;
                }
                conn.Close();
            }
            return result;
        }

        public bool UpdateEmployee(Entities.Concrete.Employee.Employee prmEmployee)
        {
            bool result = false;
            using (var conn = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[stpEmployeeUpdate]", (SqlConnection)conn))
                {
                    var parametersMapper = command;
                    command.CommandType = CommandType.StoredProcedure;
                    EmployeeMapper.EntityToParameters(ref parametersMapper, prmEmployee);
                    command.Parameters.Add(new SqlParameter { ParameterName = "@prmSuccessFlag", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output, Value = result });
                    var rowsAffected = command.ExecuteNonQuery();
                    result = (bool)command.Parameters["@prmSuccessFlag"].Value;
                }
                conn.Close();
            }
            return result;
        }

        public bool ValidateEmployee(long prmCompanyID, string prmUserName, bool prmIsUpdated) 
        {
            bool result = false;
            using (var conn = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[stpEmployeeValidateExists]", (SqlConnection)conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@prmCompanyID", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Input, Value = prmCompanyID });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@prmUserName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = prmUserName.Trim() });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@prmIsUpdate", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Input, Value = prmIsUpdated});
                    SqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        result = true;
                    }
                }
                conn.Close();
            }
            return result;
        }
    }
}
