namespace DeliveryApp;

class Truck : Transport
{
    public Truck(string name) : base(name) { }

    public override double CalculateCost(Order order)
    {
        return 200 + 15 * order.Distance + 0.5 * order.Weight;
    
    }
    
}