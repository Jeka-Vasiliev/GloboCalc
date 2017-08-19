namespace GloboCalc.Core.Tokenization
{
    public struct Token
    {
        public Token(string value, TokenCategory tokenCategory, int position)
        {
            Value = value;
            TokenCategory = tokenCategory;
            Position = position;
        }

        public string Value;

        public TokenCategory TokenCategory;

        public int Position;
    }
}