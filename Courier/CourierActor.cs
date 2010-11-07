﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExecutionActors;
using EveOperations;

namespace Courier
{
	class CourierActor : Actor, IMessageHandler, ISettingsProvider
	{
		protected CourierPlugin pPlugin = null;

		protected override void Init(object data)
		{
			pPlugin = (CourierPlugin)data;
			StateMachine.Register(CourierStateMachine.Id, new CourierStateMachine(pLog, this, this));
			pObserver.Notify(this, "Initialization", 100, "Eve Courier actor initialized");
		}

		protected override void Worker()
		{
			pObserver.Notify(this, "Start", 100, "Eve Courier actor started");
			CourierStateMachine machine = (CourierStateMachine)StateMachine.GetInstance(CourierStateMachine.Id);
			// TODO: transfer other settings
			machine.HandleEvent(CourierEvents.Start);
			pObserver.Notify(this, "End", 100, "Eve Courier actor returned");
		}

		#region IMessageHandler Members

		public void SendMessage(string stage, string msg)
		{
			pObserver.Notify(this, stage, 0, msg);
		}

		#endregion

		#region ISettingsProvider Members

		public Settings GetSettings()
		{
			return pPlugin.Settings;
		}

		public void SaveSettings()
		{
			pPlugin.SaveSettings();
		}

		#endregion
	}
}
