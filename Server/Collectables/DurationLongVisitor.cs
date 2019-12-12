namespace WebSocketServerWorking.Collectables
{
    class DurationLongVisitor
    {
        private const double Modifier = 5;

        public double visit(Bomb bomb)
        {
            return bomb.duration * Modifier;
        }

        public double visit(SpeedBoost speedBoost)
        {
            return speedBoost.duration * Modifier;
        }
    }
}