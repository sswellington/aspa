namespace Aspa.Shared.Logger;

/// <summary>
/// Represents the importance levels for log events, following the Serilog convention.
/// Levels are listed in increasing order of importance:
/// <list type="number">
///     <item><term><b>Verbose: </b></term><description>Tracing information and debugging minutiae; generally only switched on in unusual situations.</description></item>
///     <item><term><b>Debug: </b></term><description>Internal control flow and diagnostic state dumps to facilitate pinpointing of recognized problems.</description></item>
///     <item><term><b>Information: </b></term><description>Events of interest or that have relevance to outside observers; the default enabled minimum logging level.</description></item>
///     <item><term><b>Warning: </b></term><description>Indicators of possible issues or service/functionality degradation.</description></item>
///     <item><term><b>Error: </b></term><description>Indicates a failure within the application or connected system.</description></item>
///     <item><term><b>Fatal: </b></term><description>Critical errors causing complete failure of the application.</description></item>
/// </list>
/// For more details, refer to: <a href="https://github.com/serilog/serilog/wiki/Writing-Log-Events#log-event-levels">Serilog Wiki - Log Event Levels</a>
/// </summary>
public enum Level
{
    Verbose = 1,
    Debug = 2,
    Information = 3,
    Warning = 4,
    Error = 5,
    Fatal = 6
}