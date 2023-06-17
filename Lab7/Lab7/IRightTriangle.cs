using System;

namespace Lab7
{
    public interface IRightTriangle
    {
        double side1 { set; get; }
        double side2 { set; get; }
        double side3 { set; get; }
        void printPerimeter();
        void calculateArea();
        void calculateInnerRadius();
        void calculateOuterRadius();
        void printAllMembers();
    }
}
