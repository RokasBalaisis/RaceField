namespace WebSocketServerWorking.Collectables
{
    public interface Visitor
    {
        double visit(Bomb bomb);
        double visit(SpeedBoost speedBoost);
    }
}