using PhoenixFramework.Core.Exceptions;

namespace Ex.Domain.Share.Exception;

public class RecordNotFoundException : BusinessException
{
    public RecordNotFoundException(string code = "200-", string message = "رکورد مورد نظر یافت نشد.")
        : base(code, message)
    {
    }
}