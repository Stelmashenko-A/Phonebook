namespace Phonebook
{
    public class Phone
    {
        public Phone(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override bool Equals(object obj)
        {
            var tmp = obj as Phone;
            return tmp != null && Equals(tmp);
        }

        public bool Equals(Phone other)
        {
            return string.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }
    }
}