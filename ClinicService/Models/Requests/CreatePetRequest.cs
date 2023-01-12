namespace ClinicService.Models.Requests
{
    public class CreatePetRequest
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public int PetId { get; internal set; }
        public DateTime ConsultationDate { get; internal set; }
        public string Description { get; internal set; }
    }
}
