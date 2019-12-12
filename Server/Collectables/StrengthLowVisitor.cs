namespace WebSocketServerWorking.Collectables
{
    class StrengthLowVisitor : Visitor
    {
        private const double Modifier = 0.3;

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