namespace BikeDistributor
{
    public abstract class BaseDiscountHandler : IDiscountHandler
    {
        private IDiscountHandler _nextHandler;

        public IDiscountHandler SetNext(IDiscountHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual double Handle(Line line)
        {
            return _nextHandler?.Handle(line) ?? 0d;
        }
    }
}