using RedArbor.Employee.Utilities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RedArbor.Employee.Data.Utility
{
    public class EmployeeMapper
    {
        /// <summary>
        /// Metodo para mapear de objeto SqlDataReader a entidad
        /// </summary>
        /// <param name="prmReader"></param>
        /// <returns></returns>
        public static Entities.Concrete.Employee.Employee SqlDataReaderToEntity(SqlDataReader prmReader) 
        {
            return new Entities.Concrete.Employee.Employee() {
                CompanyID = (long)prmReader["CompanyID"],
                Name = prmReader["Name"].ToString(),
                UserName = prmReader["UserName"].ToString(),
                Email = prmReader["Email"].ToString(),
                Password = prmReader["Password"].ToString(),
                Telephone = prmReader["Telephone"].ToString(),
                Fax = prmReader["Fax"].ToString(), 
                PortalID = (Int16)prmReader["PortalID"],
                RoleID = (Int16)prmReader["RoleID"],
                StatusID = (Int16)prmReader["StatusID"],
                LastLogin = Convert.ToDateTime(prmReader["LastLogin"]),
                CreatedOn = Convert.ToDateTime(prmReader["CreatedOn"]),
                UpdatedOn = Convert.ToDateTime(prmReader["UpdatedOn"]),
                DeletedOn = Convert.ToDateTime(prmReader["DeletedOn"])
            };
        }

        /// <summary>
        /// Metodo utilitario para llenar parametros de un objeto SQLCommand, se usa en el insert y update(usan los mismos paramentros).
        /// </summary>
        /// <param name="prmCommand"> Objeto SQLCommand previamente instanciado.</param>
        /// <param name="prmEmployee"></param>
        public static void EntityToParameters(ref SqlCommand prmCommand, Entities.Concrete.Employee.Employee prmEmployee) 
        {
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmCompanyID", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.Input, Value = prmEmployee.CompanyID });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = prmEmployee.Name.Trim() });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmUserName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Size = 50, Value = prmEmployee.UserName.Trim() });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmEmail", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = prmEmployee.Email.Trim() });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmPassword", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = Encryptor.EncryptSHA1Managed(prmEmployee.Password.Trim()) });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmTelephone", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = prmEmployee.Telephone.Trim() });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmFax", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = prmEmployee.Fax.Trim() });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmPortalID", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = prmEmployee.PortalID });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmRoleID", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = prmEmployee.RoleID });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmStatusID", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Input, Value = prmEmployee.StatusID });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmLastLogin", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = NullOrEmptyToDBNull(prmEmployee.LastLogin) });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmCreatedOn", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = NullOrEmptyToDBNull(prmEmployee.CreatedOn) });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmUpdatedOn", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = NullOrEmptyToDBNull(prmEmployee.UpdatedOn) });
            prmCommand.Parameters.Add(new SqlParameter { ParameterName = "@prmDeletedOn", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Input, Value = NullOrEmptyToDBNull(prmEmployee.DeletedOn) });
        }

        /// <summary>
        /// Si la propiedad o el objeto pasado como argumento es nulo o vacio, retorna un DBNull
        /// </summary>
        /// <param name="prmObject"></param>
        /// <returns></returns>
        private static object NullOrEmptyToDBNull(object prmObject)
        {
            if (prmObject == null)
            {
                return DBNull.Value;
            }
            else
            {
                if (prmObject is string)
                {
                    if (Convert.ToString(prmObject) == "")
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is byte[])
                {
                    if (((byte[])prmObject).Length == 0)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is byte)
                {
                    if (Convert.ToByte(prmObject) == 0)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is short)
                {
                    if (Convert.ToInt32(prmObject) == 0)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is int)
                {
                    if (Convert.ToInt32(prmObject) == 0)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is long)
                {
                    if (Convert.ToInt64(prmObject) == 0)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is float)
                {
                    if (Convert.ToSingle(prmObject) - 0.0 < 0.0000001)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is double)
                {
                    if (Convert.ToDouble(prmObject) - 0.0 < 0.0000001)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is decimal)
                {
                    if (Convert.ToDecimal(prmObject) == 0)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is DateTime)
                {
                    if (Convert.ToDateTime(prmObject) == DateTime.MinValue)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is byte)
                {
                    if (prmObject != null && Convert.ToByte(prmObject) == 0)
                    {
                        return DBNull.Value;
                    }
                }
                else if (prmObject is Guid)
                {
                    if (prmObject.Equals(new Guid("00000000-0000-0000-0000-000000000000")))
                    {
                        return DBNull.Value;
                    }
                }
                return prmObject;
            }
        }
    }
}
