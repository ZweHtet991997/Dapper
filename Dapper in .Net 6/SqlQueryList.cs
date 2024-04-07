namespace Dapper_in_.Net_6
{
    public static class SqlQueryList
    {
        public static string GetEmployeeList()
        {
            return "SELECT * FROM Tbl_Emp";
        }

        public static string CreateEmployee()
        {
            return "INSERT INTO Tbl_Emp (EmployeeID,FullName,Email,PhoneNumber,Office,Department,CreatedDate) " +
                $"VALUES (@EmployeeID,@FullName,@Email,@PhoneNumber,@Office,@Department,@CreatedDate)";
        }

        public static string UpdateEmployee()
        {
            return "UPDATE Tbl_Emp SET EmployeeID=@EmployeeID,FullName=@FullName,Email=@Email,PhoneNumber=@PhoneNumber," +
                "Office=@Office,Department=@Department WHERE ID=@Id";
        }

        public static string DeleteEmployee()
        {
            return "DELETE FROM Tbl_Emp WHERE ID=@Id";
        }
    }
}
