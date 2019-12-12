namespace WebSocketServerWorking.Collectables
{
    class StrengthHighVisitor : Visitor
    {
        private const double Modifier = 2;

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