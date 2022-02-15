namespace Astrolabe.Core.Utilities.Security;

/// <summary>
/// Представляет точку входя для использования набора методов расширения проверки аргументов.
/// </summary>
public class Security : ISecurityDirective
{
    /// <summary>
    /// 
    /// </summary>
    public static ISecurityDirective ProtectFrom { get; } = new Security();

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Security"/>.
    /// </summary>
    private Security() { /* */ }
}