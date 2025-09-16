# CuffProtection Plugin for SCP: Secret Laboratory

---

## CuffProtection v1.4.0

Ever get frustrated when you successfully cuff a D-Boi, only for a trigger-happy guard to come along and steal your kill? Or maybe you've been the one cuffed, helplessly watching as someone other than your captor decides your fate.

**CuffProtection** is here to change that! This plugin introduces a simple yet game-changing mechanic: once a player is cuffed, they are protected from being harmed by anyone *except* for the person who cuffed them.

### Features

*   **🛡️ Cuffed Player Protection:** Cuffed players cannot be damaged by any player other than their original cuffer. This prevents kill-stealing and encourages more strategic gameplay.
*   **🤝 The Cuffer is King:** The player who applies the handcuffs is the only one (besides SCPs) who can harm the cuffed individual. This gives the cuffer full control over their detainee.
*   **🔔 Smart Notifications:** Stay informed! The plugin provides customizable on-screen hints to both the original cuffer and the cuffed player if someone else removes the cuffs.
    *   The **original cuffer** is alerted when someone else frees their captive.
    *   The **cuffed player** is notified who set them free.
*   **CLEANUP:** The plugin automatically handles clearing its data on player death and at the end of each round to ensure smooth performance.

---

### How It Works

1.  **Handcuffing:** When a player cuffs another, the plugin logs who cuffed whom.
2.  **Protection Activated:** The cuffed player is now immune to damage from all players...
3.  **Exception to the Rule:** ...*except* for the player who initially cuffed them. SCPs can still harm cuffed players as usual.
4.  **Removing Cuffs:**
    *   If the original cuffer removes the cuffs, everything proceeds as normal.
    *   If a *different* player removes the cuffs, optional notifications are sent out.
5.  **Reset:** The protection is removed if the cuffed player dies, is uncuffed, or the round ends.

---

### Configuration

You can customize the plugin's behavior through the `Config.cs` file.

| Setting                  | Description                                                                                              | Default Value                                                                                                 |
| ------------------------ | -------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `IsEnabled`              | Globally enables or disables the plugin.                                                                 | `true`                                                                                                        |
| `NotifyOriginalCuffer`   | If `true`, the person who first cuffed a player will be notified if someone else uncuffs them.             | `true`                                                                                                        |
| `NotifyCuffedPlayer`     | If `true`, the cuffed player will be notified who freed them if it wasn't their original captor.            | `true`                                                                                                        |
| `UncuffMessageForCuffer` | The message shown to the original cuffer. Variables: `{remover}`, `{cuffed_player}`                        | `<size=30><color=orange><b>Attention!</b></color>\n<size=25><color=white>{remover} removed the cuffs from {cuffed_player}.</color></size>` |
| `UncuffMessageForCuffed` | The message shown to the cuffed player. Variables: `{remover}`, `{original_cuffer}`                      | `<size=30><color=green><b>You were freed!</b></color>\n<size=25><color=white>{remover} removed your cuffs from {original_cuffer}.</color></size>` |

---

### Why You Need This Plugin

*   **Reduces Trolling & Griefing:** Prevents random players from interfering with a successful capture.
*   **Encourages Teamwork:** Forces players to communicate instead of just shooting a detained enemy.
*   **Adds Strategic Depth:** Gives the capturing player more agency and control over the situation.
*   **Fully Customizable:** Tailor the notification messages to fit your server's style.

This plugin is a must-have for any server admin looking to refine the gameplay experience and promote more tactical interactions between players.
