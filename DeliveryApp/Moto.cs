namespace DeliveryApp;

class Moto : Transport
{
    public Moto(string name) : base(name) { }

    public override double CalculateCost(Order order)
    {
        return 30 + 6 * order.Distance + 0.5 * order.Weight; ;
    }

    public override bool CanTake(Order order)
    {
        return order.Weight <= 15 && order.Distance <= 30;
    }
}