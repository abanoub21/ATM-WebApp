namespace ATMApplication.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Password { get; set; }
        public int Balance { get; set; }
    }
}
