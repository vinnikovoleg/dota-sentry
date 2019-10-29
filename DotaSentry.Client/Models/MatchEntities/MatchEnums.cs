using System;
using System.Collections.Generic;
using System.Text;

namespace DotaSentry.Client.Models.MatchEntities
{
    public enum ChatType { Chat, Chatwheel };

    public enum ObjectiveType { BuildingKill, ChatMessageAegis, ChatMessageFirstblood, ChatMessageRoshanKill };

    public enum Prefab { Courier, Taunt, Tool, Wearable };

    public enum MaxHeroHitType { MaxHeroHit };

    public enum ObsLeftLogType { ObsLeftLog, ObsLog, SenLeftLog, SenLog };

    public struct Key
    {
        public long? Integer;
        public string String;

        public static implicit operator Key(long Integer) => new Key { Integer = Integer };
        public static implicit operator Key(string String) => new Key { String = String };
    }
}
