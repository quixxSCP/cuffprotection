using Exiled.API.Interfaces;
using System.ComponentModel;
using static UnityEngine.Scripting.GarbageCollector;
namespace CuffProtection
{
    public class Config : IConfig
    {
        [Description("Is plugin activated?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Activate debug messages?")]
        public bool Debug { get; set; } = false;

        [Description("Notify the player who cuffed initially?")]
        public bool NotifyOriginalCuffer { get; set; } = true;

        [Description("Notify the cuffed player who uncuffed them?")]
        public bool NotifyCuffedPlayer { get; set; } = true;

        [Description("Message shown to the cuffer, variables: {remover}, {cuffed_player}")]
        public string UncuffMessageForCuffer { get; set; } = "<size=30><color=orange><b>Attention!</b></color>\n<size=25><color=white>{remover} removed the cuffs from {cuffed_player}.</color></size>";

        [Description("Message shown to the cuffed person, variables: {remover}, {original_cuffer}")]
        public string UncuffMessageForCuffed { get; set; } = "<size=30><color=green><b>You were freed!</b></color>\n<size=25><color=white>{remover} removed your cuffs from {original_cuffer}.</color></size>";
    }
}