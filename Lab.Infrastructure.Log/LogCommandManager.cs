namespace Lab.Infrastructure.OperationLog;

public static class LogCommandManager
{
    private static readonly Dictionary<int, string> Dictionary = new()
    {
        { LogCommandStore.Create, "ایجاد" },
        { LogCommandStore.Edit, "ویرایش" },
        { LogCommandStore.Delete, "حذف غیرقابل بازگشت" },
        { LogCommandStore.Activate, "فعال سازی" },
        { LogCommandStore.Deactivate, "غیرفعال سازی" },
        { LogCommandStore.Lock, "فقل کردن" },
        { LogCommandStore.Unlock, "باز کردن" },
        { LogCommandStore.Remove, "حذف قابل بازگشت" },
        { LogCommandStore.Restore, "بازگشت از حذف" },
        { LogCommandStore.List, "مشاهده لیست" },
    };

    public static string TitleOf(int operation) => Dictionary[operation];
}