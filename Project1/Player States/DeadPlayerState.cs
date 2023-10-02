public class DeadPlayerState : IPlayerState
{
    private PlayerState player;
    //placeholder till connected with global health system
    public DeadPlayerState(PlayerState player)
    {
        this.player = player;
        //construct sprite here too?? (texture?)
    }
    public void ChangeDirection()
    {
        // no-op
    }

    public void ChangeDirection(PlayerDirection direction)
    {
        throw new System.NotImplementedException();
    }

    public void DeathState()
    {
        //draw a dead player sprite!
    }

    public void IsMoving(bool moving)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damageAmount)
    {
        // no-op
    }

    public void Update()
    {
        //not sure how to approach this
    }

    public void Update(PlayerDirection direction, bool moving)
    {
        throw new System.NotImplementedException();
    }

    public void UseWeapon()
    {
        // no-op
    }

    public void VictoryState()
    {
        // no-op
    }
}
