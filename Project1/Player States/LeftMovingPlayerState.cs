
using Microsoft.VisualBasic;
using Project1;

public class LeftMovingPlayerState : IPlayerState
{
    private PlayerState playerState;
    private Player player;

    public LeftMovingPlayerState(Player player)
    {
        this.player = player;
        //construct sprite here too?? (texture?)
    }

    public void ChangeDirection(PlayerDirection direction)
    {
        //fix other directions' classes
        switch (direction) {
            case PlayerDirection.Left:
                break;
            case PlayerDirection.Right:
                player.playerState = new RightMovingPlayerState(player);
                break;
            case PlayerDirection.Up:
                player.playerState = new UpMovingPlayerState(player);
                break;
            case PlayerDirection.Down:
                player.playerState = new DownMovingPlayerState(player);
                break;
        }

    }

    public void IsMoving(bool moving)
    {
        player.playerState = new LeftStandingPlayerState(player);
    }

    public void Update(PlayerDirection direction, bool moving)
    {
        player.playerState.IsMoving(moving);
        player.playerState.ChangeDirection(direction);
    }

    public void UseWeapon()
    {
        //different sprite drawn
        //switch case depending on which direction facing
        //is a timed state, how to handle?
    }

}