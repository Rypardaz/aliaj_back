namespace Ex.Application.Contracts.Salon
{
    public class EditSalon : CreateSalon
    {
        public Guid Guid { get; set; }
        public int SalonType { get; set; }
    }
}
