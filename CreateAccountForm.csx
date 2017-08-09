#r "Newtonsoft.Json"

using System;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

[Serializable]
public class CreateAccountForm
{
    [Prompt("What is the {&}?")]
    public string Email { get; set; }

    [Prompt("What is the {&}")]
    public string Company { get; set; }

    [Prompt("What is the {&}")]
    public string PhoneNumber { get; set; }

    public static IForm<CreateAccountForm> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<CreateAccountForm>().Build();
    }

    public static IFormDialog<CreateAccountForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}