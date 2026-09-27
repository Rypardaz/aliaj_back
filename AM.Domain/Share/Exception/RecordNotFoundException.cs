using PhoenixFramework.Core.Exceptions;

namespace AM.Domain.Share.Exception;

public class RecordNotFoundException(string code = "200-", string message = "رکورد مورد نظر یافت نشد.")
    : BusinessException(code, message);