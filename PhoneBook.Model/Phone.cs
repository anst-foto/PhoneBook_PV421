namespace PhoneBook.Model;

public enum PhoneType
{
    Unknown, Mobile, Work, Home
}

public class Phone
{
    public int Id { get; set; }
    public PhoneType Type { get; set; }
    public string Number { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool IsActive => !IsDeleted;
}