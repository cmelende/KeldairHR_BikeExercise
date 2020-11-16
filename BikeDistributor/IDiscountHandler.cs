namespace BikeDistributor
{
    public interface IDiscountHandler
    {
        IDiscountHandler SetNext(IDiscountHandler handler);
        double Handle(Line line);
    }
}