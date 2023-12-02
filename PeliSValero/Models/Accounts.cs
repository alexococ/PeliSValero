namespace PeliSValero.Models
{
    public class Account
    {
        public int UserId { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string NIF { get; set; }
        public decimal Balance { get; set; }

        public static int accountNumberSeed;




        /* CONSTRUCTORES */
        public Account(string firstName, string lastName, string nif, string username, decimal balance)
        {
            UserId = accountNumberSeed;
            FirstName = firstName;
            LastName = lastName;
            NIF = nif;
            Username = username;
            Balance = balance;
        }

        public Account()
        {
        }

    }
}