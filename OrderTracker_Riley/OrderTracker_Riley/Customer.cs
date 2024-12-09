
namespace OrderTracker_Riley
{
    public record Customer(string Name, string Address) : ICustomer
    {
        private string _phoneNumber = "123-456-7890"; // Default value to avoid CS8618

        public Customer(string name, string address, string phoneNumber) : this(name, address)
        {
            _phoneNumber = phoneNumber;
        }

        public void Deconstruct(out string Name, out string Address, out string PhoneNumber)
        {
            Name = this.Name;
            Address = this.Address;
            PhoneNumber = GetPhoneNumber1();
        }

        public string GetPhoneNumber1()
        {
            // Implement the method to return a phone number
            return _phoneNumber;
        }

        public void SetPhoneNumber(string value)
        {
            // Implement the method to set a phone number
            _phoneNumber = value;
        }

        // The record's primary constructor automatically initializes Name and Address.
        // Remove unnecessary custom constructors or additional properties.

        // Override methods only if custom behavior is required, otherwise let the record handle it.
        public override string ToString() => $"{Name}, {Address}, {GetPhoneNumber1()}";
    }
    }

// Define the ICustomer interface if required (example):
#pragma warning disable CA1050 // Declare types in namespaces
public interface ICustomer
#pragma warning restore CA1050 // Declare types in namespaces
{
    string Name
    {
        get;
    }
    string Address
    {
        get;
    }

    string GetPhoneNumber1();
}
