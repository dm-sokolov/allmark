using AllMark.Interfaces;

namespace AllMark.Helpers
{
    public class SimpleHelper : ISimpleHelper
    {
        public string GetValue()
        {
            return nameof(SimpleHelper);
        }
    }
}
