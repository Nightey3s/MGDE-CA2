using UnityEngine;

public interface ICollectible
{
    /// <summary>
    /// Pick up the ICollectible
    /// </summary>
    /// <param name="collector"></param>
    void PickUp(GameObject collector);
}
