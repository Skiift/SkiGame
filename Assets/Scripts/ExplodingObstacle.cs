using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingObstacle : ObstacleScript //jāraksta mantojamā bāze, nav MonoBehavior
{
   protected override void PlayerCollision()
   {
      base.PlayerCollision();
      Destroy(gameObject);
   }
}
