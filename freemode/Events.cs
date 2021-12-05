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
            if(mysql.IsAccountExist(player.Name))
            {
                player.SendChatMessage("~w~Ваш аккаунт уже ~g~зарегистрирован~w~ на сервере. Используйте /login для авторизации.");
            }
            else
            {
                player.SendChatMessage("~w~Ваш аккаунт не ~g~зарегистрирован~w~ на сервере. Используйте /register для регистрации.");
            }
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
