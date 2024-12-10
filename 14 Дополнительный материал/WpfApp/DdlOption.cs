namespace WpfApp
{
    public class DdlOption
    {
        public string Text;
        public string Value;

        public DdlOption(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }

}
