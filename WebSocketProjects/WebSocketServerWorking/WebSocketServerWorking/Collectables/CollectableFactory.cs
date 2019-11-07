namespace WebSocketServerWorking.Collectables
{
    class CollectableFactory : Factory
    {
        private Bomb _bomb;
        private SpeedBoost _speedBoost;

        public CollectableFactory()
        {
            _bomb = new Bomb();
            _speedBoost = new SpeedBoost();
        }

        public override Collectable GetCollectable(Collectable.Type type)
        {
            switch (type)
            {
                case Collectable.Type.Bomb:
                    return (Bomb)_bomb.Clone();
                case Collectable.Type.SpeedBoost:
                    return (SpeedBoost)_speedBoost.Clone();
                default:
                    return null;
            }
        }
    }
}