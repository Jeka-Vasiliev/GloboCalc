using GloboCalc.Core.Abstractions;
using GloboCalc.Core.Tokenization;

namespace GloboCalc.Core
{
    public class TokenComparer
    {
        IOperationPropertiesExtractor _extractor;

        public TokenComparer(IOperationPropertiesExtractor extractor)
        {
            _extractor = extractor;
        }

        public bool IsPrecedencer(Token fromStack, Token current)
        {
            if (fromStack.TokenCategory != TokenCategory.Operator)
            {
                return false;
            }

            if (_extractor.GetPresendence(fromStack) >= _extractor.GetPresendence(current) &&
                _extractor.GetAssociativity(fromStack) == Associativity.Left)
            {
                return true;
            }
            return false;
        }
    }
}
