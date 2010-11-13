﻿using ExecutionActors;
using Courier.States;

namespace Courier.Transitions
{
	class LoginSelectCharacterTransition : Transition<LoginState, CharacterSelectState>
	{
		public override bool CheckConstraints(LoginState currentState, int eventId)
		{
			return eventId == (int)CourierEvents.LoggedIn;
		}
	}
}
