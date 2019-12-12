namespace WebSocketServerWorking.Collectables
{
    interface Visitable
    {
        double modify(Visitor visitor);
    }
}