namespace KT.Domain.Common.Models;

/// <summary>
/// A value object is an object that is defined by its attributes.
/// Value objects have no unique identity, and are considered equal if their attributes are equal.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }

        return left?.Equals(right) != false;
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return EqualOperator(left, right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return NotEqualOperator(left, right);
    }

    public static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !EqualOperator(left, right);
    }

    public abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
    }

    public ValueObject GetCopy()
    {
        return MemberwiseClone() as ValueObject 
            ?? throw new InvalidOperationException("Clone operation failed.");
    }

    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }
}
