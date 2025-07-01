using System.Text;

namespace Aspa.Html.Constants;

public static class Template
{
    /// <summary>
    /// Provides the base HTML structure for all page templates.
    /// This method injects CSS links and JavaScript scripts into the appropriate placeholders.
    /// </summary>
    /// <param name="cssLinks">A string containing all &lt;link&gt; tags for CSS to be injected into the &lt;head&gt;.</param>
    /// <param name="jsScripts">A string containing all &lt;script&gt; tags for JavaScript to be injected before the closing &lt;/body&gt; tag.</param>
    /// <returns>A string representing the complete HTML structure with styles and scripts applied.</returns>
    private static string Base(string cssLinks, string jsScripts)
    {
        return new StringBuilder().Append(
                """
                <!DOCTYPE  PUBLIC "-//W3C//DTD X 1.0 Transitional//EN" "http://www.w3.org/TR/x1/DTD/x1-transitional.dtd">
                < lang="pt-br" xmlns="http://www.w3.org/1999/x" xml:lang="pt-br">
                    <head>
                        <meta charset='utf-8'>
                        <meta http-equiv="Cache-control" content="public">
                        <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                        <meta name='viewport' content='width=device-width, initial-scale=1'>
                        <meta name="author" content="github.com/sswellington"/>
                        <meta name="robots" content="Software Developer .NET SQL Server Python">
                        <meta name="keywords" content="Software Developer .NET SQL Server Python" />

                        <title></title>
                        
                        <link rel="stylesheet" href="assets/css/reset.min.css" />
                        
                """
            )
            .Append(cssLinks)
            .Append(
                """

                    </head>
                    <body>
                        <header>
                            <nav id="nav">
                                <a href="./"> 🏠 Home &nbsp </a>
                                <a href="./blog"> 📝 Blog &nbsp </a>
                                <a href="./about"> 🤵 About &nbsp</a>
                            </nav>
                        </header>
                        <main></main>
                        
                """
            )
            .Append(jsScripts)
            .Append(
                """

                    </body>
                </>
                """
            )
            .ToString();
    }
    
    /// <summary>
    /// Generates the complete HTML template using Bootstrap 5.
    /// Includes the Bootstrap JavaScript bundle.
    /// Documentation: <see href="https://getbootstrap.com/"/>.
    /// </summary>
    /// <returns>An HTML string with Bootstrap 5 applied.</returns>
    public static string Bootstrap()
    {
        const string css = $"<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr\" crossorigin=\"anonymous\">";
        const string js = "<script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q\" crossorigin=\"anonymous\"></script>";
        return Base(css, js);
    }
    
    /// <summary>
    /// Generates the complete HTML template using the Bulma framework.
    /// Documentation: <see href="https://bulma.io/"/>.
    /// </summary>
    /// <returns>An HTML string with Bulma applied.</returns>
    public static string Bulma()
    {
        const string css = $"<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bulma@1.0.4/css/bulma.min.css\">";
        return Base(css, "");
    }
    
    /// <summary>
    /// Generates the complete HTML template using the Foundation framework.
    /// Documentation: <see href="https://get.foundation/index.html"/>.
    /// </summary>
    /// <returns>An HTML string with Foundation applied.</returns>
    public static string Foundation()
    {
        const string css = $"<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/foundation-sites@6.9.0/dist/css/foundation.min.css\" crossorigin=\"anonymous\">";
        const string js = "<script src=\"https://cdn.jsdelivr.net/npm/foundation-sites@6.9.0/dist/js/foundation.min.js\" crossorigin=\"anonymous\"></script>";
        return Base(css, js);
    }
    
    /// <summary>
    /// Generates the complete HTML template using Materialize CSS.
    /// Includes Materialize JavaScript.
    /// Documentation: <see href="https://materializecss.com/"/>.
    /// </summary>
    /// <returns>An HTML string with Materialize CSS applied.</returns>
    public static string MaterializeCss()
    {
        const string css = $"<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css\">";
        const string js = "<script src=\"https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js\"></script>";
        return Base(css, js);
    }
    
