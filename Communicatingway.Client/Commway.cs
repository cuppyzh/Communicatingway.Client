using Communicatingway.Client.Model.Configuration;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Logging;
using Dalamud.Plugin;

namespace Communicatingway.Client
{
    public class Commway : IDalamudPlugin
    {
        public string Name => "Commway";
        public static CommwayConfiguration Configuration;

        public Commway(DalamudPluginInterface dalamudPluginInterface)
        {
            PluginLog.LogInformation($"{Name} is starting....");

            dalamudPluginInterface.Create<PluginServices>();
            PluginServices.commway = this;

            PluginServices.chatGui.ChatMessage += ChatMessageEvent;
        }

        public void Dispose()
        {

        }

        #region Private Methods
        private void _LoadConfig()
        {

        }

        private void ChatMessageEvent(XivChatType type, uint senderId, ref SeString sender, ref SeString message, ref bool isHandled)
        {
            if (type != XivChatType.FreeCompany)
            {
                return;
            }

            //_apiCallService.SendMessage(sender.TextValue, message.TextValue);
        }
        #endregion
    }
}