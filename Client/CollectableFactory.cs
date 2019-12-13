namespace WebsocketClient
{
    class CollectableFactory : Factory
    {
        public override Collectable GetCollectable(Collectable.Type type)
        {
            switch (type)
            {
                case Collectable.Type.Bomb:
                    return new Bomb(1, 0.5);
                case Collectable.Type.SpeedBoost:
                    return new SpeedBoost(1, 0.5);
                default:
                    return null;
            }
        }
    }
}