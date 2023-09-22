namespace BankApplication.Core.Contracts.ApiService
{
    public interface IAppApiServiceManager
    {
        Task<AppApiResponseDto> GetAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true);
        Task<AppApiResponseDto> PostAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true);
        Task<AppApiResponseDto> PatchAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true);
        Task<AppApiResponseDto> PutAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true);
        Task<AppApiResponseDto> DeleteAsync(RequestDataDto requestData, bool withAcceptJsonHeader = true);
    }
}
