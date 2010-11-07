﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveOperations;

namespace Courier.States
{
	public class CharacterSelectState : EveCourierState
	{
		private const int pCharacterSelectWaitTime = 15 * 1000;

		public CharacterSelectState()
		{}

		public override void Enter()
		{
			pMachine.LogAndDisplay("CharacterSelectState", "Enter");
			if(pMachine.Eve.SelectCharacter((CharacterPosition)pMachine.Settings[CourierSettings.Position]))
			{
				pMachine.HandleEvent(CourierEvents.CharacterSelected);
				pMachine.Eve.EveWindow.Wait(pCharacterSelectWaitTime);
				pMachine.HandleEvent(CourierEvents.Initialized);
			}
			else
			{
				pMachine.HandleEvent(CourierEvents.End);
			}
		}
	}
}
