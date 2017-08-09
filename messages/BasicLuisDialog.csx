using System;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

// For more information about this template visit http://aka.ms/azurebots-csharp-luis
[Serializable]
public class BasicLuisDialog : LuisDialog<object>
{
    public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(Utils.GetAppSetting("LuisAppId"), Utils.GetAppSetting("LuisAPIKey"))))
    {
        
    }

    [LuisIntent("None")]
    public async Task NoneIntent(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the none intent. You said: {result.Query[1]}"); //
        context.Wait(MessageReceived);
    }

    // Go to https://luis.ai and create a new intent, then train/publish your luis app.
    // Finally replace "MyIntent" with the name of your newly created intent in the following handler
    [LuisIntent("CreateAccount")]
    public async Task CreateAccount(IDialogContext context, LuisResult result)
    {
        if(!result.Query.Contains("@"))
        {
            await context.PostAsync($"You have not provided an email");
            return;
        }
        
        await context.PostAsync($"Are you sure you want to create an account as: {result.Query}"); //
        context.Wait(MessageReceived);
    }
    
    [LuisIntent("DeleteAccount")]
    public async Task DeleteAccount(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached Delete account selection");
    }

    [LuisIntent("ResetPassword")]
    public async Task ResetPassword(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached Reset Password Selection");
    }

    [LuisIntent("EnableAccount")]
    public async Task EnableAccount(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the Enable Account Selection");
    }

    [LuisIntent("DIsbaleAccount")]
    public async Task DisableAccount(IDialogContext context, LuisResult result)
    {
        await context.PostAsync($"You have reached the Disable Account Selection");
    }
}