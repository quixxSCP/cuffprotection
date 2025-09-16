using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;
using System.Collections.Generic;

namespace CuffProtection
{
    public class CuffProtection : Plugin<Config>
    {
        public override string Name => "CuffProtection";
        public override string Author => "quix";
        public override Version Version => new Version(1, 4, 0);
        public override Version RequiredExiledVersion => new Version(9, 8, 1);

        private static readonly Dictionary<Player, Player> CufferRegistry = new Dictionary<Player, Player>();

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            Exiled.Events.Handlers.Player.Handcuffing += OnCuffing;
            Exiled.Events.Handlers.Player.RemovingHandcuffs += OnUncuffing;
            Exiled.Events.Handlers.Player.Died += OnDied;
            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnded;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            Exiled.Events.Handlers.Player.Handcuffing -= OnCuffing;
            Exiled.Events.Handlers.Player.RemovingHandcuffs -= OnUncuffing;
            Exiled.Events.Handlers.Player.Died -= OnDied;
            Exiled.Events.Handlers.Server.RoundEnded -= OnRoundEnded;
            CufferRegistry.Clear();
            base.OnDisabled();
        }

        private void OnHurting(HurtingEventArgs ev)
        {
            if (!ev.Player.IsCuffed || ev.Player.IsScp)
                return;

            if (ev.Attacker == null || ev.Attacker.Role.Team == Team.SCPs)
                return;

            if (CufferRegistry.TryGetValue(ev.Player, out Player cuffer) && ev.Attacker == cuffer)
                return;

            ev.IsAllowed = false;
        }

        private void OnCuffing(HandcuffingEventArgs ev)
        {
            if (ev.Target != null && ev.Player != null)
            {
                CufferRegistry[ev.Target] = ev.Player;
            }
        }

        private void OnUncuffing(RemovingHandcuffsEventArgs ev)
        {
            if (CufferRegistry.TryGetValue(ev.Target, out Player originalCuffer))
            {
                Player remover = ev.Player;

                if (originalCuffer != null && originalCuffer.IsConnected && remover != originalCuffer)
                {
                    if (Config.NotifyOriginalCuffer)
                    {
                        string cufferHint = Config.UncuffMessageForCuffer
                            .Replace("{remover}", remover.Nickname)
                            .Replace("{cuffed_player}", ev.Target.Nickname);

                        originalCuffer.ShowHint(cufferHint, 5f);
                    }

                    if (Config.NotifyCuffedPlayer)
                    {
                        string cuffedHint = Config.UncuffMessageForCuffed
                            .Replace("{remover}", remover.Nickname)
                            .Replace("{original_cuffer}", originalCuffer.Nickname);

                        ev.Target.ShowHint(cuffedHint, 5f);
                    }
                }

                CufferRegistry.Remove(ev.Target);
            }
        }

        private void OnDied(DiedEventArgs ev)
        {
            if (ev.Player != null && CufferRegistry.ContainsKey(ev.Player))
            {
                CufferRegistry.Remove(ev.Player);
            }
        }

        private void OnRoundEnded(Exiled.Events.EventArgs.Server.RoundEndedEventArgs ev)
        {
            CufferRegistry.Clear();
        }
    }
}