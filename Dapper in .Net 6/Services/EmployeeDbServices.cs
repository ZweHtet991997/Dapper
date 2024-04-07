using Dapper;
using Dapper_in_.Net_6.Models;
using System.Data;
using System.Data.SqlClient;

namespace Dapper_in_.Net_6.Services
{
    public class EmployeeDbServices
    {
        private GetDBConnectionService _dbConnectionService;

        public EmployeeDbServices(GetDBConnectionService dbConnectionService)
        {
            _dbConnectionService = dbConnectionService;
        }

        public async Task<List<EmployeeModel>> GetEmployee()
        {
            try
            {
                string Query = SqlQueryList.GetEmployeeList();
                SqlConnection con = _dbConnectionService.OpenConnection();
                var dataResult = await con.QueryAsync<EmployeeModel>(Query);
                con.Close();
                var lstEmployee = dataResult.ToList();
                return lstEmployee;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Create(EmployeeModel model)
        {
            try
            {
                string Query = SqlQueryList.CreateEmployee();
                var parameter = new DynamicParameters();
                parameter.Add("@EmployeeId", model.EmployeeID);
                parameter.Add("@FullName", model.FullName);
                parameter.Add("@Email", model.Email);
                parameter.Add("@PhoneNumber", model.PhoneNumber);
                parameter.Add("@Office", model.Office);
                parameter.Add("@Department", model.Department);
                parameter.Add("@CreatedDate", DateTime.UtcNow.Date);
                SqlConnection con = _dbConnectionService.OpenConnection();
                var dataResult = await con.ExecuteAsync(Query, parameter);
                con.Close();
                return 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(EmployeeModel model)
        {
            try
            {
                string Query = SqlQueryList.UpdateEmployee();
                var parameter = new DynamicParameters();
                parameter.Add("@Id", model.Id);
                parameter.Add("@EmployeeID", model.EmployeeID);
                parameter.Add("@FullName", model.FullName);
                parameter.Add("@Email", model.Email);
                parameter.Add("@PhoneNumber", model.PhoneNumber);
                parameter.Add("@Office", model.Office);
                parameter.Add("@Department", model.Department);
                parameter.Add("@UpdatedDate", DateTime.UtcNow.Date);
                SqlConnection con = _dbConnectionService.OpenConnection();
                var dataResult = await con.ExecuteAsync(Query, parameter);
                con.Close();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int Id)
        {
            try
            {
                string Query = SqlQueryList.DeleteEmployee();
                var parameter = new DynamicParameters();
                parameter.Add("@Id", Id);
                SqlConnection con = _dbConnectionService.OpenConnection();
                var dataResult = await con.ExecuteAsync(Query, parameter);
                con.Close();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //using store procedure
        public async Task<EmployeeModel> GetEmployeeById(int employeeId)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@EmployeeID", employeeId);
                SqlConnection con = _dbConnectionService.OpenConnection();
                var dataResult = await con.QueryAsync<EmployeeModel>("GetEmployeeByEmployeeID", parameter, commandType: CommandType.StoredProcedure);
                con.Close();
                return dataResult.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
