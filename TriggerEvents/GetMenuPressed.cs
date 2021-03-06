// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

#if VRTK_VERSION_3_2_0_OR_NEWER

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip("Get menu pressed event for VRTK. This is also known as button two.")]

	public class  GetMenuPressed : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("This will be true if the button aliased to the menu is held down. Also known as button two.")]
		public FsmBool menuPressed;

		public FsmBool everyFrame;

		VRTK.VRTK_ControllerEvents theScript;

		public override void Reset()
		{

			menuPressed = false;
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

			menuPressed.Value = theScript.buttonTwoPressed;


		}

	}
}

#else

namespace HutongGames.PlayMaker.Actions
{
[ActionCategory("VRTKController")]
[Tooltip("Get menu pressed event for VRTK.")]

public class  GetMenuPressed : FsmStateAction

{
[RequiredField]
[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
public FsmOwnerDefault gameObject;

[Tooltip("This will be true if the button aliased to the menu is held down.")]
public FsmBool menuPressed;

public FsmBool everyFrame;

VRTK.VRTK_ControllerEvents theScript;

public override void Reset()
{

menuPressed = false;
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

menuPressed.Value = theScript.menuPressed;

}

}
}

#endif