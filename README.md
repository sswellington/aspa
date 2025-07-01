# Aspa - HTML Generator

This C\# project, **Aspa HTML Generator**, is a lightweight, code-driven solution for generating static HTML websites. Instead of relying on traditional templating engines or manual HTML editing, it allows developers to programmatically construct web pages directly within C\# code.

The core idea is to define HTML structures and content using C\# methods and then render these into complete HTML files. This approach is particularly useful for:

  * **Automated Content Generation:** Easily create multiple pages with consistent layouts and dynamic content sourced from code.
  * **Simple Static Sites:** It's ideal for portfolios, blogs, or small informational sites where server-side rendering or complex frameworks aren't needed.
  * **Version Control Integration:** Manage your website's structure and content directly within your codebase, leveraging Git for versioning.
  * **Developer-Friendly Workflow:** For C\# developers, it offers a familiar environment to build web content without switching contexts to HTML or templating languages.

### How It Works

The project leverages a `Template` class (likely `Aspa.Html.Constants.Template`) that holds various base HTML structures, each pre-configured with different CSS frameworks (like Bootstrap, Bulma, Materialize, etc.). The `Syntax` utility class (from `Aspa.Html.Utils`) provides methods to create HTML elements (headings, paragraphs, etc.) within a C\# context.

The `Program.Main` method demonstrates the workflow:

1.  **Page Construction:** It uses methods like `Syntax.Heading`, `Syntax.Paragraph`, and `Syntax.Super` to add content to a virtual page.
2.  **HTML Rendering:** `Syntax.Render` takes the constructed content and wraps it within one of the chosen base HTML templates (including its associated CSS/JS).
3.  **File Saving:** `File.WriteAllText` then saves the generated HTML strings to physical `.html` files (e.g., `index.html`, `about.html`, `blog.html`).
4.  **Logging:** `Aspa.Shared.Logger.Service` is used to log the generation process, providing clear feedback on page creation and saving.

In essence, this project simplifies the creation of static web content by making HTML generation a first-class citizen within a C\# application, offering a programmatic and maintainable way to build simple websites.

---

# How to Run the Project

To run the Aspa HTML Generator project, you'll need the .NET SDK installed on your machine. Based on your `.csproj` file, the project targets .NET 9.0.

### Prerequisites

  * **.NET 9.0 SDK:** Ensure you have the .NET 9.0 SDK installed. You can download it from the [official .NET website](https://dotnet.microsoft.com/download/dotnet/9.0).

### Steps to Execute

1.  **Navigate to the Project Directory:**
    Open your terminal or command prompt and change the directory to the root of your `Aspa` project (the folder containing `src/`, `public/`, etc.).

    For example, if your project structure is like this:

    ```
    Aspa/
    ├── src/
    │   ├── Aspa.csproj
    │   ├── Html/
    │   └── Program.cs
    ├── public/
    ├── tests/
    ├── log/
    └── doc/
    ```

    You should navigate to the `Aspa` directory.

2.  **Run the Project:**
    Execute the following command from your project's root directory:

    ```bash
    dotnet run --project .\src\Aspa.csproj
    ```

    If your current working directory in the terminal is already `Aspa/src/`, you can simply run:

    ```bash
    dotnet run
    ```

    This command will build and run your C\# application.

### What to Expect

Upon execution, the program will:

  * Generate `index.html`, `about.html`, and `blog.html` files in a designated output directory (typically `bin/Debug/net9.0/` relative to your `Aspa.csproj` file, or a configured output path).
  * Output informational messages to the console regarding page generation and file saving, thanks to your `Aspa.Shared.Logger.Service`.

After the execution completes, you can open the generated HTML files in a web browser to see the results.

-----

# Contributions

We warmly welcome contributions to the Aspa HTML Generator project\! Whether you're looking to add new CSS frameworks, improve existing features, fix bugs, or enhance documentation, your help is greatly appreciated.

### How to Contribute

1.  **Fork the Repository:** Start by forking the project repository on GitHub.
2.  **Clone Your Fork:** Clone your forked repository to your local machine:
    ```bash
    git clone https://github.com/your-username/AspaHtmlGenerator.git
    ```
    (Remember to replace `your-username` with your actual GitHub username.)
3.  **Create a New Branch:** Create a new branch for your feature or bug fix. Choose a descriptive name:
    ```bash
    git checkout -b feat/add-new-framework
    # or
    git checkout -b fix/resolve-bug-xyz
    ```
4.  **Make Your Changes:** Implement your changes, adhering to the project's existing coding style and conventions.
5.  **Test Your Changes:** Thoroughly test your changes to ensure they work as expected and do not introduce any regressions.
6.  **Commit Your Changes:** Write clear, concise, and descriptive commit messages. We recommend following the [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) specification.
    ```bash
    git commit -m "feat: Add support for new CSS framework"
    ```
7.  **Push to Your Fork:** Push your new branch to your forked repository on GitHub:
    ```bash
    git push origin feat/add-new-framework
    ```
8.  **Open a Pull Request:** Navigate to the original Aspa HTML Generator repository on GitHub and open a new Pull Request from your branch. Provide a detailed description of your changes and link to any relevant issues.

We'll review your contribution as soon as possible. Thank you for helping make Aspa HTML Generator better for everyone\!