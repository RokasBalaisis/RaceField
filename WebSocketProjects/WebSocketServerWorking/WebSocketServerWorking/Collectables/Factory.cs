namespace WebSocketServerWorking.Collectables
{
    public abstract class Factory
    {
        public abstract Collectable GetCollectable(Collectable.Type type);
    }
}