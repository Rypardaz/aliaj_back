using PhoenixFramework.Application;

namespace AM.Infrastructure.Query.Contract.Shared;

public class DownloadViewModel(byte[] file, string contentType, string name)
    : DownloadFileViewModel(file, contentType, name);