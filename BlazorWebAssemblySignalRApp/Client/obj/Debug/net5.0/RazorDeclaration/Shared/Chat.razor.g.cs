// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorWebAssemblySignalRApp.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using BlazorWebAssemblySignalRApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/_Imports.razor"
using BlazorWebAssemblySignalRApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/Shared/Chat.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/chatRoom")]
    public partial class Chat : Microsoft.AspNetCore.Components.ComponentBase, IAsyncDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "/Volumes/EDUCATION/FinalAssignment6/BlazorWebAssemblySignalRApp/Client/Shared/Chat.razor"
       
    private string currentHeading = "BhoomitPatel's lounge";
    private string newHeading;
    private void UpdateHeading()
    {
        currentHeading = $"{newHeading}";
        newHeading = string.Empty;
    }


    private HubConnection hubConnection;
    private List<string> messages = new List<string>();
    private string userInput;
    private string messageInput;




    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
        .WithUrl(NavigationManager.ToAbsoluteUri("/chathub") + "?parameter=Anonymous")
        .Build();

        hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            var encodedMsg = $"{user}: {message}";
            messages.Add(encodedMsg);
            messageInput = string.Empty;

            StateHasChanged();
        });
        userInput = "Bhoomit Patel";
        messageInput = "How are you?";
        messages.Add($"{userInput}: {messageInput}");
        messageInput = string.Empty;
        userInput = string.Empty;

        await hubConnection.StartAsync();

    }


    async Task Send() =>
    await hubConnection.SendAsync("SendMessage", userInput, messageInput);


    public bool IsConnected =>
    hubConnection.State == HubConnectionState.Connected && messageInput != string.Empty;



    public async ValueTask DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }

    private void Keypress(KeyboardEventArgs args)
    {
        messageInput = null;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
