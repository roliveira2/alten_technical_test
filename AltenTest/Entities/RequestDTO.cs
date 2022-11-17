using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AltenTest.Entities
{
    public class RequestDTO
    {
        public ErrorEnum idErro { get; set; }
        public string txtErro { get; set; }
        public List<string> listValidation { get; set; }
        public dynamic uniqueObject { get; set; }
        public dynamic listObject { get; set; }
        public string identity { get; set; }

        public enum ErrorEnum
        {
            [Description("Success")]
            Success = 0,
            [Description("Error inserting data")]
            ErrorInsert = 1,
            [Description("Error updating data")]
            ErrorUpdate = 2,
            [Description("Error reading data")]
            ErrorRead = 3,
            [Description("Error deleting data")]
            ErrorDelete = 4,
            [Description("No data result")]
            NoResult = 5,
            [Description("Validation error")]
            ErrorValidating = 6,
            [Description("Generic error")]
            Error = 7
        }

        public static class ErrorCategory
        {
            public static string ErrorRead { get { return "An error occurred while reading the record:"; } }
            public static string ErrorInsert { get { return "An error occurred while saving the record:"; } }
            public static string ErrorUpdate { get { return "An error occurred while updating the record:"; } }
            public static string ErrorDelete { get { return "An error occurred while deleting the record:"; } }
            public static string ErrorRegisterNotFound { get { return "A reservation with a specified location was not found."; } }
            public static string ErrorRegisterNotFoundSearch { get { return "No records were found with the search terms."; } }
            public static string ErrorRegisterBlock { get { return "The register is not able for editing."; } }
        }

    }
}
