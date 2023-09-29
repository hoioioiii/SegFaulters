using Microsoft.VisualBasic;
using Project1;
public class PlayerState : IPlayerState
{

    public IPlayerState State;



    public PlayerState(Player player)
    {

        State = new LeftMovingPlayerState(player);
    }

    public void ChangeDirection(PlayerDirection direction)
    {
        State.ChangeDirection(direction);
    }

    public void UseWeapon()
    {
        State.UseWeapon();
    }

    public void Update(PlayerDirection direction, bool moving)
    {
        State.Update(direction, moving);
    }

    public void IsMoving(bool moving)
    {
        State.IsMoving(moving);
    }
}
public enum PlayerDirection
{
    Left,
    Right,
    Up,
    Down
}