using System;

namespace AzzyAIConfig
{
    public class EnumDescription
    {
        public EnumDescription(Enum value)
        {
            this.Value = value;
        }

        public Enum Value { get; private set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Description;
        }

        public override bool Equals(object obj)
        {
            EnumDescription other = obj as EnumDescription;
            return this.Value == obj || (other != null && this.Value == other.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
