
using ItemsoftMX.Base.Domain.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;


namespace Back.Rest.Domain.Utils
{
    public static class HandleException<T> where T : class
    {
        public static BaseResponse<T> GetError(Exception exception)
        {
            BaseResponse<T> error = new BaseResponse<T>()
            {
                Message = "Ocurrio un problema al realizar la petición.",
                //   Exception = exception.Message
            };

            if (exception is DbUpdateConcurrencyException concurrencyEx)
            {
                error.Message = "Error de Concurrencia. Espere un momento e intente de nuevo.";
            }
            else if (exception is DbUpdateException dbUpdateEx)
            {
                if (dbUpdateEx.InnerException != null && dbUpdateEx.InnerException.InnerException != null)
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                                //return new Exception(dbUpdateEx.Message, dbUpdateEx.InnerException);
                                error.Message = "Unique constraint error.";
                                break;
                            case 547:   // Constraint check violation
                                //return new Exception(dbUpdateEx.Message, dbUpdateEx.InnerException);
                                error.Message = "Constraint check violation.";
                                break;
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                //return new Exception("Registro duplicado.");
                                error.Message = "Registro duplicado.";
                                break;
                            default:
                                // A custom exception of yours for other DB issues
                                //return new Exception(dbUpdateEx.Message, dbUpdateEx.InnerException);
                                if (dbUpdateEx.InnerException != null)
                                {
                                    error.Message = dbUpdateEx.InnerException.Message;
                                }
                                else
                                {
                                    error.Message = dbUpdateEx.Message;
                                }

                                break;
                        }
                    }
                    //else 
                    //if (dbUpdateEx.InnerException is SqlException mySqlException)
                    //{
                    //    switch (mySqlException.Number)
                    //    {
                    //        case 1062:
                    //            error.Message = "Registro duplicado.";
                    //            break;
                    //        default:

                    //            if (dbUpdateEx.InnerException != null)
                    //            {
                    //                error.Message = dbUpdateEx.InnerException.Message;
                    //            }
                    //            else
                    //            {
                    //                error.Message = dbUpdateEx.Message;
                    //            }

                    //            break;
                    //    }
                    //}

                }
            }

            return error;
        }

        //private static Exception  ConcurrencyException()
        //{
        //   return new Exception("Error de Concurrencia. Espere un momento e intente de nuevo.");
        //}


        public static BaseResponse<T> GetError(string exception, string code = "ServerError")
        {
            return new BaseResponse<T>()
            {
                Message = exception,
                //   Exception = exception
            };
        }
    }
}
