namespace Lab.Infrastructure.OperationLog;

public static class LogCommandStore
{
    public const int Create = 1;
    public const int Edit = 2;
    public const int Delete = 3;
    public const int Activate = 4;
    public const int Deactivate = 5;
    public const int Lock = 6;
    public const int Unlock = 7;
    public const int Remove = 8;
    public const int Restore = 9;
    public const int List = 10;
}