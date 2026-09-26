using PhoenixFramework.Application;

namespace Lab.Infrastructure.Query.Contracts.Shared;

public class DownloadViewModel(byte[] file, string contentType, string name)
    : DownloadFileViewModel(file, contentType, name);