using System.Diagnostics.CodeAnalysis;

namespace Backend.Domain.Common;

public readonly struct ShortGuid : IParsable<ShortGuid>, IEquatable<ShortGuid>
{
    public static readonly ShortGuid Empty = new(Guid.Empty);

    /// <summary>
    /// 128-bits Guid representation
    /// </summary>
    private readonly Guid guid;

    /// <summary>
    /// 22 chars representation of the ShortGuid
    /// </summary>
    private readonly string value;

    /// <summary>
    /// Returns a ShortGuid instance from an existing Guid
    /// </summary>
    public ShortGuid(Guid guid)
    {
        this.value = Encode(guid);
        this.guid = guid;
    }

    /// <summary>
    /// Returns a ShortGuid instance from a ShortGuid string
    /// </summary>
    public ShortGuid(string value)
    {
        this.value = value;
        this.guid = Decode(value);
    }

    /// <summary>
    /// Encodes an existing Guid string value to a ShortGuid string
    /// </summary>
    /// <param name="value">Guid string value</param>
    /// <returns>ShortGuid string representation</returns>
    public static string Encode(string value)
    {
        return Encode(new Guid(value));
    }

    /// <summary>
    /// Encodes an existing Guid value to a ShortGuid string
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

    public static bool CanParse(string? s)
    {
        // TODO: Implement a more complete check if the value is a valid ShortGuid
        return !string.IsNullOrEmpty(s) && s.Length == 22;
    }

    #region IParsable<ShortGuid> implementation

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

    #endregion

    public override string ToString()
    {
        return this.value;
    }

    public override int GetHashCode()
        => this.value.GetHashCode();

    public bool Equals(ShortGuid other)
        => other.value == this.value;

    public override bool Equals([NotNullWhen(true)] object? obj)
        => obj is ShortGuid sg && sg.value == this.value;

    public static implicit operator Guid(ShortGuid shortGuid)
        => shortGuid.guid;

    public static bool operator ==(ShortGuid x, ShortGuid y)
        => x.value == y.value;

    public static bool operator !=(ShortGuid x, ShortGuid y)
        => !(x == y);
}
