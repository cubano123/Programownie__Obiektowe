// TESTY
Ułamek a = new Ułamek(1, 2);
Ułamek b = new Ułamek(25, 6);
Ułamek c = new Ułamek(4, 8);

Console.WriteLine("Ułamek a = " + a);
Console.WriteLine("Ułamek b = " + b);
Console.WriteLine("Ułamek c = " + c);

Console.WriteLine();

Console.WriteLine("Dodawanie: " + (a + b));
Console.WriteLine("Odejmowanie: " + (a - b));
Console.WriteLine("Mnożenie: " + (a * b));
Console.WriteLine("Mnożenie z liczba: a * 3 = " + (a * 3));
Console.WriteLine("Dzielenie: " + (a / b));

Console.WriteLine();

Console.WriteLine("Czy a = b? -> " + (a == b));
Console.WriteLine("Czy a > b? -> " + (a > b));
Console.WriteLine("Czy a >= b? -> " + (a >= b));
Console.WriteLine("Czy a < b? -> " + (a < b));
Console.WriteLine("Czy a <= b? -> " + (a <= b));

Console.WriteLine();
c.Skracanie();

Console.WriteLine("Skracanie ułamka c: " + c);
Console.WriteLine("Zaokrąglij ułamek b: " + b.Zaokrąglij());

/// <summary>
/// Klasa Ułamek, operatory, równość i porównanie, metoda skracania i zaokrąglania
/// </summary>
public class Ułamek : IEquatable<Ułamek>, IComparable<Ułamek>
{
    private int licznik;
    private int mianownik;

    public Ułamek() // Podstawowy ułamek
    {
        this.licznik = 1;
        this.mianownik = 1;
    }

    public Ułamek(int licznik, int mianownik)
    {
        this.licznik = licznik;
        this.mianownik = mianownik;
    }

    public Ułamek(Ułamek ułamek)
    {
        this.licznik = ułamek.licznik;
        this.mianownik = ułamek.mianownik;
    }

    // ---

    public static Ułamek operator +(Ułamek a, Ułamek b) // dodawanie ułamków
        => new Ułamek(a.licznik * b.mianownik + b.licznik * a.mianownik, a.mianownik * b.mianownik);
    public static Ułamek operator -(Ułamek a, Ułamek b) // odejmowanie ułamków
        => new Ułamek(a.licznik * b.mianownik - b.licznik * a.mianownik, a.mianownik * b.mianownik);
    public static Ułamek operator *(Ułamek a, Ułamek b) // mnożenie ułamków
        => new Ułamek(a.licznik * b.licznik, a.mianownik * b.mianownik);
    public static Ułamek operator *(Ułamek a, int b) // mnożenie ułamka i liczby
        => new Ułamek(a.licznik * b, a.mianownik);
    public static Ułamek operator /(Ułamek a, Ułamek b) // dzielenie ułamków
    {
        if (b.licznik == 0)
            throw new DivideByZeroException(); // brak możliwości dzielenia przez 0

        else
            return new Ułamek(a.licznik * b.mianownik, a.mianownik * b.licznik);
    }

    // ---

    public static bool operator ==(Ułamek a, Ułamek b) // a = b
    {
        if (a is null || b is null)
            return false;
        if (a.licznik * b.mianownik == a.mianownik * b.licznik)
            return true;
        else
            return false;
    }
    public static bool operator !=(Ułamek a, Ułamek b) // a != b
    {
        return !(a == b);
    }
    public static bool operator >(Ułamek a, Ułamek b) // a > b
    {
        if (a is null || b is null || a == b)
            return false;
        if (a.licznik * b.mianownik > a.mianownik * b.licznik)
            return true;
        else return false;
    }
    public static bool operator >=(Ułamek a, Ułamek b) // a >= b
    {
        if (a is null || b is null)
            return false;
        if (a.licznik * b.mianownik >= a.mianownik * b.licznik)
            return true;
        else return false;
    }
    public static bool operator <(Ułamek a, Ułamek b) // a < b
    {
        if (a is null || b is null || a == b)
            return false;
        if (a.licznik * b.mianownik < a.mianownik * b.licznik)
            return true;
        else return false;
    }
    public static bool operator <=(Ułamek a, Ułamek b) // a <= b
    {
        if (a is null || b is null)
            return false;
        if (a.licznik * b.mianownik <= a.mianownik * b.licznik)
            return true;
        else return false;
    }

    // ---

    public override string ToString() // Poprawny zapis ułamka
    {
        if (this.licznik == this.mianownik)
            return "1";
        else if (mianownik == 1)
            return licznik.ToString();
        else if (licznik == 0 && mianownik == 0)
            return "Symbol nieoznaczony 0/0";
        else
            return $"{licznik}/{mianownik}";
    }

    // ---

    public void Skracanie() // Skracanie ułamków za pomocą NWD
    {
        int nwd = Nwd(licznik, mianownik);
        this.licznik /= nwd;
        this.mianownik /= nwd;
    }

    public int Nwd(int a, int b) // Największy wspólny dzielnik
    {
        while (a != b)
        {
            if (a > b)
                a -= b;
            else
                b -= a;
            return a;
        }
        return a;
    }
    public double Zaokrąglij() =>
           Math.Round((double)this.licznik / (double)this.mianownik); // Zaokrąglanie ułamków

    // ---

    public override int GetHashCode()
    {
        return HashCode.Combine(licznik, mianownik);
    }

    public bool Equals(Ułamek other) => this == other;

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (!(obj is Ułamek)) return false;
        Ułamek? x;

        if (obj is Ułamek) x = (Ułamek)obj;
        else x = new Ułamek((int)obj, 1);

        return x == this;
    }

    public int CompareTo(Ułamek other)
    {
        if (other == this)
            return 0;
        if (this > other)
            return 1;
        else
            return -1;
    }
}