    /// <summary>
    /// Generates the complete HTML template using Material Design Lite (MDL).
    /// Includes Material Icons and the MDL JavaScript.
    /// Documentation: <see href="https://getmdl.io/"/>.
    /// </summary>
    /// <returns>An HTML string with Material Design Lite applied.</returns>
    public static string MaterialLight()
    {
        const string css = $"<link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/icon?family=Material+Icons\">\n<link rel=\"stylesheet\" href=\"https://code.mdl.io/1.3.0/material.indigo-pink.min.css\">";
        const string js = "<script defer src=\"https://code.mdl.io/1.3.0/material.min.js\"></script>";
        return Base(css, js);
    }
    
    /// <summary>
    /// Generates the complete HTML template using the Milligram framework.
    /// Includes Normalize.css and Google Fonts.
    /// Documentation: <see href="https://milligram.io/"/>.
    /// </summary>
    /// <returns>An HTML string with Milligram applied.</returns>
    public static string Milligram()
    {
        const string css = """
                           <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,300italic,700,700italic">
                           <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/8.0.1/normalize.css">
                           <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/milligram/1.4.1/milligram.css">
                           """;
        return Base(css, "");
    }
    
    /// <summary>
    /// Generates the complete HTML template using the New.css framework.
    /// Documentation: <see href="https://newcss.net/"/>.
    /// </summary>
    /// <returns>An HTML string with New.css applied.</returns>
    public static string NewCss()
    {
        const string css = "<link rel=\"stylesheet\" href=\"assets/css/new.min.css\" />\n<link rel=\"stylesheet\" href=\"assets/css/style.css\" />";
        return Base(css, "");
    }
    
    /// <summary>
    /// Generates the complete HTML template using Pure.css.
    /// Documentation: <see href="https://pure-css.github.io/"/>.
    /// </summary>
    /// <returns>An HTML string with Pure.css applied.</returns>
    public static string PureCss()
    {
        const string css = $"<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/purecss@3.0.0/build/pure-min.css\" integrity=\"sha384-X38yfunGUhNzHpBaEBsWLO+A0HDYOQi8ufWDkZ0k9e0eXz/tH3II7uKZ9msv++Ls\" crossorigin=\"anonymous\">";
        return Base(css, "");
    }
    
    /// <summary>
    /// Generates the complete HTML template using Semantic UI.
    /// Includes jQuery and the Semantic UI JavaScript.
    /// Documentation: <see href="https://semantic-ui.com/"/>.
    /// </summary>
    /// <returns>An HTML string with Semantic UI applied.</returns>
    public static string SemanticUi()
    {
        const string css = $"<link rel=\"stylesheet\" type=\"text/css\" href=\"semantic/dist/semantic.min.css\">";
        const string js = """
                          <script
                            src="https://code.jquery.com/jquery-3.1.1.min.js"
                            integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8="
                            crossorigin="anonymous"></script>
                          <script src="semantic/dist/semantic.min.js"></script>
                          """;
        return Base(css, js);
    }

    /// <summary>
    /// Generates the complete HTML template using the Spectre.css framework.
    /// Includes experimental and icon extensions.
    /// Documentation: <see href="https://picturepan2.github.io/spectre/index.html"/>.
    /// </summary>
    /// <returns>An HTML string with Spectre.css applied.</returns>
    public static string Spectre()
    {
        const string css = $"<link rel=\"stylesheet\" href=\"https://unpkg.com/spectre.css/dist/spectre.min.css\">\n<link rel=\"stylesheet\" href=\"https://unpkg.com/spectre.css/dist/spectre-exp.min.css\">\n<link rel=\"stylesheet\" href=\"https://unpkg.com/spectre.css/dist/spectre-icons.min.css\">";
        return Base(css, "");
    }
    
    /// <summary>
    /// Generates the complete HTML template using the Vanilla Framework.
    /// Documentation: <see href="https://vanillaframework.io/"/>.
    /// </summary>
    /// <returns>An HTML string with the Vanilla Framework applied.</returns>
    public static string Vanilla()
    {
        const string css = $"<link rel=\"stylesheet\" href=\"https://assets.ubuntu.com/v1/vanilla-framework-version-4.24.1.min.css\" />";
        return Base(css, "");
    }
    
    /// <summary>
    /// Generates the complete HTML template using the Water.css framework.
    /// Documentation: <see href="https://watercss.kognise.dev/"/>.
    /// </summary>
    /// <returns>An HTML string with Water.css applied.</returns>
    public static string WaterCss()
    {
        const string css = $"<link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/water.css@2/out/water.css\">";
        return Base(css, "");
    }
}