using System;
using GTANetworkAPI;

namespace freemode
{
    class Commands : Script
    {
        [Command("veh", "/veh спавнит авто в координатах игрока", Alias ="vehicle")]
        private void cmd_veh(Player player, string vehname, int color1, int color2)
        {
            uint vhash = NAPI.Util.GetHashKey(vehname);
            if(vhash <= 0)
            {
                player.SendChatMessage("~r~Неверная модель т/с");
            }
            Vehicle veh = NAPI.Vehicle.CreateVehicle(vhash, player.Position, player.Heading, color1, color2);
            veh.NumberPlate = "Matthew";
            veh.Locked = false;
            veh.EngineStatus = true;
            player.SetIntoVehicle(veh, (int)VehicleSeat.Driver);
        }

        [Command("freeze", "/freeze [ник игрока] [true/false]")]
        private void cmd_freezeplayer(Player player, Player target, bool freezestatus)
        {
            NAPI.ClientEvent.TriggerClientEvent(target, "PlayerFreeze", freezestatus);
        }
    }
}
