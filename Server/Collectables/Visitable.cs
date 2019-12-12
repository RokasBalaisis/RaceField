namespace WebSocketServerWorking.Collectables
{
    interface Visitable
    {
        void modify(Visitor visitor);
    }
}