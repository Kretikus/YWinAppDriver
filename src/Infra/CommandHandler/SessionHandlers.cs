﻿// Copyright (c) https://github.com/licanhua/YWinAppDriver. All rights reserved.
// Licensed under the MIT License.

namespace WinAppDriver.Infra.CommandHandler
{
  class SetImplicitTimeoutHandler : SessionCommandHandlerBase<SetImplicitTimeoutReq, object>
  {
    protected override object ExecuteSessionCommand(ISessionManager sessionManager, ISession session, SetImplicitTimeoutReq req, string elementId)
    {
      if (req.type != null && req.type != "implicit")
      {
        throw new InvalidArgumentException("only type=implicit is supported");
      }
      if (req.ms < 0)
      {
        throw new InvalidArgumentException("ms shoudl not be negative");
      }
      session.SetImplicitTimeout((int)req.ms);
      return null;
    }
  }

  public class GetSourceHandler : ICommandHandler
  {
    public object ExecuteCommand(ISessionManager sessionManager, string sessionId, object body, string elementId)
    {
      return sessionManager.GetSession(sessionId).GetSource();
    }
  }

  class DeleteSessionHandler : ICommandHandler
  {
    public object ExecuteCommand(ISessionManager sessionManager, string sessionId, object body, string elementId)
    {
      if (sessionManager.ContainsSession(sessionId))
      {
        var session = sessionManager.GetSession(sessionId);
        sessionManager.DeleteSession(sessionId);
        session.QuitApplication();
      }
      return null;
    }
  }
}
