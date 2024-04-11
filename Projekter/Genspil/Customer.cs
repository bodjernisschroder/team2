namespace Genspil
{
    public class Customer
    {
        private string _name;
        private string _email;
        private string _phoneNumber;
        public string Name
        { 
            get { return _name; }
            set
            {
                if (value == "") throw new Exception("Customer must have a name");
                _name = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (value == "") _email = "N/A";
                else _email = value;
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value == "") _phoneNumber = "N/A";
                else _phoneNumber = value;
            }
        }

        public Customer()
        {
            Name = ConsoleManager.AddCustomerName();
            Email = ConsoleManager.AddCustomerEmail();
            PhoneNumber = ConsoleManager.AddCustomerPhoneNumber();
        }

        public Customer(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}