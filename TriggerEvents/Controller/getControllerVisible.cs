// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions

#if VRTK_VERSION_3_2_0_OR_NEWER

{
	[ActionCategory("VRTKController")]
	[Tooltip("Check whether the controller is currently visible.")]

	public class  getControllerVisible : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_ControllerEvents))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("Get controller visibility")]
		public FsmBool getControllerVisibility;

		public FsmBool everyFrame;

		VRTK.VRTK_ControllerEvents controller;

		public override void Reset()
		{

			getControllerVisibility = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			controller = go.GetComponent<VRTK.VRTK_ControllerEvents>();

			MakeItSo();

			if (!everyFrame.Value)
			{
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

			getControllerVisibility.Value = controller.controllerVisible;

		}

	}
}

#else

{
[ActionCategory("VRTKController")]
[Tooltip("Check whether the controller is currently visible.")]

public class  getControllerVisible : FsmStateAction

{
[RequiredField]
[CheckForComponent(typeof(VRTK.VRTK_ControllerActions))]    
public FsmOwnerDefault gameObject;

[Tooltip("Get controller visibility")]
public FsmBool getControllerVisibility;

public FsmBool everyFrame;

VRTK.VRTK_ControllerActions theScript;

public override void Reset()
{

getControllerVisibility = false;
gameObject = null;
everyFrame = false;
}

public override void OnEnter()
{
var go = Fsm.GetOwnerDefaultTarget(gameObject);

theScript = go.GetComponent<VRTK.VRTK_ControllerActions>();

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

getControllerVisibility.Value = theScript.IsControllerVisible ();		
}

}
}

#endif