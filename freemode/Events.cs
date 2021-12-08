using System;
using GTANetworkAPI;

namespace freemode
{
    class Events : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStarted()
        {
            mysql.InitConnection();
        }
        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            player.SendChatMessage("Добро пожаловать на сервер ~g~Global RP");
            NAPI.ClientEvent.TriggerClientEvent(player, "showLoginWindow");
            NAPI.ClientEvent.TriggerClientEvent(player, "PlayerFreeze", true);
        }

        [ServerEvent(Event.PlayerSpawn)]
        private void OnPlayerSpawn(Player player)
        {
            player.Health = 50;
            player.Armor = 50;
        }
    }
}
