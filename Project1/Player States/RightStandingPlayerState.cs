
using Microsoft.VisualBasic;
using Project1;

public class RightStandingPlayerState : IPlayerState
{
    private PlayerState playerState;
    private Player player;

    public RightStandingPlayerState(Player player)
    {
        this.player = player;
    }

    public void ChangeDirection(PlayerDirection direction)
    {
        //fix other directions' classes
        switch (direction)
        {
            case PlayerDirection.Left:
                player.playerState = new LeftMovingPlayerState(player);
                break;
            case PlayerDirection.Right:
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
            player.playerState = new RightMovingPlayerState(player);
    }

    public void Update(PlayerDirection direction, bool moving)
    {
        player.playerState.IsMoving(moving);
        player.playerState.ChangeDirection(direction);
    }


}
