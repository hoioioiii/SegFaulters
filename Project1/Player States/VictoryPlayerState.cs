using System.Collections.Specialized;

public class VictoryPlayerState : IPlayerState
{
    private PlayerState player;
    //placeholder till connected with global health system
    public VictoryPlayerState(PlayerState player)
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
        // no-op
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
       //show end game screen or something similar 
       //not sure how to implement yet
    }
}