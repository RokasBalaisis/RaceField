namespace WebSocketServerWorking.Collectables
{
    interface Visitor
    {
        double visit(Bomb bomb);
        double visit(SpeedBoost speedBoost);
    }
}