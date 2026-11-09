namespace DeliveryApp;

class Order
{
    public int Id;
    public string Description;
    public double Weight;
    public double Distance;
    public Transport AssignedTransport;
    public double Cost;

    public Order(int id, string description, double weight, double distance)
    {
        this.Id = id;
        this.Description = description;
        this.Weight = weight;
        this.Distance = distance;
    }
}