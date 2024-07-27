using PhoenixFramework.Application;

namespace Lab.Infrastructure.Query.Contracts.Shared
{
    public class DownloadViewModel : DownloadFileViewModel
    {
        public DownloadViewModel(byte[] file, string contentType, string name) : base(file, contentType, name)
        {
        }
    }
}
