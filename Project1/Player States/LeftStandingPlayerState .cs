
using Microsoft.VisualBasic;
using Project1;

public class LeftStandingPlayerState : IPlayerState
{
    private Player player;

    public LeftStandingPlayerState(Player player)
    {
        this.player = player;
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
        if (moving)
            player.playerState = new LeftMovingPlayerState(player);
    }

    public void Update(PlayerDirection direction, bool moving)
    {
        player.playerState.IsMoving(moving);
        player.playerState.ChangeDirection(direction);
    }


}