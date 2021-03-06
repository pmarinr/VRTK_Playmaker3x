// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
#if VRTK_VERSION_3_2_0_OR_NEWER

{
	[ActionCategory("VRTKController")]
	[Tooltip("Get get grip pressed event for VRTK.")]

	public class  GetGripPressed : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("This will be true if the grip is squeezed about half way in.")]
		public FsmBool gripPressed;

		public FsmBool everyFrame;

		VRTK.VRTK_ControllerEvents theScript;

		public override void Reset()
		{

			gripPressed = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_ControllerEvents>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			gripPressed.Value = theScript.gripPressed;

		}

	}
}

#else

{
[ActionCategory("VRTKController")]
[Tooltip("Get get grip pressed event for VRTK.")]

public class  GetGripPressed : FsmStateAction

{
[RequiredField]
[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
public FsmOwnerDefault gameObject;

[Tooltip("This will be true if the grip is squeezed about half way in.")]
public FsmBool gripPressed;

public FsmBool everyFrame;

VRTK.VRTK_ControllerEvents theScript;

public override void Reset()
{

gripPressed = false;
gameObject = null;
everyFrame = false;
}

public override void OnEnter()
{
var go = Fsm.GetOwnerDefaultTarget(gameObject);

theScript = go.GetComponent<VRTK.VRTK_ControllerEvents>();

if (!everyFrame.Value)
{
MakeItSo();
Finish();
}

}

public override void OnUpdate()
{
if (everyFrame.Value)
{
MakeItSo();
}
}


void MakeItSo()
{
var go = Fsm.GetOwnerDefaultTarget(gameObject);
if (go == null)
{
return;
}

gripPressed.Value = theScript.grabPressed;

}

}
}

#endif