namespace WebSocketServerWorking.Collectables
{
    class DurationShortVisitor : Visitor
    {
        private const double Modifier = 0.5;

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