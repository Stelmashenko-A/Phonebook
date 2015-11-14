namespace Phonebook
{
    public class Phone
    {
        public Phone(string value)
        {
            Value = value;
        }

        public string Value { get; protected set; }
    }
}