namespace DeliveryApp;

class DeliveryService
{
    private List<Transport> transports = new List<Transport>();
    private List<Order> activeOrders = new List<Order>();
    private List<Order> history = new List<Order>();

    public void AddTransport(Transport t)
    {
        transports.Add(t);
    }

    public void ShowCosts(Order order)
    {
        Console.WriteLine($"Вартість доставки заказу {order.Id}:");
        foreach (Transport t in transports)
        {
            if (t.CanTake(order))
            {
                Console.WriteLine($"  {t.Name}: {t.CalculateCost(order)} грн");
            }
        }
    }

    public void Assign(Order order, Transport transport)
    {
        if (transport.IsBusy)
        {
            Console.WriteLine($"{transport.Name} зайнятий, заказ {order.Id} не призначено.");
            return;
        }
        if (!transport.CanTake(order))
        {
            Console.WriteLine($"{transport.Name} не може взяти заказ {order.Id}.");
            return;
        }

        transport.IsBusy = true;
        order.AssignedTransport = transport;
        activeOrders.Add(order);
        Console.WriteLine($"Заказ {order.Id} призначено на {transport.Name}.");
    }

    public void ShowActiveOrders()
    {
        Console.WriteLine("Активні заказы:");
        foreach (Order o in activeOrders)
        {
            Console.WriteLine($"  Заказ {o.Id}: {o.Description} -> {o.AssignedTransport.Name}");
        }
    }
    public void Deliver(Order order, IPayment payment)
    {
        if (!activeOrders.Contains(order))
        {
            Console.WriteLine($"Заказ {order.Id} не є активним, доставити неможливо.");
            return;
        }

        double cost = order.AssignedTransport.CalculateCost(order);
        payment.Pay(cost);

        order.Cost = cost;
        order.AssignedTransport.IsBusy = false;
        activeOrders.Remove(order);
        history.Add(order);
        Console.WriteLine($"Заказ {order.Id} доставлено.");
    }

    public void ShowHistory()
    {
        Console.WriteLine("Історія доставок:");
        foreach (Order o in history)
        {
            Console.WriteLine($"  Заказ {o.Id}: {o.Description}, {o.Cost} грн, {o.AssignedTransport.Name}");
        }
    }
}