using System.Linq;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Services;
using LazyPythons.Helper;
using LPCommandExecutor;
using LPCommandExecutor.Response;
using Microsoft.Bot;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Core.Extensions;
using Microsoft.Bot.Schema;

namespace LazyPythons.Bot
{
    public class EchoBot : IBot
    {
        private readonly CommadExecutor _executor;
        public EchoBot(CommadExecutor executor)
        {
            _executor = executor;
        }
        /// <summary>
        /// Every Conversation turn for our EchoBot will call this method. In here
        /// the bot checks the Activty type to verify it's a message, bumps the 
        /// turn conversation 'Turn' count, and then echoes the users typing
        /// back to them. 
        /// </summary>
        /// <param name="context">Turn scoped context containing all the data needed
        /// for processing this conversation turn. </param>        
        public async Task OnTurn(ITurnContext context)
        {
            // This bot is only handling Messages
            if (context.Activity.Type == ActivityTypes.Message)
            {
                // Get the conversation state from the turn context
                var state = context.GetConversationState<EchoState>();

                // Bump the turn count. 
                state.TurnCount++;
                // var result = await _service.GetAllCaffes().ConfigureAwait(false);
                //var t = result.Select(x=> x.Name).ToList();
                // Echo back to the user whatever they typed.

             
                IExecutorResponse response = await _executor.GetResponse(context.Activity.Text);

                Visualizer responder = new Visualizer(context);

                await responder.RespondToExecution(response);
            }
        }
    }
}
