#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

using Microsoft.Bot.Bulilder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

public class CreateAccountForm
{
    [Prompt("What is the {&}")]
    public string Email { get; set; }

    [Prompt("What is the {&}")]
    public string Company { get; set; }

    [Prompt("What is the {&}")]
    public string PhoneNumber { get; set; }

    public static IForm<BasicForm> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<BasicForm>().Build();
    }

    public static IFormDialog<BasicForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}