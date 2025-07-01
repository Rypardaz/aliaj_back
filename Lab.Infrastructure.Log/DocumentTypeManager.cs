namespace Lab.Infrastructure.OperationLog;

public static class DocumentTypeManager
{
    private static readonly Dictionary<int, string> Dictionary = new()
    {
        { DocumentTypeStore.EquipmentName, "نام تجهیزات" },
    };
}