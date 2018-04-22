
namespace CarStuff
{
    public interface ICar
    {
        void Drive();
        int GetSpeed();
        OptionsPackage Options {set; get;}
    }
}
