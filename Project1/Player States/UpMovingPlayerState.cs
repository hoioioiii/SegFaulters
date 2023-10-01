
using Microsoft.VisualBasic;
using Project1;

public class UpMovingPlayerState : IPlayerState
{
    private Player player;

    public UpMovingPlayerState(Player player)
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
                player.playerState = new RightMovingPlayerState(player);
                break;
            case PlayerDirection.Up:
                break;
            case PlayerDirection.Down:
                player.playerState = new DownMovingPlayerState(player);
                break;
        }

    }

    public void IsMoving(bool moving)
    {
        if (!moving)
            player.playerState = new UpStandingPlayerState(player);
    }

    public void Update(PlayerDirection direction, bool moving)
    {
        player.playerState.IsMoving(moving);
        player.playerState.ChangeDirection(direction);
    }


}
