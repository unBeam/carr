using Cysharp.Threading.Tasks;

public interface ICarFactory
{ 
    void CreateCar(ICarConfig carConfig);
}
