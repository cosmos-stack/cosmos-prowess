namespace Cosmos.Validations.Internals
{
    public interface IUnionValidationModel<out TLeft, out TRight>
    {
        UnionValidationTarget Target { get; }

        TLeft LeftModel { get; }

        TRight RightModel { get; }
    }
}