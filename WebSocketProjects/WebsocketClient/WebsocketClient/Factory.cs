namespace WebsocketClient
{
    public abstract class Factory
    {
        public abstract Collectable GetCollectable(Collectable.Type type);
    }
}