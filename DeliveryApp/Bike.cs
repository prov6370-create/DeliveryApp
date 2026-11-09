namespace DeliveryApp;

class Bike : Transport
{
    public Bike(string name) : base(name) { }

    public override double CalculateCost(Order order)
    {
        return 20 + 5 * order.Distance;
    }

    public override bool CanTake(Order order)
    {
        return order.Weight <= 5 && order.Distance <= 10;
    }
}