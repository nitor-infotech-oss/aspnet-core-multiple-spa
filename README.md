# Serve multiple [React](https://reactjs.org/) applications with Single [ASP.NET Core](https://docs.microsoft.com/en-gb/aspnet/core/) Web Application

[![Greenkeeper badge](https://badges.greenkeeper.io/nitor-infotech-oss/aspnet-core-multiple-spa.svg)](https://greenkeeper.io/)


## Idea

The ASP.NET Core is providing amazing experience building [Single Page Application with React](https://docs.microsoft.com/en-gb/aspnet/core/client-side/spa/react). You can create a single application either in React or [Angular](https://docs.microsoft.com/en-gb/aspnet/core/client-side/spa/angular) and serve the application using [Kestrel](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel). This is made possible with [JavaScriptServices](https://docs.microsoft.com/en-gb/aspnet/core/client-side/spa-services)

What we are really implementing here is the capability to serve multiple Single Page Applications (Modules) under a single ASP.NET core Web Application

It is a hack, this is an utility can be used with any Client Side JavaScript application or framework with minor customization, you can customize and set your own conventions

## How it works

1. Every Single Page Application build produces a consistent output with a single HTML Page
2. The HTML page - `index.html`, has references to style bundles and script bundles and a placeholder to render the client side application
3. `SPAHelper` Class has few helper methods which can extract the `head` and `body` section and render in your `Razor Views` or `Razor Pages`

    - `RenderReactHead` will extract styles and other `head` tags and render those in View (You can use layout sections to put that under layout head)

    ```html
        @section Styles {
            @await Html.RenderReactHead("sample-app-1", "wwwroot/sample-app-1/index.html")
        }
    ```

    - `RenderReactBody` will extract body along with script imports and render those in View

    ```html
        @await Html.RenderReactBody("sample-app-1", "wwwroot/sample-app-1/index.html")
    ```

4. The output of SPA build is kept under `sample-app-1` under `wwwroot`, you can follow this convention to render multiple SPAs with every Action Method and View

5. If you are using [React Router](https://reacttraining.com/react-router), you can add following conditional route mapping to avoid `404 HTTP status code` on page refresh. This will always render server side View before activating client side routing

    ```csharp
        app.MapWhen(
            context => context.Request.Path.Value.StartsWith("/Apps/App1"), 
            builder => {
            builder.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    "spa-app1-fallback",
                    new { controller = "Apps", action = "App1" }
                );
            });
        });
    ```

## Todos

1. ~~Automate build and copying SPA output~~
2. Build target for Project to automate publishing with SPA output
