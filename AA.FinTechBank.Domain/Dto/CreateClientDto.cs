using System.ComponentModel.DataAnnotations;

namespace AA.FinTechBank.Domain.Dto
{
    public class CreateClientDto
    {
        [Required]
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public int ClientCount { get; set; }
        public int ClientBalance { get; set; } = 0;
        public DateTime ClientDateOfBirth { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPhone { get; set; }
        public string ClientEmail { get; set; }
        public string ClientType { get; set; }
        public string ClientMaritalStatus { get; set; }
        public int ClientIdentificationId { get; set; }
        public string ClientOccupation { get; set; }
        public string ClientGenre { get; set; }
        public string ClientNationality { get; set; }
    }
}
