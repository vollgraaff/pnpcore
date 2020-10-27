﻿using Microsoft.Extensions.Logging;
using PnP.Core.Services;

namespace PnP.Core.Model.Teams
{
    [GraphType]
    internal partial class TeamChatMessageContent : BaseDataModel<ITeamChatMessageContent>, ITeamChatMessageContent
    {        
        public TeamChatMessageContent()
        {
        }
        

        public string Content { get => GetValue<string>(); set => SetValue(value); }

        public ChatMessageContentType ContentType { get => GetValue<ChatMessageContentType>(); set => SetValue(value); }
    }
}