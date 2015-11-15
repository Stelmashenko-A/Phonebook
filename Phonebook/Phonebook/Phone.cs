namespace Phonebook
{
    public class Phone
    {
        public Phone(string number, string description="")
        {
            Number = number;
            Description = description;
        }

        public string Number { get; }

        public string Description { get; }

        public override bool Equals(object obj)
        {
            var tmp = obj as Phone;
            return tmp != null && Equals(tmp);
        }

        public bool Equals(Phone other)
        {
            return string.Equals(Number, other.Number);
        }

        public override int GetHashCode()
        {
            return Number?.GetHashCode() ?? 0;
        }
    }
}