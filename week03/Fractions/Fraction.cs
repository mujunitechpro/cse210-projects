using System;
public class Fraction
{
    //private attributes
    private int _top;
    private int _bottom;

    //constructor with no parameters

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    //constructor with one parameter

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    //constructor with two parameters

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    //Getter and setter for top
    public int GetTop()
    {
        return _top;
    }
    public void SetTop(int top)
    {
        _top = top;
    }

    //Getter and Setter for bottom
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    //returns fraction as a string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    //returns decimal value
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
