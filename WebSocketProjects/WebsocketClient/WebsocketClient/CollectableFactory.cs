namespace WebsocketClient
{
    class CollectableFactory : Factory
    {
        public override Collectable GetCollectable(Collectable.Type type)
        {
            switch (type)
            {
                case Collectable.Type.Bomb:
                    return new Bomb();
                case Collectable.Type.SpeedBoost:
                    return new SpeedBoost();
                default:
                    return null;
            }
        }
    }
}