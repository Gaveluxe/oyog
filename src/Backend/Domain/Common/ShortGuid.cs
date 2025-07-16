using System.Diagnostics.CodeAnalysis;

namespace Backend.Domain.Common;

public readonly struct ShortGuid : IParsable<ShortGuid>, IEquatable<ShortGuid>
{
    public static readonly ShortGuid Empty = new(Guid.Empty);

    /// <summary>
    /// Returns the 128-bits Guid representation
    /// </summary>
    public Guid Guid { get; }

    /// <summary>
    /// Returns the 22 chars representation of the ShortGuid
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Returns a ShortGuid instance from an existing Guid
    /// </summary>
    public ShortGuid(Guid guid)
    {
        this.Value = Encode(guid);
        this.Guid = guid;
    }

    /// <summary>
    /// Returns a ShortGuid instance from a ShortGuid string
    /// </summary>
    public ShortGuid(string value)
    {
        this.Value = value;
        this.Guid = Decode(value);
    }

    /// <summary>
    /// Encodes an existing Guid string value to a ShortGuid
    /// </summary>
    /// <param name="value">Guid string value</param>
    /// <returns>ShortGuid string representation</returns>
    public static string Encode(string value)
    {
        return Encode(new Guid(value));
    }

    /// <summary>
    /// Encodes an existing Guid value to a ShortGuid
    /// </summary>
    /// <param name="value">Guid value</param>
    /// <returns>ShortGuid string representation</returns>
    public static string Encode(Guid value)
    {
        var encoded = Convert.ToBase64String(value.ToByteArray());
        return encoded
            .Replace("/", "_")
            .Replace("+", "-")[..22];
    }

    /// <summary>
    /// Decodes an existing ShortGuid string value to a full Guid
    /// </summary>
    /// <param name="value">ShortGuid string representation</param>
    /// <returns>Full Guid value</returns>
    public static Guid Decode(string value)
    {
        var sanitized = value
            .Replace("_", "/")
            .Replace("-", "+");

        var buffer = Convert.FromBase64String(sanitized + "==");
        return new Guid(buffer);
    }

    public static ShortGuid Parse(string s, IFormatProvider? provider)
    {
        return new(s);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ShortGuid result)
    {
        if (s is null)
        {
            result = ShortGuid.Empty;
            return false;
        }

        result = new(s);
        return true;
    }

    public bool Equals(ShortGuid other)
    {
        return other.Value == this.Value;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is ShortGuid sg && sg.Value == this.Value;
    }

    public static bool operator ==(ShortGuid x, ShortGuid y)
    {
        return x.Value == y.Value;
    }

    public static bool operator !=(ShortGuid x, ShortGuid y)
    {
        return !(x == y);
    }

    public override int GetHashCode()
    {
        return this.Value.GetHashCode();
    }
}
