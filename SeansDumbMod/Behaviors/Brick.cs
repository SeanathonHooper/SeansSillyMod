using LethalLib.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace SeansDumbMod.Behaviors
{
	internal class Brick : PhysicsProp
	{
		public Ray brickThrowRay;
		public RaycastHit brickHit;
		private int brickMask = 87420;
		public bool thrown = false;
		//public int brickHealth = 3;


		public override void OnHitGround()
		{
			base.OnHitGround();
			thrown = false;
			//if (brickHealth <= 0)
			//{
			//	Destroy(this.gameObject);
			//}
		}
		public override void ItemActivate(bool used, bool buttonDown = true)
		{ 
			if (base.IsOwner)
			{
				playerHeldBy.DiscardHeldObject(placeObject: true, null, GetBrickThrowDestination());
				//brickHealth--;
				//thrown = true;
			}
		}
		public Vector3 GetBrickThrowDestination()
		{
			Vector3 position = base.transform.position;
			brickThrowRay = new Ray(playerHeldBy.gameplayCamera.transform.position, playerHeldBy.gameplayCamera.transform.forward);
			position = ((!Physics.Raycast(brickThrowRay, out brickHit, 12f, brickMask, QueryTriggerInteraction.Ignore)) ? brickThrowRay.GetPoint(10f) : brickThrowRay.GetPoint(brickHit.distance - 0.05f));
			brickThrowRay = new Ray(position, Vector3.down);
			if (Physics.Raycast(brickThrowRay, out brickHit, 30f, brickMask, QueryTriggerInteraction.Ignore))
			{
				return brickHit.point + Vector3.up * 0.05f;
			}
			return brickThrowRay.GetPoint(30f);
		}
	}
}

