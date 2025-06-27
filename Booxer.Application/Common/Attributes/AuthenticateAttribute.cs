namespace Booxer.Application.Common.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class AuthenticateAttribute : Attribute
{
    public bool AdminOnly { get; init; }
}