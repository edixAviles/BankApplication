namespace BankApplication.Core.Response
{
    public class ResponseManager<T>
    {
        public Response<T> OnSuccess(T response)
        {
            return new Response<T>
            {
                Success = true,
                Result = response
            };
        }

        public Response<T> OnError(ErrorResponse error)
        {
            return new Response<T>
            {
                Success = false,
                Result = default,
                Error = error
            };
        }
    }
}
