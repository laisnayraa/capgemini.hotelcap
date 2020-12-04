using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Fruta fruta = new Latanja();
        Debug.WriteLine(fruta.GetCor());
        fruta = new Maca();
        Debug.WriteLine(fruta.GetCor());
    }
}
public abstract class Fruta
{
    public abstract string GetCor();
}
public class Maca : Fruta
{
    public override string GetCor()
    {
        return "Red";
    }
}
public class Latanja : Fruta
{
    public override string GetCor()
    {
        return "Latanja";
    }
}