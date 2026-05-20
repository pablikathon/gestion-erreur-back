namespace Domain.DTO.Customer
{
    public class Customer(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Phone,
        string Address,
        bool IsActive,
        DateTime CreatedAt,
        DateTime UpdatedAt)
    {
        public Guid Id { get; init; } = Id;
        public string FirstName { get; init; } = FirstName;
        public string LastName { get; init; } = LastName;
        public string Email { get; init; } = Email;
        public string Phone { get; init; } = Phone;
        public string Address { get; init; } = Address;
        public bool IsActive { get; init; } = IsActive;
        public DateTime CreatedAt { get; init; } = CreatedAt;
        public DateTime UpdatedAt { get; init; } = UpdatedAt;

        /// <summary>
        /// Retourne "nouveau" si le client a été créé il y a moins de 6 mois,
        /// "habitué" s'il a été créé il y a environ 6 mois à moins d'un an,
        /// et "ancien" s'il a été créé il y a plus d'un an.
        /// </summary>
        public string Seniority
        {
            get
            {
                var now = DateTime.UtcNow;
                var age = now - CreatedAt.ToUniversalTime();

                if (age.TotalDays < (int)SeniorityEnum.Regular)
                {
                    return nameof(SeniorityEnum.New);
                }

                if (age.TotalDays <= (int)SeniorityEnum.Old)
                {
                    return nameof(SeniorityEnum.Regular);
                }

                return nameof(SeniorityEnum.Old);
            }
        }

        /// <summary>
        /// Vérifie si l'email du client est valide.
        /// </summary>
        public bool IsEmailValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Email)) return false;
                try
                {
                    var addr = new System.Net.Mail.MailAddress(Email);
                    return addr.Address == Email;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
}
