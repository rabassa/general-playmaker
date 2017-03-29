// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Custom")]
	[Tooltip("Find random float between two values but excluding a specific range")]
	public class  randomFloatExlusion : FsmStateAction
	{

		[RequiredField]
		[TitleAttribute("Float Min")]
		public FsmFloat minPlaymaker;

		[RequiredField]
		[TitleAttribute("Float Max")]
		public FsmFloat maxPlaymaker;

		[RequiredField]
		[TitleAttribute("Float Min Exclusive")]
		public FsmFloat minExclusivePlaymaker;

		[RequiredField]
		[TitleAttribute("Float Max Exclusive")]
		public FsmFloat maxExclusivePlaymaker;

		[TitleAttribute("Returned Value")]
		public FsmFloat outcome;

		[Tooltip("Repeat every frame")]
		public bool everyFrame;

		private float min;
		private float max;
		private float maxExclusive;
		private float minExclusive;

		public override void Reset()
		{

			everyFrame = false;
			min = 0;
			max = 0;
			minExclusive = 0;
			maxExclusive = 0;
			outcome = null;

			minPlaymaker = null;
			maxPlaymaker = null;
			minExclusivePlaymaker = null;
			maxExclusivePlaymaker = null;
		}


		public override void OnEnter()
		{

			DoMath();

			if (!everyFrame)
				Finish();
		}


		public override void OnUpdate()
		{
				DoMath();
		}


		float DoMath()
		{
			min = minPlaymaker.Value;
			max = maxPlaymaker.Value;
			minExclusive = minExclusivePlaymaker.Value;
			maxExclusivePlaymaker = maxExclusivePlaymaker.Value;

			var excluded = maxExclusive - minExclusive;
			var newMax = max - excluded;
			outcome.Value = Random.Range (min, newMax);

			return outcome.Value > minExclusive ? outcome.Value + excluded : outcome.Value;
		}

	}
}